using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace sprint0
{
    public class GleeokHead : ISprite
    {
        public Vector2 Location { get; set; }
        public Texture2D Texture { get; set; }
        private Rectangle defaultSource;
        private bool isAngry; // if head is severed / angry, has different frames; TODO maybe change to state pattern later?
        private List<Rectangle> angrySources;
        private int currFrame;
        private readonly int totalFrames, repeatedFrames;
        private Vector2 anchor; // where the neck attaches to the body
        private Random rand;
        private readonly int maxDistance = 50; // max distance head can be from anchor TODO might need adjusting
        private readonly int moveDelay; // delay to make slower bc floats mess up drawings
        private int moveCounter;
        private Vector2 destination;

        public GleeokHead(Texture2D texture, Vector2 anchor)
        {
            Texture = texture;
            currFrame = 0;
            totalFrames = 2;
            repeatedFrames = 4;
            moveDelay = 5; // slow
            moveCounter = 0;
            defaultSource = new Rectangle(280, 11, 8, 16);
            isAngry = false;
            angrySources = new List<Rectangle>
            {
                new Rectangle(289, 11, 16, 16),
                new Rectangle(306, 11, 16, 16)
            };
            this.anchor = anchor;
            rand = new Random();
            // randomly generates head location
            Location = randomLocation();
            destination = randomLocation();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (isAngry)
                spriteBatch.Draw(Texture, Location, angrySources[currFrame / repeatedFrames], Color.White);
            else 
                spriteBatch.Draw(Texture, Location, defaultSource, Color.White);
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
                    destination = randomLocation();
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
        }

        // generates random location
        public Vector2 randomLocation()
        {
            // TODO depends on where link is?
            Vector2 dir = new Vector2(rand.Next(-100, 100), rand.Next(0, 100)); // location can only below anchor
            dir.Normalize();
            return anchor + rand.Next(0, maxDistance) * dir;
        }
    }
}
