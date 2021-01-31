using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace sprint0
{
    class MovingNonAnimatedSprite : ISprite
    {
        public Vector2 Location { get; set; }
        public Texture2D Texture { get; set; }
        private int yOffset = 0;
        private bool movingUp = true;

        public MovingNonAnimatedSprite(Texture2D texture, Vector2 location)
        {
            Texture = texture;
            Location = location;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            int width = 17;
            int height = 38;

            Rectangle sourceRectangle = new Rectangle(208, 2048, width, height);
            Rectangle destinationRectangle = new Rectangle((int)Location.X, (int)Location.Y + yOffset, width, height);

            spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
        }

        public void Update()
        {
            if (movingUp)
            {
                yOffset += 1;
                if (yOffset >= 16)
                    movingUp = false;
            } else
            {
                yOffset -= 1;
                if (yOffset <= -16)
                    movingUp = true;
            }
        }
    }
}

