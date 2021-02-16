using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace sprint0
{
    public class Ganon : ISprite
    {
        public Vector2 Location { get; set; }
        public Texture2D Texture { get; set; }
        private readonly int xOffset = 40, yOffset = 154, size = 32;
        private List<Rectangle> sources;
        private int currFrame, counter; // counts the time
        private readonly int totalFrames, invisibleTime = 200, visibleTime = 100, teleportTime = 50; //TODO currently arbitrary times
        private bool isVisible;
        private readonly Random rand;

        public Ganon(Texture2D texture, Vector2 location)
        {
            Location = location;
            Texture = texture;
            currFrame = 0;
            totalFrames = 5;
            sources = new List<Rectangle>();
            for (int frame = 0; frame < totalFrames; frame++)
            {
                sources.Add(new Rectangle(xOffset + frame * (size + 1), yOffset, size, size));
            };
            rand = new Random();

            isVisible = true;
            counter = 0;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (isVisible)
                spriteBatch.Draw(Texture, Location, sources[currFrame], Color.White);
        }

        public void Update()
        {
            // TODO change his color to red when vulnerable (hit by link many times)
            if (isVisible)
            {
                if (counter == visibleTime)
                {
                    // turn invisible
                    isVisible = false;
                    counter = 0;
                }
            } else
            {
                if (counter == invisibleTime)
                {
                    // turn visible
                    isVisible = true;
                    counter = 0;
                    currFrame = (currFrame + 1) % totalFrames; //TODO frame depends on location?
                } else if (counter == teleportTime)
                {
                    // teleport somewhere
                    teleport();
                }
            }
            counter++;
        }

        public void teleport()
        {
            // currently picks a random place to appear TODO change location bounds
            // TODO depends on where link is?
            Location = new Vector2(rand.Next(0, 100), rand.Next(0, 100));
        }
    }
}
