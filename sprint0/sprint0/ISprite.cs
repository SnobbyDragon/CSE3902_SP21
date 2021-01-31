using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace sprint0
{
    public interface ISprite
    {
        public Vector2 Location { get; set; }
        public void Update();
        public void Draw(SpriteBatch spriteBatch);
    }
}
