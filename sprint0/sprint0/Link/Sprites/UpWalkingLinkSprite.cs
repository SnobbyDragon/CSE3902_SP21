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
        public Rectangle Location { get; set; }

        private Texture2D texture;

        private readonly List<Rectangle> frames;
        private int currentFrame;
        private readonly int repeatedFrames;
        private readonly int totalFrames;
        private readonly int width, height;

        public UpWalkingLinkSprite(Texture2D texture, Vector2 location)
        {
            width = height = 16;
            this.texture = texture;
            Location = new Rectangle((int)location.X, (int)location.Y, (int)(width * Game1.Scale), (int)(height * Game1.Scale));
            currentFrame = 0;
            repeatedFrames = 8;
            totalFrames = 2;
            frames = SpritesheetHelper.GetFramesH(69, 11, width, height, totalFrames);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, Location, frames[currentFrame / repeatedFrames], Color.White);
        }

        public void Update()
        {
            currentFrame = (currentFrame + 1) % (totalFrames * repeatedFrames);
        }
    }
}
