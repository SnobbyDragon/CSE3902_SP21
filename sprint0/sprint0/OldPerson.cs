using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace sprint0
{
    public class OldPerson : ISprite
    {
        public Vector2 Location { get; set;}
        public Texture2D Texture { get; set; }
        public String Type { get; set; }
        private readonly int xOffset = 1, yOffset = 11, size = 16;
        private Dictionary<String, Rectangle> typeRectMap;

        public OldPerson(Texture2D texture, String type)
        {
            Texture = texture;
            Type = type;
            typeRectMap = new Dictionary<String, Rectangle>
            {
                { "man 1", new Rectangle(xOffset, yOffset, size, size) },
                { "man 2", new Rectangle(xOffset + size + 1, yOffset, size, size) },
                { "woman", new Rectangle(xOffset + 2 * (size + 1), yOffset, size, size) }
            };
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Location, typeRectMap[Type], Color.White);
        }

        public void Update()
        {
            // does nothing for now
        }
    }
}
