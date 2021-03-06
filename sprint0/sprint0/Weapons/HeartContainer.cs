﻿using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace sprint0
{
    public class HeartContainer : ISprite
    {
        public Rectangle Location { get; set; }
        public Texture2D Texture { get; set; }
        private Rectangle source;
        private readonly int width, height;

        public HeartContainer(Texture2D texture, Vector2 location)
        {
            width = height = 13;
            Location = new Rectangle((int)location.X, (int)location.Y, width, height);
            Texture = texture;
            source = new Rectangle(25, 0, width, height);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Location, source, Color.White);
        }

        public void Update()
        {
            // does nothing for now
        }
    }
}
