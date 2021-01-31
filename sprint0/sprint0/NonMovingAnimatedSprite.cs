using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace sprint0
{
    class NonMovingAnimatedSprite : ISprite
    {
        public Vector2 Location { get; set; }
        public Texture2D Texture { get; set; }
        private List<Rectangle> frameList;
        private int currentFrame;
        private int repeatFrames;
        private int count;

        public NonMovingAnimatedSprite(Texture2D texture, Vector2 location)
        {
            Texture = texture;
            frameList = new List<Rectangle>();
            currentFrame = 0;
            repeatFrames = 2;
            count = 0;
            frameList.Add(new Rectangle(624, 138, 27, 36));
            frameList.Add(new Rectangle(624, 138, 27, 36));
            frameList.Add(new Rectangle(625, 418, 24, 25));
            frameList.Add(new Rectangle(625, 418, 24, 25));
            frameList.Add(new Rectangle(511, 1534, 19, 19));
            for (int i = 0; i < 11; i++)
                frameList.Add(new Rectangle(538 + i * 24, 1537, 16, 16));
            frameList.Add(new Rectangle(807, 1535, 19, 18));
            frameList.Add(new Rectangle(832, 1534, 19, 19));
            frameList.Add(new Rectangle(625, 418, 24, 25));
            frameList.Add(new Rectangle(625, 418, 24, 25));
            Location = location;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            Rectangle sourceRectangle = frameList[currentFrame];
            Rectangle destinationRectangle = new Rectangle((int)Location.X, (int)Location.Y + 36 - sourceRectangle.Height, sourceRectangle.Width, sourceRectangle.Height);

            spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
        }

        public void Update()
        {
            if(count == 0)
                currentFrame = (currentFrame + 1) % frameList.Count;
            count = (count + 1) % repeatFrames;
        }
    }
}
