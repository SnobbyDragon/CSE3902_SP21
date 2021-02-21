using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

//Author: Stuti Shah
namespace sprint0
{
    public class KeyHUD : ISprite
    {
        public Vector2 Location { get; set; }
        public Texture2D Texture { get; set; }
        public int keyNumTens;
        public int keyNumOnes;
        private List<Rectangle> sources;
        private int sideLength = 8;

        public KeyHUD(Texture2D texture, Vector2 location, int keyNum)
        {
            Location = location;
            Texture = texture;

            //the tens and ones place for the number of keys
            keyNumTens = keyNum / 10;
            keyNumOnes = keyNum % 10;

            int totalFrames = 10;
            int xPos = 528, yPos = 117;

            //Add number frames sources[0] = 0, ..., sources[9] = 9
            sources = new List<Rectangle>();
            for (int frame = 0; frame < totalFrames; frame++)
            {
                sources.Add(new Rectangle(xPos, yPos, sideLength, sideLength));
                xPos += sideLength + 1;
            }

            //'x' that comes before the number (eg. x15) (sources[10])
            sources.Add(new Rectangle(519, yPos, sideLength, sideLength));
        }


        public void Draw(SpriteBatch spriteBatch)
        {
            //draws the 'x'
            spriteBatch.Draw(Texture, new Rectangle((int)Location.X, (int)Location.Y, (int)(sideLength * Game1.Scale), (int)(sideLength * Game1.Scale)), sources[10], Color.White);

            //draws tens place
            spriteBatch.Draw(Texture, new Rectangle((int)(Location.X + sideLength * Game1.Scale), (int)Location.Y, (int)(sideLength * Game1.Scale), (int)(sideLength * Game1.Scale)), sources[keyNumTens], Color.White);

            //draws ones place
            spriteBatch.Draw(Texture, new Rectangle((int)(Location.X + 2 * sideLength * Game1.Scale), (int)Location.Y, (int)(sideLength * Game1.Scale), (int)(sideLength * Game1.Scale)), sources[keyNumOnes], Color.White);
        }

        public void Update()
        {
            //todo: update ones and tens after link gets/uses item
        }
    }
}
