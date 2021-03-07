using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

// Author: Angela Li
/*
 * Last updated: 3/4/21 by li.10011
 */
namespace sprint0
{
    public class Aquamentus : IEnemy
    {
        private readonly Game1 game;
        public Rectangle Location { get; set; }
        public Texture2D Texture { get; set; }
        private readonly int xOffset = 1, yOffset = 11, width = 24, height = 32;
        private readonly List<Rectangle> sources;
        private int currFrame;
        private readonly int totalFrames, repeatedFrames;
        private int currDest;
        private readonly int moveDelay; // delay to make slower bc floats mess up drawings; must be < totalFrames*repeatedFrames
        private readonly List<Vector2> destinations; // aquamentus moves to predetermined destinations TODO depends on link actually
        private readonly bool isDead; //TODO maybe should be in a more general class since a lot of sprites can die
        private Vector2 headOffset; // offsets from top left to center of aquamentus' head (where fireballs come from)
        private readonly int fireballRate = 100; //TODO currently arbitrary
        private int fireballCounter = 0;

        public Aquamentus(Texture2D texture, Vector2 location, Game1 game)
        {
            this.game = game;
            Location = new Rectangle((int)location.X, (int)location.Y, width, height);
            Texture = texture;
            currFrame = 0;
            totalFrames = 4;
            repeatedFrames = 14;
            headOffset = new Vector2(4, 4); //TODO must be scaled later when sprite is scaled
            sources = new List<Rectangle>();
            for (int frame = 0; frame < totalFrames; frame++)
            {
                sources.Add(new Rectangle(xOffset + frame * (width + 1), yOffset, width, height));
            };

            currDest = 0;
            moveDelay = 5; //slow dragoon
            destinations = new List<Vector2>
            {
                location,
                location + new Vector2(30,0)
            };

            isDead = false;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (!isDead) // only draws if alive
                spriteBatch.Draw(Texture, Location, sources[currFrame / repeatedFrames], Color.White);
        }

        public void Update()
        {
            if (!isDead)
            { // only moves and animates if alive
                Vector2 dist = destinations[currDest] - Location.Location.ToVector2();
                if (dist.Length() == 0)
                {
                    // reached destination, so pick a new destination
                    currDest = (currDest + 1) % destinations.Count;
                }
                else if (currFrame % moveDelay == 0)
                {
                    // has not reached destination, move towards it
                    dist.Normalize();
                    Rectangle loc = Location;
                    loc.Offset(dist);
                    Location = loc;
                }
                currFrame = (currFrame + 1) % (totalFrames * repeatedFrames);
            }
            // fireballs move and animate regardless
            if (CanShoot())
            {
                ShootFireballs();
            }
        }

        public void ChangeDirection()
        {
            // TODO
        }

        private bool CanShoot()
        {
            fireballCounter++;
            fireballCounter %= fireballRate;
            return fireballCounter == 0;
        }

        private void ShootFireballs()
        {
            Vector2 dir = game.Player.Pos - (Location.Location.ToVector2() + headOffset); // TODO offset to center of link
            dir.Normalize();
            game.AddFireball(Location.Center.ToVector2(), dir, this);
            game.AddFireball(Location.Center.ToVector2(), Vector2.Transform(dir, Matrix.CreateRotationZ((float)(Math.PI / 6))), this); // 30 degrees up
            game.AddFireball(Location.Center.ToVector2(), Vector2.Transform(dir, Matrix.CreateRotationZ((float)(-Math.PI / 6))), this); // 30 degrees down
        }
    }
}
