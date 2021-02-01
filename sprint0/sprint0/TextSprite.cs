using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace sprint0
{
    class TextSprite : ISprite
    {
        public Vector2 Location { get; set; }
        private SpriteFont font;
        private String text;

        public TextSprite(SpriteFont font, String text)
        {
            this.font = font;
            this.text = text;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(font, text, Location, Color.Black);
        }

        public void Update() { }
    }
}
