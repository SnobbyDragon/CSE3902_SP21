﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace sprint0
{
    class LeftIdleLinkSprite : ISprite
    {
        public Texture2D Texture { get => texture; set => texture = value; }
        public Rectangle Location { get; set; }

        private Texture2D texture;
        private Rectangle sourceRectangle;

        private readonly int size = 16;

        public LeftIdleLinkSprite(Texture2D texture, Vector2 location)
        {
            this.texture = texture;
            Location = new Rectangle((int)location.X, (int)location.Y, size, size);
            sourceRectangle = new Rectangle(35, 11, size, size);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, Location, sourceRectangle, Color.White, 0, new Vector2(0,0), SpriteEffects.FlipHorizontally, 0);
        }

        public void Update() { }
    }
}
