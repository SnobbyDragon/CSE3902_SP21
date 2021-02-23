using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace sprint0
{
    class UpWalkingLinkSprite : ISprite
    {
        public Texture2D Texture { get => texture; set => texture = value; }
        public Vector2 Location { get => location; set => location = value; }

        private Texture2D texture;
        private Vector2 location;
        private readonly List<Rectangle> frames;
        private int currentFrame;
        private readonly int repeatFrames;
        private readonly int totalFrames;

        public UpWalkingLinkSprite(Texture2D texture, Vector2 location)
        {
            this.texture = texture;
            this.location = location;
            currentFrame = 0;
            repeatFrames = 8;
            totalFrames = 2 * repeatFrames;
            frames = new List<Rectangle> { new Rectangle(69, 11, 16, 16), new Rectangle(86, 11, 16, 16) };
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, location, frames[currentFrame / repeatFrames], Color.White);
        }

        public void Update() {
            currentFrame++;
            currentFrame %= totalFrames;
        }
    }
}
