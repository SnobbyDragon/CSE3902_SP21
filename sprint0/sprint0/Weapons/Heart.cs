using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace sprint0
{
    public class Heart : ISprite
    {
        public Rectangle Location { get; set; }
        public Texture2D Texture { get; set; }
        public string Type { get; set; }
        private readonly int width = 7, height = 8;
        private readonly Dictionary<string, Rectangle> typeRectMap;

        public Heart(Texture2D texture, Vector2 location, string type)
        {
            Location = new Rectangle((int)location.X, (int)location.Y, (int)(width * Game1.Scale), (int)(height * Game1.Scale));
            Texture = texture;
            Type = type;
            typeRectMap = new Dictionary<string, Rectangle>
            {
                { "red", new Rectangle(0, 0, width, height) },
                { "half", new Rectangle(width + 1, 0, width, height) },
                { "pink", new Rectangle(2 * (width + 1), 0, width, height) },
                { "blue", new Rectangle(0, height, width, height) }
            };
        }

        public void Draw(SpriteBatch spriteBatch)
            => spriteBatch.Draw(Texture, Location, typeRectMap[Type], Color.White);
        public void Update() { }
    }
}
