using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace sprint0
{
    public class AquamentusFireball : ISprite
    {
        public Vector2 Location { get; set; }
        public Texture2D Texture { get; set; }
        private readonly int xOffset = 101, yOffset = 14, width = 8, height = 10;
        private List<Rectangle> sources;
        private int currFrame;
        private readonly int totalFrames, repeatedFrames;

        public AquamentusFireball(Texture2D texture)
        {
            Texture = texture;
            currFrame = 0;
            totalFrames = 4;
            repeatedFrames = 2;
            sources = new List<Rectangle>();
            for (int frame = 0; frame < totalFrames; frame++)
            {
                sources.Add(new Rectangle(xOffset + frame*(width + 1), yOffset, width, height));
            };
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Location, sources[currFrame / repeatedFrames], Color.White);
        }

        public void Update()
        {
            // animates all the time for now
            currFrame = (currFrame + 1) % (totalFrames * repeatedFrames);
        }
    }
}
