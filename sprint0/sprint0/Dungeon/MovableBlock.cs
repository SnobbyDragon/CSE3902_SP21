using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace sprint0
{
    public class MovableBlock : IBlock
    {
        public Rectangle Location { get; set; }
        public Texture2D Texture { get; set; }
        private Rectangle source;
        private readonly int width, height;

        public MovableBlock(Texture2D texture, Vector2 location)
        {
            width = height = 16;
            Location = new Rectangle((int)location.X, (int)location.Y, (int)(width * Game1.Scale), (int)(height * Game1.Scale));
            Texture = texture;
            source = new Rectangle(1001, 11, width, height);

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Location, source, Color.White);
        }

        public void Update()
        {
            //No movement for now
        }

        public bool IsWalkable()
        {
            return false;
        }

        public bool IsMovable()
        {
            return true;
        }
    }
}
