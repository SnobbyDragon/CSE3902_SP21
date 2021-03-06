﻿using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

//Author: Hannah Johnson

namespace sprint0
{
    public class Darkness : ISprite
    {
        public Rectangle Location { get; set; }
        public Texture2D Texture { get; set; }
        private Rectangle source;

        public Darkness(Texture2D texture, Vector2 location)
        {
            Location = new Rectangle((int)location.X, (int)location.Y, Game1.Width, Game1.MapHeight);
            Texture = texture;
            source = new Rectangle(976, 888, 192, 100);
        }

        public void Draw(SpriteBatch spriteBatch)
            => spriteBatch.Draw(Texture, new Rectangle((int)Location.X, (int)Location.Y, (int)((Game1.Width - 64) * Game1.Scale), (int)((Game1.MapHeight - 64) * Game1.Scale)), source, Color.White);
        public void Update() { }
    }
}
