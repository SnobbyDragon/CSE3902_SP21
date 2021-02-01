using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace sprint0
{
    class MovingAnimatedSprite : ISprite
    {
        public Vector2 Location { get; set; }
        public Texture2D Texture { get; set; }
        private List<Rectangle> frameList;
        private int currentFrame;
        private int xPos; //TODO delete this
        private int repeatFrames;
        private int count;

        public MovingAnimatedSprite(Texture2D texture, Vector2 location)
        {
            Texture = texture;
            frameList = new List<Rectangle>();
            currentFrame = 0;
            xPos = 0;
            repeatFrames = 2;
            count = 0;
            frameList.Add(new Rectangle(509, 218, 20, 36));
            frameList.Add(new Rectangle(544, 217, 26, 37));
            frameList.Add(new Rectangle(578, 216, 32, 38));
            frameList.Add(new Rectangle(616, 217, 32, 37));
            frameList.Add(new Rectangle(654, 217, 30, 37));
            frameList.Add(new Rectangle(699, 218, 22, 36));
            frameList.Add(new Rectangle(733, 217, 23, 37));
            frameList.Add(new Rectangle(766, 217, 29, 37));
            frameList.Add(new Rectangle(803, 216, 30, 38));
            frameList.Add(new Rectangle(842, 217, 27, 37));
            Location = location;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Rectangle sourceRectangle = frameList[currentFrame];
            Rectangle destinationRectangle = new Rectangle((int)Location.X - 50 + 32 - sourceRectangle.Width,
                (int)Location.Y + 38 - sourceRectangle.Height, sourceRectangle.Width, sourceRectangle.Height);

            spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
        }

        public void Update()
        {
           if (count == 0)
           {
                currentFrame = (currentFrame + 1) % frameList.Count;
                xPos = (xPos + 5) % 850;
           }
           count = (count + 1) % repeatFrames;
        }
    }
}
