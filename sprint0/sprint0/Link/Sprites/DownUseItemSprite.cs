using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

/*
 * Last updated: 2/21/21 by urick.9
 */
namespace sprint0
{
    class DownUseItemSprite : ISprite
    {


        public Texture2D Texture { get => texture; set => texture = value; }
        public Vector2 Location { get => location; set => location = value; }
        private Texture2D texture;
        private Vector2 location;
        private readonly int xOffset = 107, yOffset = 11;
        public DownUseItemSprite(Texture2D texture, Vector2 location)
        {
            this.location = location;
            this.texture = texture;

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, location, new Rectangle(xOffset, yOffset, 16, 16), Color.White);
        }

        public void Update() {
            //Nothing here

        }
    }
}