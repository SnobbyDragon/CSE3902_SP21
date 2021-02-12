using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace sprint0
{
    public class Statue : ISprite
    {

        public Vector2 Location { get; set; }
        public Texture2D Texture { get; set; }
        private Rectangle source;
        private readonly int xOffset = 1018, yOffset = 11, size = 16;

        public Statue(Texture2D texture, Vector2 location, string dir)
        {
            Location = location;
            Texture = texture;
            if (dir.Equals("right"))
            { // creates a right facing statue
                source = new Rectangle(xOffset, yOffset, size, size);
            }
            else if (dir.Equals("left"))
            { // creates a left facing statue
                source = new Rectangle(xOffset + size + 1, yOffset, size, size);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Location, source, Color.White);
        }

        public void Update()
        {
            
        }
    }
}
