using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace sprint0
{
    class RightWalkingLinkSprite : ISprite
    {
        public Texture2D Texture { get => texture; set => texture = value; }
        public Rectangle Location { get; set; }

        private Texture2D texture;

        private readonly List<Rectangle> frames;
        private int currentFrame;
        private readonly int repeatedFrames;
        private readonly int totalFrames;
        private readonly int size = 16;

        public RightWalkingLinkSprite(Texture2D texture, Vector2 location)
        {
            this.texture = texture;
            Location = new Rectangle((int)location.X, (int)location.Y, (int)(size * Game1.Scale), (int)(size * Game1.Scale));
            currentFrame = 0;
            repeatedFrames = 8;
            totalFrames = 2;
            frames = SpritesheetHelper.GetFramesH(35, 11, size, size, totalFrames);
        }

        public void Draw(SpriteBatch spriteBatch)
            => spriteBatch.Draw(texture, Location, frames[currentFrame / repeatedFrames], Color.White);
        public void Update()
            => currentFrame = (currentFrame + 1) % (totalFrames * repeatedFrames);
    }
}