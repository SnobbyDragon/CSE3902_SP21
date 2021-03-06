using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

/*
 * Last updated: 3/5/21 by li.10011
 */
namespace sprint0
{
    class DownUseItemSprite : ISprite
    {


        public Texture2D Texture { get => texture; set => texture = value; }
        public Rectangle Location { get; set; }
        private Texture2D texture;

        private readonly int xOffset = 107, yOffset = 11, size = 16;

        public DownUseItemSprite(Texture2D texture, Vector2 location)
        {
            Location = new Rectangle((int)location.X, (int)location.Y, size, size);
            this.texture = texture;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Location, new Rectangle(xOffset, yOffset, size, size), Color.White);
        }

        public void Update() {
            //Nothing here
        }
    }
}