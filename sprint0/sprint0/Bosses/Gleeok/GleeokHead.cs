using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

// Author: Angela Li
namespace sprint0
{
    public class GleeokHead : ISprite
    {
        private Game1 game;
        public Vector2 Location { get; set; }
        public Texture2D Texture { get; set; }
        private Rectangle defaultSource;
        private bool isAngry; // if head is severed / angry, has different frames; TODO maybe change to state pattern later?
        private List<Rectangle> angrySources;
        private int currFrame;
        private readonly int totalFrames, repeatedFrames;
        private Vector2 anchor; // where the neck attaches to the body
        private Random rand;
        private readonly int size = 16; // head size
        private readonly int maxDistance = 50; // max distance head can be from anchor TODO might need adjusting
        private readonly int moveDelay; // delay to make slower bc floats mess up drawings
        private int moveCounter;
        private Vector2 destination;
        private GleeokFireball fireball;
        private Vector2 centerOffset;

        public GleeokHead(Texture2D texture, Vector2 anchor, Game1 game)
        {
            Texture = texture;
            this.game = game;
            currFrame = 0;
            totalFrames = 2;
            repeatedFrames = 4;
            moveDelay = 4;
            moveCounter = 0;
            defaultSource = new Rectangle(280, 11, 8, 16);
            isAngry = false;
            angrySources = new List<Rectangle>
            {
                new Rectangle(289, 11, size, size),
                new Rectangle(306, 11, size, size)
            };
            this.anchor = anchor;
            rand = new Random();
            // randomly generates head location
            Location = RandomLocation();
            destination = RandomLocation();

            fireball = new GleeokFireball(texture);
            centerOffset = new Vector2(size / 2 - 4, size / 2 - 5); // head size / 2 - fireball size / 2
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (isAngry)
                spriteBatch.Draw(Texture, Location, angrySources[currFrame / repeatedFrames], Color.White);
            else
                spriteBatch.Draw(Texture, Location, defaultSource, Color.White);

            fireball.Draw(spriteBatch);
        }

        public void Update()
        {
            if (isAngry)
            {
                currFrame = (currFrame + 1) % (totalFrames * repeatedFrames);
                //TODO movement for angry
            } else
            {
                Vector2 dist = destination - Location;
                if (dist.Length() < 2)
                {
                    // reached destination, so pick a new destination
                    destination = RandomLocation();
                }
                else if (moveCounter == moveDelay)
                {
                    // has not reached destination, move towards it
                    dist.Normalize();
                    Location +=  dist;
                    moveCounter = 0;
                }
                moveCounter++;
            }

            // fireballs move and animate regardless
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
            Vector2 dir = game.Player.Pos - (Location + centerOffset);
            dir.Normalize();
            fireball.Direction = dir;
            fireball.Location = Location + centerOffset;
            fireball.IsDead = false;
        }

        // generates random location
        public Vector2 RandomLocation()
        {
            // TODO depends on where link is?
            Vector2 dir = new Vector2(rand.Next(-100, 100), rand.Next(0, 100)); // location can only below anchor
            dir.Normalize();
            return anchor + rand.Next(0, maxDistance) * dir;
        }
    }
}
