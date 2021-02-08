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
        private int currFrame;
        private readonly int totalFrames, repeatedFrames;

        public Ganon(Texture2D texture, Vector2 location)
        {
            Location = location;
            Texture = texture;
            currFrame = 0;
            totalFrames = 5;
            repeatedFrames = 8;
            sources = new List<Rectangle>();
            for (int frame = 0; frame < totalFrames; frame++)
            {
                sources.Add(new Rectangle(xOffset + frame * (size + 1), yOffset, size, size));
            };
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Location, sources[currFrame / repeatedFrames], Color.White);
        }

        public void Update()
        {
            // animates all the time for now; TODO change his color to red when vulnerable (hit by link many times)
            currFrame = (currFrame + 1) % (totalFrames * repeatedFrames);
        }
    }
}
