using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace sprint0
{
    public class Merchant : ISprite
    {
        public Vector2 Location { get; set; }
        public Texture2D Texture { get; set; }
        public String Type { get; set; }
        private readonly int xOffset = 109, yOffset = 11, size = 16;
        private Dictionary<String, Rectangle> typeRectMap;

        public Merchant(Texture2D texture, Vector2 location, String type)
        {
            Location = location;
            Texture = texture;
            this.Type = type;
            typeRectMap = new Dictionary<String, Rectangle>
            {
                { "green", new Rectangle(xOffset, yOffset, size, size) },
                { "white", new Rectangle(xOffset + size + 1, yOffset, size, size) },
                { "red", new Rectangle(xOffset + 2 * (size + 1), yOffset, size, size) }
            };
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Location, typeRectMap[Type], Color.White);
        }

        public void Update()
        {
            // does nothing for now; probably buy/sell stuff later???
        }
    }
}
