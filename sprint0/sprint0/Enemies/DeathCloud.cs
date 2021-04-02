using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace sprint0
{
    public class DeathCloud : ISprite
    {
        public Rectangle Location { get; set; }
        public Texture2D Texture { get; set; }
        private readonly int xOffset = 138, yOffset = 185, size = 16, totalFrames = 3, repeatedFrames = 6;
        private readonly List<Rectangle> sources;
        private int frame;

        public DeathCloud(Texture2D texture, Vector2 location)
        {
            Texture = texture;
            Location = new Rectangle((int)location.X, (int)location.Y, (int)(size * Game1.Scale), (int)(size * Game1.Scale));
            sources = SpritesheetHelper.GetFramesH(xOffset, yOffset, size, size, totalFrames);
            frame = 0;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (frame < totalFrames * repeatedFrames)
                spriteBatch.Draw(Texture, Location, sources[frame / repeatedFrames], Color.White);
        }

        public void Update()
        {
            if (frame < totalFrames * repeatedFrames)
                frame++;
        }
    }
}