using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace sprint0
{
    public class GanonDeathCloud : IEffect
    {
        public Rectangle Location { get; set; }
        public Texture2D Texture { get; set; }
        private readonly int xOffset = 329, yOffset = 154, size = 16, totalFrames = 2, repeatedFrames = 20;
        private readonly List<Rectangle> sources;
        private int frame;

        public GanonDeathCloud(Texture2D texture, Vector2 location)
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

        public bool IsAlive() => true;
    }
}