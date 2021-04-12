using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace sprint0
{
    class DownWalkingLinkSprite : ISprite
    {
        public Texture2D Texture { get => texture; set => texture = value; }
        public Rectangle Location { get; set; }

        private Texture2D texture;

        private readonly List<Rectangle> frames;
        private int currentFrame;
        private readonly int repeatFrames, totalFrames, numFrames = 2, xOffset = 1, yOffset = 11;
        private readonly int size = 16;

        public DownWalkingLinkSprite(Texture2D texture, Vector2 location)
        {
            this.texture = texture;
            Location = new Rectangle((int)location.X, (int)location.Y, (int)(size * Game1.Scale), (int)(size * Game1.Scale));
            currentFrame = 0;
            repeatFrames = 8;
            totalFrames = 2 * repeatFrames;
            frames = SpritesheetHelper.GetFramesH(xOffset, yOffset, size, size, numFrames);
        }

        public void Draw(SpriteBatch spriteBatch)
            => spriteBatch.Draw(texture, Location, frames[currentFrame / repeatFrames], Color.White);

        public void Update()
        {
            currentFrame++;
            currentFrame %= totalFrames;
        }
    }
}