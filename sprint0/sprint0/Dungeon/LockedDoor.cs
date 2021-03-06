using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace sprint0
{
    public class LockedDoor : ISprite
    {

        public Rectangle Location { get; set; }
        public Texture2D Texture { get; set; }
        private Rectangle source;
        private readonly int xOffset = 881, yOffset = 11, size = 32;

        public LockedDoor(Texture2D texture, Vector2 location, string dir)
        {
            Location = new Rectangle((int)location.X, (int)location.Y, (int)(size * Game1.Scale), (int)(size * Game1.Scale));
            Texture = texture;
            source = dir switch
            {
                "down" => new Rectangle(xOffset, yOffset, size, size),
                "right" => new Rectangle(xOffset, yOffset + size + 1, size, size),
                "left" => new Rectangle(xOffset, yOffset + 2 * (size + 1), size, size),
                "up" => new Rectangle(xOffset, yOffset + 3 * (size + 1), size, size),
                _ => throw new ArgumentException("Invalid direction! Failed to make locked door.")
            };
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
