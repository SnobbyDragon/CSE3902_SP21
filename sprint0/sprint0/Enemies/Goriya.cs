using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace sprint0
{
    public class Goriya : ISprite
    {
        public Vector2 Location { get; set; }
        public Texture2D Texture { get; set; }
        private readonly int xOffset = 222, yOffset = 11, size = 15;
        private List<Rectangle> sources;
        private int currFrame;
        private readonly int totalFrames, repeatedFrames;

        public Goriya(Texture2D texture, Vector2 location)
        {
            Location = location;
            Texture = texture;
            sources = new List<Rectangle>
            {
                new Rectangle(xOffset, yOffset, size, size),
                new Rectangle(xOffset + size + 1, yOffset, size, size),
                new Rectangle(xOffset + size*2 + 2, yOffset, size, size),
                new Rectangle(xOffset + size*3 + 3, yOffset, size, size)
            };
            currFrame = 0;
            totalFrames = 4;
            repeatedFrames = 8;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Location, sources[currFrame/repeatedFrames], Color.White);
        }

        public void Update()
        {
            // animates all the time for now
            currFrame = (currFrame + 1) % (totalFrames*repeatedFrames);
        }
    }
}