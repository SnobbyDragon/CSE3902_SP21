using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace sprint0
{
    public class OldPerson : IBlock
    {
        public Rectangle Location { get; set; }
        public Texture2D Texture { get; set; }
        public string Type { get; set; }
        private readonly int xOffset = 1, yOffset = 11, width, height;
        private Dictionary<string, Rectangle> typeRectMap;

        public OldPerson(Texture2D texture, Vector2 location, String type)
        {
            width = height = 16;
            Location = new Rectangle((int)location.X, (int)location.Y, (int)(width * Game1.Scale), (int)(height * Game1.Scale));
            Texture = texture;
            Type = type;
            typeRectMap = new Dictionary<String, Rectangle> //TODO use GetFrames method when we make that static public
            {
                { "man 1", new Rectangle(xOffset, yOffset, width, height) },
                { "man 2", new Rectangle(xOffset + width + 1, yOffset, width, height) },
                { "woman", new Rectangle(xOffset + 2 * (width + 1), yOffset, width, height) }
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

        public bool IsWalkable() => false;
        public bool IsMovable() => false;
    }
}
