using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace sprint0
{
    public class GanonAshes : IEffect
    {
        public Rectangle Location { get; set; }
        public Texture2D Texture { get; set; }
        private readonly int xOffset = 312, yOffset = 171, size = 16, totalFrames = 2, repeatedFrames = 16;
        private readonly List<Rectangle> sources;
        private int frame;

        public GanonAshes(Texture2D texture, Vector2 location)
        {
            Texture = texture;
            Location = new Rectangle((int)location.X, (int)location.Y, (int)(size * Game1.Scale), (int)(size * Game1.Scale));
            sources = SpritesheetHelper.GetFramesV(xOffset, yOffset, size, size, totalFrames);
            frame = 0;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Location, sources[frame / repeatedFrames], Color.White);
        }

        public void Update()
        {
            frame = (frame + 1) % (totalFrames * repeatedFrames);
        }

        public bool IsAlive() => true;
    }
}
