using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace sprint0
{
    class LeftWalkingLinkSprite : ISprite
    {
        public Texture2D Texture { get => texture; set => texture = value; }
        public Rectangle Location { get; set; }
        private Texture2D texture;
        private readonly List<Rectangle> frames;
        private int currentFrame;
        private readonly int repeatFrames;
        private readonly int totalFrames;
        private readonly int size = 16, xOffset = 35, yOffset = 11;

        public LeftWalkingLinkSprite(Texture2D texture, Vector2 location)
        {
            this.texture = texture;
            Location = new Rectangle((int)location.X, (int)location.Y, (int)(size * Game1.Scale), (int)(size * Game1.Scale));
            currentFrame = 0;
            repeatFrames = 8;
            totalFrames = 2 * repeatFrames;
            frames = new List<Rectangle> { new Rectangle(xOffset, yOffset, size, size), new Rectangle(xOffset + size + 1, yOffset, size, size) };
        }

        public void Draw(SpriteBatch spriteBatch)
            => spriteBatch.Draw(texture, Location, frames[currentFrame / repeatFrames], Color.White, 0, new Vector2(0, 0), SpriteEffects.FlipHorizontally, 0);

        public void Update()
        {
            currentFrame++;
            currentFrame %= totalFrames;
        }
    }
}
