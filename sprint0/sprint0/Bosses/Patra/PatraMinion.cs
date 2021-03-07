using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

// Author: Angela Li
namespace sprint0
{
    public class PatraMinion : IEnemy
    {
        public Rectangle Location { get; set; }
        public Texture2D Texture { get; set; }
        private readonly int xOffset = 18, yOffset = 158, width = 8, height = 8;
        private List<Rectangle> sources;
        private int currFrame;
        private readonly int totalFrames, repeatedFrames;
        private IEnemy center; // blue patra
        private Vector2 offset; // offset so distances can be calculated to be center of sprites
        private readonly int minDistance = 30, maxDistance = 80; // min and max distances from center
        private int distance, angle; // curr distance; angle from center (0 is right of center)
        private int expansionTime, expansionCounter; // 0 = waiting, 1 - 6 = moving; odd = expanding to max dist, even = contract to min dist
        private readonly int expansionDelay = 200; // time between expansions

        public PatraMinion(Texture2D texture, IEnemy center, int angle)
        {
            Texture = texture;
            currFrame = 0;
            totalFrames = 2;
            repeatedFrames = 3;
            sources = new List<Rectangle>();
            for (int frame = 0; frame < totalFrames; frame++)
            {
                sources.Add(new Rectangle(xOffset + frame * (width + 1), yOffset, width, height));
            };
            this.center = center;
            this.angle = angle;
            distance = minDistance; // starts close
            offset = new Vector2(8, 5.5f) - new Vector2(width / 2, height / 2); // offset from center - offset from minion
            expansionCounter = expansionTime = 0;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Location, sources[currFrame / repeatedFrames], Color.White);
        }

        private float DegreesToRadians(int degrees)
        {
            return (float)(Math.PI * degrees / 180.0);
        }

        public void Update()
        {
            currFrame = (currFrame + 1) % (totalFrames * repeatedFrames); // animate flying
            Vector2 loc = center.Location.Location.ToVector2() + offset + new Vector2((float)(distance * Math.Cos(DegreesToRadians(angle))), (float)(distance * Math.Sin(DegreesToRadians(angle))));
            Location = new Rectangle((int)loc.X, (int)loc.Y, (int)(width * Game1.Scale), (int)(height * Game1.Scale));

            // spins fast, no need for delay
            angle = (angle - 3) % 360; // spin counterclockwise

            CountExpansion();

            if (expansionCounter > 0)
            {
                // not waiting
                if (expansionCounter > 6)
                {
                    // expanded 3 times, return to waiting state
                    expansionCounter = 0;
                }
                else
                {
                    // expanding / contracting
                    if (expansionCounter % 2 == 0)
                    {
                        Contract();
                    }
                    else
                    {
                        Expand();
                    }
                }
            }
        }

        // keeps timings for expansions
        private void CountExpansion()
        {
            if (expansionTime == expansionDelay)
            {
                expansionTime = 0; // time to expand
                expansionCounter = 1; // on first expansion
            }
            else if (expansionCounter == 0)
            {
                expansionTime++; // if waiting, then increment time
            }
        }

        // contracting movement
        private void Contract()
        {
            if (distance == minDistance)
            {
                // done contracting
                expansionCounter++;
            }
            else
            {
                // not done, decrease distance
                distance--;
            }
        }

        // expanding movement
        private void Expand()
        {
            if (distance == maxDistance)
            {
                // done expanding
                expansionCounter++;
            }
            else
            {
                // not done, increase distance
                distance++;
            }
        }
    }
}
