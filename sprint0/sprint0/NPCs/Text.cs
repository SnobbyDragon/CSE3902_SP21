using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace sprint0
{
    public class Text
    {
        public Vector2 Location { get; set; }
        public SpriteFont Font { get; set; }
        private Color color;
        private readonly string message;
        private readonly string path = "Font";
        public Text(Game1 game, string message, Vector2 Location, Color color)
        {
            this.color = color;
            this.message = message;
            this.Location = Location;
            Font = game.Content.Load<SpriteFont>(path);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(Font, message, Location, color);
        }

        public void Update()
        {

        }
    }
}
