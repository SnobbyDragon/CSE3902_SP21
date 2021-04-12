using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

/*
 * Last updated: 2/21/21 by urick.9
 */
namespace sprint0
{
    class UpUseItemSprite : ISprite
    {
        public Texture2D Texture { get => texture; set => texture = value; }
        public Rectangle Location { get; set; }
        private Texture2D texture;
        private readonly int xOffset = 140, yOffset = 11, width = 16, height = 16;

        public UpUseItemSprite(Texture2D texture, Vector2 location)
        {
            Location = new Rectangle((int)location.X, (int)location.Y, (int)(width * Game1.Scale), (int)(height * Game1.Scale));
            this.texture = texture;
        }

        public void Draw(SpriteBatch spriteBatch)
            => spriteBatch.Draw(Texture, Location, new Rectangle(xOffset, yOffset, width, height), Color.White);
        public void Update() { }
    }
}