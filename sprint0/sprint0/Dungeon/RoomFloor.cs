using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace sprint0
{
    public class RoomFloor : ISprite
    {

        public Vector2 Location { get; set; }
        public Texture2D Texture { get; set; }
        private Rectangle source;
        private readonly int xSize = 192, ySize = 112, gap = 4, xOffset = 1, yOffset = 192;

        public RoomFloor(Texture2D texture, Vector2 location, string type)
        {
            Location = location;
            Texture = texture;
            source = type switch
            {
                "plain" => new Rectangle(xOffset, yOffset, xSize, ySize),
                "1" => new Rectangle(xOffset + xSize + gap, yOffset, xSize, ySize),
                "2" => new Rectangle(xOffset, yOffset + ySize + gap, xSize, ySize),
                _ => throw new ArgumentException("Invalid direction! Failed to make room floor.")
            };
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, new Rectangle((int)Location.X, (int)Location.Y, (int)(xSize * Game1.Scale), (int)(ySize * Game1.Scale)), source, Color.White);

        }

        public void Update()
        {
            //N/A
        }
    }
}
