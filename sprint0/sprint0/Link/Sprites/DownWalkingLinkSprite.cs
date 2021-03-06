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
        
        private List<Rectangle> frames;
        private int currentFrame;
        private int repeatFrames;
        private int totalFrames;
        private readonly int size = 16;

        public DownWalkingLinkSprite(Texture2D texture, Vector2 location)
        {
            this.texture = texture;
            Location = new Rectangle((int)location.X, (int)location.Y, size, size);
            currentFrame = 0;
            repeatFrames = 8;
            totalFrames = 2 * repeatFrames;
            frames = new List<Rectangle> { new Rectangle(1, 11, size, size), new Rectangle(18, 11, size, size) };
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