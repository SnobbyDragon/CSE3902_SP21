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
        private readonly int repeatFrames;
        private readonly int totalFrames;
        private readonly int size = 16;

        public RightWalkingLinkSprite(Texture2D texture, Vector2 location)
        {
            this.texture = texture;
            Location = new Rectangle((int)location.X, (int)location.Y, size, size);
            currentFrame = 0;
            repeatFrames = 8;
            totalFrames = 2 * repeatFrames;
            frames = new List<Rectangle> { new Rectangle(35, 11, size, size), new Rectangle(52, 11, size, size) };
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, Location, frames[currentFrame / repeatFrames], Color.White);
        }

        public void Update()
        {
            currentFrame++;
            currentFrame %= totalFrames;
        }
    }
}