using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

// Author: Angela Li
namespace sprint0
{
    public class Gohma : ISprite
    {
        private Game1 game;
        public Vector2 Location { get; set; } // location of the head
        public Texture2D Texture { get; set; }
        private readonly int size = 16;
        private Dictionary<string, List<Rectangle>> colorToLegMap, colorToHeadMap;
        private List<SpriteEffects> leftLegEffects, rightLegEffects;
        private string color;
        private int headCurrFrame, legCurrFrame;
        private readonly int headTotalFrames, headRepeatedFrames, legTotalFrames, legRepeatedFrames;
        private int currDest;
        private readonly int moveDelay; // delay to make slower bc floats mess up drawings; must be < legTotalFrames*legRepeatedFrames
        private List<Vector2> destinations; // gohma moves to predetermined destinations
        private ManhandlaFireball fireball; // TODO no gohma fireball, so manhandla for now
        private Vector2 centerOffset; // fireball shoots from center of gohma

        public Gohma(Texture2D texture, Vector2 location, string color, Game1 game)
        {
            Location = location;
            Texture = texture;
            this.game = game;
            this.color = color;
            headCurrFrame = 0;
            legCurrFrame = 0;
            headTotalFrames = 4;
            headRepeatedFrames = 12;
            legTotalFrames = 2;
            legRepeatedFrames = 14;

            colorToLegMap = new Dictionary<string, List<Rectangle>>
            {
                { "orange", GetFrames(196, 105, legTotalFrames) },
                { "blue", GetFrames(196, 122, legTotalFrames) }
            };
            leftLegEffects = new List<SpriteEffects>
            {
                SpriteEffects.None,
                SpriteEffects.FlipHorizontally
            };
            rightLegEffects = new List<SpriteEffects>
            {
                SpriteEffects.FlipHorizontally,
                SpriteEffects.None
            };
            colorToHeadMap = new Dictionary<string, List<Rectangle>>
            {
                { "orange", GetFrames(230, 105, headTotalFrames) },
                { "blue", GetFrames(230, 122, headTotalFrames) }
            };

            currDest = 0;
            moveDelay = 2; //slow spooder
            destinations = new List<Vector2>
            {
                location,
                location + new Vector2(100,0),
                location,
                location + new Vector2(0,100)
            };

            fireball = new ManhandlaFireball(texture);
            centerOffset = new Vector2(size / 2 - 4, size / 2 - 5); // gohma size / 2 - fireball size / 2
        }

        //TODO make a utility class so we can reuse this code??? this is in a lot of places rn
        public List<Rectangle> GetFrames(int xOffset, int yOffset, int totalFrames)
        {
            List<Rectangle> sources = new List<Rectangle>();
            for (int frame = 0; frame < totalFrames; frame++)
            {
                sources.Add(new Rectangle(xOffset + frame * (size + 1), yOffset, size, size));
            };
            return sources;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            // draws the left leg
            spriteBatch.Draw(
                Texture, Location + new Vector2(-size, 0),
                colorToLegMap[color][legCurrFrame / legRepeatedFrames],
                Color.White, 0, new Vector2(0,0), 1,
                leftLegEffects[legCurrFrame / legRepeatedFrames], 0);

            // draws the head
            spriteBatch.Draw(Texture, Location, colorToHeadMap[color][headCurrFrame / headRepeatedFrames], Color.White);

            // draws the right leg; left/right leg should be opposite frames
            spriteBatch.Draw(
                Texture, Location + new Vector2(size, 0),
                colorToLegMap[color][(legCurrFrame / legRepeatedFrames + 1) % legTotalFrames], // TODO refator: this is probably overly complicated
                Color.White, 0, new Vector2(0, 0), 1,
                rightLegEffects[(legCurrFrame / legRepeatedFrames + 1) % legTotalFrames], 0);

            // draws fireball
            fireball.Draw(spriteBatch);
        }

        public void Update()
        {
            Vector2 dist = destinations[currDest] - Location;
            if (dist.Length() == 0) // can use exact bc no floating point errors for whole numbers
            {
                // reached destination, so pick a new destination
                currDest = (currDest + 1) % destinations.Count;
            }
            else if (legCurrFrame % moveDelay == 0)
            {
                // has not reached destination, move towards it
                dist.Normalize();
                Location += dist;
            }

            // animates all the time for now
            headCurrFrame = (headCurrFrame + 1) % (headTotalFrames * headRepeatedFrames);
            legCurrFrame = (legCurrFrame + 1) % (legTotalFrames * legRepeatedFrames);

            // shoot fireball
            if (CanShoot())
            {
                ShootFireball();
            }
            else
            {
                fireball.Update();
            }
        }

        private bool CanShoot() // shoot fireball if fireball is dead
        {
            return fireball.IsDead;
        }

        private void ShootFireball()
        {
            Vector2 dir = game.Player.Position - (Location + centerOffset);
            dir.Normalize();
            fireball.Direction = dir;
            fireball.Location = Location + centerOffset;
            fireball.IsDead = false;
        }
    }
}
