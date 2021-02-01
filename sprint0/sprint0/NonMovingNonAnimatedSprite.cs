using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace sprint0
{
    class NonMovingNonAnimatedSprite : ISprite
    {
        public Vector2 Location { get; set; }
        public Texture2D Texture { get; set; }

        public NonMovingNonAnimatedSprite(Texture2D texture, Vector2 location)
        {
            Texture = texture;
            Location = location;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            int width = 22;
            int height = 40;

            Rectangle sourceRectangle = new Rectangle(393, 0, width, height);
            Rectangle destinationRectangle = new Rectangle((int)Location.X, (int)Location.Y, width, height);

            spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
        }

        public void Update() { }
    }
}
