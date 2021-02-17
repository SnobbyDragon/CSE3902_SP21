using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

//Author: Hannah Johnson and co

namespace sprint0
{
    public class Flame : ISprite
    {

        public Vector2 Location { get; set; }
        public Texture2D Texture { get; set; }
        private Rectangle source;
        SpriteEffects s = SpriteEffects.FlipHorizontally;
        private int currentFrame;
        private int repeatedFrames;
        private int totalFrames;

        public Flame(Texture2D texture, Vector2 location)
        {
            Location = location;
            Texture = texture;
            source = new Rectangle(52, 11, 16, 16);
            currentFrame = 0;
            repeatedFrames = 8;
            totalFrames = 2;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Location, source, Color.White, 0, new Vector2(0, 0), new Vector2(1, 1), s, 0);
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
