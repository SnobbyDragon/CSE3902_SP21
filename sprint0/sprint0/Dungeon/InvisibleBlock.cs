using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

//Author: Jesse He

namespace sprint0
{
    public class InvisibleBlock : IBlock
    {
        public Rectangle Location { get; set; }
        private readonly int width, height;

        public InvisibleBlock(Vector2 location)
        {
            width = height = 16;
            Location = new Rectangle((int)location.X, (int)location.Y, (int)(width * Game1.Scale), (int)(height * Game1.Scale));
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            // No-op -- is invisible
        }

        public void Update()
        {
            // No-op -- does not move
        }

        public bool IsWalkable()
        {
            return false;
        }

        public bool IsMovable()
        {
            return false;
        }

        public void SetIsMovable()
        {
            throw new NotImplementedException();
        }
    }
}
