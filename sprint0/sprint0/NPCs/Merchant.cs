using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace sprint0
{
    public class Merchant : ISprite
    {
        public Rectangle Location { get; set; }
        public Texture2D Texture { get; set; }
        public String Type { get; set; }
        private readonly int xOffset = 109, yOffset = 11, width, height;
        private Dictionary<String, Rectangle> typeRectMap;

        public Merchant(Texture2D texture, Vector2 location, String type)
        {
            width = height = 16;
            Location = new Rectangle((int)location.X, (int)location.Y, (int)(width * Game1.Scale), (int)(height * Game1.Scale));
            Texture = texture;
            this.Type = type;
            typeRectMap = new Dictionary<String, Rectangle> //TODO use GetFrames method when we make that static public
            {
                { "green", new Rectangle(xOffset, yOffset, width, height) },
                { "white", new Rectangle(xOffset + width + 1, yOffset, width, height) },
                { "red", new Rectangle(xOffset + 2 * (width + 1), yOffset, width, height) }
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
