using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace sprint0
{
    public class Aquamentus : ISprite
    {
        public Vector2 Location { get; set; }
        public Texture2D Texture { get; set; }
        private readonly int xOffset = 1, yOffset = 11, width = 24, height = 32;
        private List<Rectangle> sources;
        private int currFrame;
        private readonly int totalFrames, repeatedFrames;

        public Aquamentus(Texture2D texture, Vector2 location)
        {
            Location = location;
            Texture = texture;
            currFrame = 0;
            totalFrames = 4;
            repeatedFrames = 8;
            sources = new List<Rectangle>();
            for (int frame = 0; frame < totalFrames; frame++)
            {
                sources.Add(new Rectangle(xOffset + frame * (width + 1), yOffset, width, height));
            };
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Location, sources[currFrame / repeatedFrames], Color.White);
        }

        public void Update()
        {
            // animates all the time for now; TODO make it walk back and forth left and right
            currFrame = (currFrame + 1) % (totalFrames * repeatedFrames);
        }
    }
}
