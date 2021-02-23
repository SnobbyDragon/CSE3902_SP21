using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

/*
 * Last updated: 2/21/21 by urick.9
 */
namespace sprint0
{
    class LeftUseItemSprite : ISprite
    {


        public Texture2D Texture { get => texture; set => texture = value; }
        public Vector2 Location { get => location; set => location = value; }
        private Texture2D texture;
        private Vector2 location;
        private readonly Rectangle source;
        private readonly int xOffset = 124, yOffset = 11;
        public LeftUseItemSprite(Texture2D texture, Vector2 location)
        {
            this.location = location;
            this.texture = texture;
            source = new Rectangle(xOffset, yOffset, 16, 16);

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Rectangle destination = new Rectangle((int)location.X, (int)location.Y, 16, 16);
            spriteBatch.Draw(texture, destination, source, Color.White, 0, new Vector2(0, 0), SpriteEffects.FlipHorizontally, 0);
        }

        public void Update()
        {
            //Nothing here

        }
    }
}