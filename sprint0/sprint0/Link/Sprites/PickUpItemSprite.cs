using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace sprint0
{
    class PickUpItemSprite : ISprite
    {
        public Texture2D Texture { get => texture; set => texture = value; }
        public Rectangle Location { get; set; }
        private Texture2D texture;

        private readonly List<Rectangle> sources;
        private readonly int xOffset = 213, yOffset = 11, size = 16;

        private int currentFrame;
        private readonly int repeatedFrames, totalFrames;

        public PickUpItemSprite(Texture2D texture, Vector2 location)
        {
            Location = new Rectangle((int)location.X, (int)location.Y, (int)(size * Game1.Scale), (int)(size * Game1.Scale));
            this.texture = texture;
            currentFrame = 0;
            repeatedFrames = 20;
            totalFrames = 2;
            sources = SpritesheetHelper.GetFramesH(xOffset, yOffset, size, size, totalFrames);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, Location, sources[currentFrame / repeatedFrames], Color.White);
        }

        public void Update()
        {
            currentFrame = (currentFrame + 1) % (totalFrames * repeatedFrames);
        }
    }
}