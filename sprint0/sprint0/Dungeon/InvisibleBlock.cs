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
        public const int DefaultSize = 16;

        public InvisibleBlock(Vector2 location, int width, int height)
        {
            Location = new Rectangle((int)location.X, (int)location.Y, (int)(width * Game1.Scale), (int)(height * Game1.Scale));
        }

        public void Draw(SpriteBatch spriteBatch) { }

        public void Update() { }

        public bool IsWalkable() => false;

        public bool IsMovable() => false;

        public void SetIsMovable()
        {
            throw new NotImplementedException();
        }
    }
}
