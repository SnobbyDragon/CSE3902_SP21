﻿using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

/*
 * Last updated: 3/5/21 by li.10011
 */
namespace sprint0
{
    class RightUseItemSprite : ISprite
    {

        public Texture2D Texture { get => texture; set => texture = value; }
        public Rectangle Location { get; set; }
        private Texture2D texture;

        private readonly int xOffset = 124, yOffset = 11;
        private readonly int size = 16;

        public RightUseItemSprite(Texture2D texture, Vector2 location)
        {
            Location = new Rectangle((int)location.X, (int)location.Y, (int)(size * Game1.Scale), (int)(size * Game1.Scale));
            this.texture = texture;
        }

        public void Draw(SpriteBatch spriteBatch)
            => spriteBatch.Draw(Texture, Location, new Rectangle(xOffset, yOffset, size, size), Color.White);
        public void Update() { }
    }
}