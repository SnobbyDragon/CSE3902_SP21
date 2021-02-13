using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace sprint0
{
    public class HeartHUD : ISprite
    {
        public Vector2 Location { get; set; }
        public Texture2D Texture { get; set; }
        public int[] heartState;
        private List<Rectangle> sources;
        private int sideLength;

        public HeartHUD(Texture2D texture, Vector2 location, int[] heartNum)
        {
            Location = location;
            Texture = texture;
            heartState = heartNum;

            int totalFrames = 3;
            int xPos = 627, yPos = 117;
            sources = new List<Rectangle>();
            sideLength = 8;

            for (int frame = 0; frame < totalFrames; frame++)
            {
                sources.Add(new Rectangle(xPos, yPos, sideLength, sideLength));
                xPos += sideLength + 1;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            int xShift = 0;
            int yShift = 0;
            int heartCount = 0;
            for (int i = 0; i < heartState.Length; i++)
            {
                for (int num = 0; num < heartState[i]; num++)
                {
                    if (heartCount == 8)
                    {
                        xShift = 0;
                        yShift = 8;
                    }
                    spriteBatch.Draw(Texture, new Vector2(Location.X + xShift, Location.Y + yShift), sources[i], Color.White);
                    xShift += sideLength;
                    heartCount++;
                }
            }
        }

        public void Update()
        {
            //Does nothing
        }
    }
}
