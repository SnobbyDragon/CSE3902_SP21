using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

// Author: Angela Li
namespace sprint0
{
    public class Gohma : IEnemy
    {
        private Game1 game;
        public Rectangle Location { get; set; } // location of the head
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
        private Vector2 centerOffset; // fireball shoots from center of gohma
        private readonly int fireballRate = 100; //TODO currently arbitrary
        private int fireballCounter = 0;
        private int health;
        public Gohma(Texture2D texture, Vector2 location, string color, Game1 game)
        {
            health = 25;
            Location = new Rectangle((int)location.X, (int)location.Y, (int)(size * Game1.Scale), (int)(size * Game1.Scale));
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
                { "orange", SpritesheetHelper.GetFramesH(196, 105, size, size, legTotalFrames) },
                { "blue", SpritesheetHelper.GetFramesH(196, 122, size, size, legTotalFrames) }
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
                { "orange", SpritesheetHelper.GetFramesH(230, 105, size, size, headTotalFrames) },
                { "blue", SpritesheetHelper.GetFramesH(230, 122, size, size, headTotalFrames) }
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

            centerOffset = new Vector2(size / 2 - 4, size / 2 - 5); // gohma size / 2 - fireball size / 2
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            // draws the left leg
            spriteBatch.Draw(
                Texture, new Rectangle(Location.X - (int)(size * Game1.Scale), Location.Y, (int)(size * Game1.Scale), (int)(size * Game1.Scale)),
                colorToLegMap[color][legCurrFrame / legRepeatedFrames],
                Color.White, 0, new Vector2(0, 0),
                leftLegEffects[legCurrFrame / legRepeatedFrames], 0);

            // draws the right leg; left/right leg should be opposite frames
            spriteBatch.Draw(
                Texture, new Rectangle(Location.X + (int)(size * Game1.Scale), Location.Y, (int)(size * Game1.Scale), (int)(size * Game1.Scale)),
                colorToLegMap[color][(legCurrFrame / legRepeatedFrames + 1) % legTotalFrames], // TODO refator: this is probably overly complicated
                Color.White, 0, new Vector2(0, 0),
                rightLegEffects[(legCurrFrame / legRepeatedFrames + 1) % legTotalFrames], 0);


            // draws the head
            spriteBatch.Draw(Texture, Location, colorToHeadMap[color][headCurrFrame / headRepeatedFrames], Color.White);
        }

        public void Update()
        {
            CheckHealth();
            Vector2 dist = destinations[currDest] - Location.Location.ToVector2();
            if (dist.Length() == 0) // can use exact bc no floating point errors for whole numbers
            {
                // reached destination, so pick a new destination
                currDest = (currDest + 1) % destinations.Count;
            }
            else if (legCurrFrame % moveDelay == 0)
            {
                // has not reached destination, move towards it
                dist.Normalize();
                Rectangle loc = Location;
                loc.Offset(ApproximateDirection(dist));
                Location = loc;
            }

            // animates all the time for now
            headCurrFrame = (headCurrFrame + 1) % (headTotalFrames * headRepeatedFrames);
            legCurrFrame = (legCurrFrame + 1) % (legTotalFrames * legRepeatedFrames);

            // shoot fireball
            if (CanShoot())
            {
                ShootFireball();
            }
        }

        public void ChangeDirection()
        {
            // TODO
        }

        private void CheckHealth()
        {
            if (health < 0) Perish();
        }
        public void TakeDamage(int damage)
        {
            health -= damage;
        }

        public void Perish()
        {
            game.RemoveEnemy(this);
        }

        private bool CanShoot()
        {
            fireballCounter++;
            fireballCounter %= fireballRate;
            return fireballCounter == 0;
        }

        private void ShootFireball()
        {
            Vector2 dir = game.Player.Pos - (Location.Location.ToVector2() + centerOffset);
            dir.Normalize();
            game.AddFireball(Location.Center.ToVector2(), dir, this);
        }

        private Vector2 ApproximateDirection(Vector2 dir)
        {
            //TODO currently using vectors; maybe make IDirection interface?
            //Direction closestApprox;
            //foreach (Direction d in Enum.GetValues(typeof(Direction))) {}
            List<Vector2> vectors = new List<Vector2>
            {
                new Vector2(1, 0),
                new Vector2(-1, 0),
                new Vector2(0, 1),
                new Vector2(0, -1),
                new Vector2(1, 1),
                new Vector2(1, -1),
                new Vector2(-1, 1),
                new Vector2(-1, -1),
            };
            Vector2 closestApprox = vectors[0];
            float closestDist = (closestApprox - dir).LengthSquared();
            foreach (Vector2 v in vectors)
            {
                float dist = (v - dir).LengthSquared();
                if (dist < closestDist)
                {
                    closestApprox = v;
                    closestDist = dist;
                }
            }
            return closestApprox;
        }
    }
}
