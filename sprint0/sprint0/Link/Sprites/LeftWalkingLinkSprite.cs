using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace sprint0
{
    class LeftWalkingLinkSprite : ISprite
    {
        public Texture2D Texture { get => texture; set => texture = value; }
        public Vector2 Location { get => location; set => location = value; }

        private Texture2D texture;
        private Vector2 location;
        private List<Rectangle> frames;
        private int currentFrame;
        private int repeatFrames;
        private int totalFrames;

        public LeftWalkingLinkSprite(Texture2D texture, Vector2 location)
        {
            this.texture = texture;
            this.location = location;
            currentFrame = 0;
            repeatFrames = 8;
            totalFrames = 2 * repeatFrames;
            frames = new List<Rectangle> { new Rectangle(35, 11, 16, 16), new Rectangle(52, 11, 16, 16) };
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Rectangle destination = new Rectangle((int) location.X, (int) location.Y, 16, 16);
            spriteBatch.Draw(texture, destination, frames[currentFrame / repeatFrames], Color.White, 0, new Vector2(0,0), SpriteEffects.FlipHorizontally, 0);
        }

        public void Update() {
            currentFrame++;
            currentFrame %= totalFrames;
        }
    }
}
