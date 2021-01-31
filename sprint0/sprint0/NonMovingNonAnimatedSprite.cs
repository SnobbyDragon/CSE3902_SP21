using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace sprint0
{
    class NonMovingNonAnimatedSprite : ISprite
    {
        public Texture2D Texture { get; set; }

        public NonMovingNonAnimatedSprite(Texture2D texture)
        {
            Texture = texture;
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            int width = 22;
            int height = 40;

            Rectangle sourceRectangle = new Rectangle(393, 0, width, height);
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, width, height);

            spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
        }

        public void Update() { }
    }
}
