using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

//Author: Hannah Johnson

namespace sprint0
{
    public class Fairy : IItem
    {
        public int PickedUpDuration { get; set; }
        public Rectangle Location { get; set; }
        public int Damage { get => int.MaxValue; }
        public Texture2D Texture { get; set; }
        private readonly List<Rectangle> sources;
        private readonly int totalFrames;
        private int currentFrame;
        private readonly int repeatedFrames;
        //private int moveCounter;

        private Vector2 destination;
        private readonly Random rand;

        public Fairy(Texture2D texture, Vector2 location)
        {
            Texture = texture;
			PickedUpDuration = -2; // not picked up, no special animation
            totalFrames = 2;
            currentFrame = 0; repeatedFrames = 10; //moveCounter = 0;
            sources = new List<Rectangle>();
            int xPos = 40, yPos = 0, width = 7, height = 16;
            Location = new Rectangle((int)location.X, (int)location.Y, (int)(width * Game1.Scale), (int)(height * Game1.Scale));
            sources.Add(new Rectangle(xPos, yPos, width, height));
            sources.Add(new Rectangle(xPos + width + 1, yPos, width, height));

            rand = new Random();
            GenerateDest();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Location, sources[currentFrame / repeatedFrames], Color.White);
        }

        public void Update()
        {
            currentFrame = (currentFrame + 1) % (totalFrames * repeatedFrames);

            Vector2 dist = destination - Location.Location.ToVector2();
            if (dist.Length() < 5)
            {
                // reached destination, generate new destination;
                GenerateDest();
            }
            else
            {
                // has not reached destination, move towards it
                dist.Normalize();
                dist = dist.ApproxDirection().ToVector2();
                Location = new Rectangle((int)(Location.X + dist.X), (int)(Location.Y + dist.Y), Location.Width, Location.Height);
            }

        }

        // generates a new destination
        private void GenerateDest()
        {
            int xlowerBound = Location.X - 200;
            int ylowerBound = Location.Y - 200;
            int xupperBound = Location.X + 200;
            int yupperBound = Location.X + 200;

            //if destination is off screen resets to screen bounds
            if (xlowerBound < Game1.BorderThickness * Game1.Scale)
            {
                xlowerBound = (int)(Game1.BorderThickness * Game1.Scale);
            }
            if (xupperBound > (Game1.Width - Game1.BorderThickness) * Game1.Scale)
            {
                xupperBound = (int)((Game1.Width - Game1.BorderThickness) * Game1.Scale);
            }
            if (ylowerBound < (Game1.HUDHeight + Game1.BorderThickness) * Game1.Scale)
            {
                ylowerBound = (int)((Game1.HUDHeight + Game1.BorderThickness) * Game1.Scale);
            }
            if (yupperBound > (Game1.HUDHeight + Game1.MapHeight - Game1.BorderThickness) * Game1.Scale)
            {
                yupperBound = (int)((Game1.HUDHeight + Game1.MapHeight - Game1.BorderThickness) * Game1.Scale);
            }
            // picks a random destination 

            destination = new Vector2(
                rand.Next(xlowerBound, xupperBound),
                rand.Next(ylowerBound, yupperBound)
                );
        }

        public void RegisterHit()
        {
            //no-op required
        }
    }
}
