using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

//Author: Hannah Johnson

namespace sprint0
{
    public class Water : IBlock
    {
        public Rectangle Location { get; set; }
        public Texture2D Texture { get; set; }
        private Rectangle source;
        private readonly int width, height;

        public Water(Texture2D texture, Vector2 location)
        {
            width = height = 16;
            Location = new Rectangle((int)location.X, (int)location.Y, (int)(width * Game1.Scale), (int)(height * Game1.Scale));
            Texture = texture;
            source = new Rectangle(1018, 28, width, height);
        }

        public void Draw(SpriteBatch spriteBatch) => spriteBatch.Draw(Texture, Location, source, Color.White);
        public void Update() { }
        public bool IsWalkable() => false;
        public bool IsMovable(Direction dir) => false;
        public void SetIsMovable() => throw new NotImplementedException();
    }
}
