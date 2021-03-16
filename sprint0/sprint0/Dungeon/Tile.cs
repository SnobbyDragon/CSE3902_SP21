using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

//Author: Hannah Johnson

namespace sprint0
{
    public class Tile : IBlock
    {

        public Rectangle Location { get; set; }
        public Texture2D Texture { get; set; }
        private Rectangle source;
        private readonly int width, height;

        public Tile(Texture2D texture, Vector2 location)
        {
            width = height = 16;
            Location = new Rectangle((int)location.X, (int)location.Y, (int)(width * Game1.Scale), (int)(height * Game1.Scale));
            Texture = texture;
            source = new Rectangle(984, 11, width, height);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Location, source, Color.White);
        }

        public void Update()
        {
        }

        public bool IsWalkable()
        {
            return true;
        }

        public bool IsMovable()
        {
            return false;
        }

        public void SetIsMovable()
        {
            throw new NotImplementedException();
        }
    }
}
