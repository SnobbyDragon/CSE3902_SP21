using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

//Author: Stuti Shah
namespace sprint0
{
    public class RupeeHUD : ISprite
    {
        public Rectangle Location { get; set; }
        public Texture2D Texture { get; set; }
        public int rupeeNumTens;
        public int rupeeNumOnes;
        private List<Rectangle> sources;
        private int sideLength = 8;

        public RupeeHUD(Texture2D texture, Vector2 location, int rupeeNum)
        {
            Location = new Rectangle((int)location.X, (int)location.Y, 0, 0); // this rectangle is just a point
            Texture = texture;

            //the tens and ones place for the number of rupees
            rupeeNumTens = rupeeNum / 10;
            rupeeNumOnes = rupeeNum % 10;

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
            spriteBatch.Draw(Texture, new Rectangle((int)(Location.X + sideLength * Game1.Scale), (int)Location.Y, (int)(sideLength * Game1.Scale), (int)(sideLength * Game1.Scale)), sources[rupeeNumTens], Color.White);

            //draws ones place
            spriteBatch.Draw(Texture, new Rectangle((int)(Location.X + 2 * sideLength * Game1.Scale), (int)Location.Y, (int)(sideLength * Game1.Scale), (int)(sideLength * Game1.Scale)), sources[rupeeNumOnes], Color.White);
        }

        public void Update()
        {
            //todo: update ones and tens after link gets/uses item
        }

        public Collision GetCollision(ISprite other)
        {   
            return Collision.None;
        }
    }
}
