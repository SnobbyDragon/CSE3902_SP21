using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace sprint0
{
    public class RoomFloor : ISprite
    {

        public Rectangle Location { get; set; }
        public Texture2D Texture { get; set; }
        private Rectangle source;
        private readonly int width = 192, height = 112, gap = 4, xOffset = 1, yOffset = 192;

        public RoomFloor(Texture2D texture, Vector2 location, string type)
        {
            Location = new Rectangle((int)location.X, (int)location.Y, width, height);
            Texture = texture;
            source = type switch
            {
                "plain" => new Rectangle(xOffset, yOffset, width, height),
                "1" => new Rectangle(xOffset + width + gap, yOffset, width, height),
                "2" => new Rectangle(xOffset, yOffset + height + gap, width, height),
                _ => throw new ArgumentException("Invalid direction! Failed to make room floor.")
            };
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, new Rectangle((int)Location.X, (int)Location.Y, (int)(width * Game1.Scale), (int)(height * Game1.Scale)), source, Color.White);

        }

        public void Update()
        {
            //N/A
        }

        public Collision GetCollision(ISprite other)
        {
            return Collision.None;
        }
    }
}
