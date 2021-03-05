using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace sprint0
{
    public class Statue : ISprite
    {

        public Rectangle Location { get; set; }
        public Texture2D Texture { get; set; }
        private Rectangle source;
        private readonly int xOffset = 1018, yOffset = 11, width = 16, height = 16;

        public Statue(Texture2D texture, Vector2 location, string dir)
        {
            Location = new Rectangle((int)location.X, (int)location.Y, width, height);
            Texture = texture;
            if (dir.Equals("right"))
            { // creates a right facing statue
                source = new Rectangle(xOffset, yOffset, width, height);
            }
            else if (dir.Equals("left"))
            { // creates a left facing statue
                source = new Rectangle(xOffset + width + 1, yOffset, width, height);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Location, source, Color.White);
        }

        public void Update()
        {
            
        }

        public Collision GetCollision(ISprite other)
        {
            return Collision.None;
        }
    }
}
