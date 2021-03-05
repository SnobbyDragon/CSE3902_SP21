using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

//Stuti Shah
namespace sprint0
{
    public class HeartHUD : ISprite
    {
        public Rectangle Location { get; set; }
        public Texture2D Texture { get; set; }
        public int[] heartState { get; set; }
        private readonly List<Rectangle> sources;
        private readonly int sideLength;

        public HeartHUD(Texture2D texture, Vector2 location, int[] heartNum)
        {
            Location = new Rectangle((int)location.X, (int)location.Y, 0, 0); // this rectangle is just a point
            Texture = texture;

            //heartState[0] : number of empty hearts
            //heartState[1] : number of half hearts
            //heartState[2] : number of full hearts
            //note: total number of hearts : 16
            heartState = heartNum;

            int totalFrames = 3;
            int xPos = 627, yPos = 117;
            sources = new List<Rectangle>();
            sideLength = 8;

            //add empty, half, and full heart sprites
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

            //go through empty, half, and full hearts
            for (int i = 0; i < heartState.Length; i++)
            {
                //go through number of hearts for empty, half, or full hearts
                for (int num = 0; num < heartState[i]; num++)
                {
                    //if first row of hearts is full, reset xShift and change yShift to start second row
                    if (heartCount == 8)
                    {
                        xShift = 0;
                        yShift = (int)(sideLength * Game1.Scale);
                    }

                    //draw hearts
                    spriteBatch.Draw(Texture, new Rectangle((int)(Location.X + xShift), (int)(Location.Y + yShift), (int)(sideLength * Game1.Scale), (int)(sideLength * Game1.Scale)), sources[i], Color.White);

                    xShift += (int)(sideLength * Game1.Scale);
                    heartCount++;
                }
            }
        }

        public void Update()
        {
            //change heartState based on link's damage
        }

        public Collision GetCollision(ISprite other)
        {
            return Collision.None;
        }
    }
}
