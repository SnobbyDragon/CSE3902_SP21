using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

/*
 * Last updated: 3/5/21 by li.10011
 */
namespace sprint0
{
    class LeftUseItemSprite : ISprite
    {
        public Texture2D Texture { get => texture; set => texture = value; }
        public Rectangle Location { get; set; }
        private Texture2D texture;
        
        private readonly Rectangle source;
        private readonly int xOffset = 124, yOffset = 11, size = 16;
        public LeftUseItemSprite(Texture2D texture, Vector2 location)
        {
            Location = new Rectangle((int)location.X, (int)location.Y, size, size);
            this.texture = texture;
            source = new Rectangle(xOffset, yOffset, size, size);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, Location, source, Color.White, 0, new Vector2(0, 0), SpriteEffects.FlipHorizontally, 0);
        }

        public void Update()
        {
            //Nothing here
        }
    }
}