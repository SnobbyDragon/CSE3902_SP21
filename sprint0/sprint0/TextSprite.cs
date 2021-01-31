using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace sprint0
{
    class TextSprite : ISprite
    {
        private SpriteFont font;
        private String text;
        public TextSprite(SpriteFont font, String text)
        {
            this.font = font;
            this.text = text;
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            spriteBatch.DrawString(font, text, location, Color.Black);
        }

        public void Update() { }
    }
}
