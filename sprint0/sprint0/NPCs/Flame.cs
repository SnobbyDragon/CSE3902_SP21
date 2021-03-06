using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

//Author: Hannah Johnson and co

namespace sprint0
{
    public class Flame : ISprite
    {

        public Rectangle Location { get; set; }
        public Texture2D Texture { get; set; }
        private Rectangle source;
        SpriteEffects s = SpriteEffects.FlipHorizontally;
        private int currentFrame;
        private int repeatedFrames;
        private int totalFrames;
        private readonly int width, height;

        public Flame(Texture2D texture, Vector2 location)
        {
            width = height = 16;
            Location = new Rectangle((int)location.X, (int)location.Y, (int)(width * Game1.Scale), (int)(height * Game1.Scale));
            Texture = texture;
            source = new Rectangle(52, 11, width, height);
            currentFrame = 0;
            repeatedFrames = 8;
            totalFrames = 2;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Location, source, Color.White, 0, new Vector2(0, 0), s, 0);
        }

        public void Update()
        {
            if (currentFrame / repeatedFrames == 0)
            {
                s = SpriteEffects.FlipHorizontally;
            }
            else
            {
                s = SpriteEffects.None;
            }
            currentFrame = (currentFrame + 1) % (totalFrames * repeatedFrames);
        }
    }
}
