using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

//Author: Stuti Shah
//Updated: 03/15/21 by shah.1440
namespace sprint0
{
    public class RupeeHUD : IHUDInventory
    {
        public Rectangle Location { get; set; }
        public Texture2D Texture { get; set; }
        private int rupeeNumTens, rupeeNumOnes, rupeeNum;
        private readonly int mod = 10, xOffset = 528, yOffset = 117, reset = 0;
        private readonly List<Rectangle> sources;
        private readonly int sideLength = 8, totalFrames = 10;

        public RupeeHUD(Texture2D texture, Vector2 location)
        {
            Location = new Rectangle((int)location.X, (int)location.Y, reset, reset);
            Texture = texture;
            ResetNum();
            //Add number frames sources[0] = 0, ..., sources[9] = 9
            sources = new List<Rectangle>();
            for (int frame = reset; frame < totalFrames; frame++)
            {
                sources.Add(new Rectangle(xOffset, yOffset, sideLength, sideLength));
                xOffset += sideLength + 1;
            }
            //'x' that comes before the number (eg. x15) (sources[10])
            sources.Add(new Rectangle(519, yOffset, sideLength, sideLength));
        }


        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, new Rectangle((int)Location.X, (int)Location.Y, (int)(sideLength * Game1.Scale), (int)(sideLength * Game1.Scale)), sources[totalFrames], Color.White);
            spriteBatch.Draw(Texture, new Rectangle((int)(Location.X + sideLength * Game1.Scale), (int)Location.Y, (int)(sideLength * Game1.Scale), (int)(sideLength * Game1.Scale)), sources[rupeeNumTens], Color.White);
            spriteBatch.Draw(Texture, new Rectangle((int)(Location.X + 2 * sideLength * Game1.Scale), (int)Location.Y, (int)(sideLength * Game1.Scale), (int)(sideLength * Game1.Scale)), sources[rupeeNumOnes], Color.White);
        }

        public void Update()
        {
            rupeeNumTens = rupeeNum / mod;
            rupeeNumOnes = rupeeNum % mod;
        }
        public void ChangeNum(int change)
        {
            if ((rupeeNum += change) >= reset)
            {
                Update();
            }
            else ResetNum();

        }
        public void Increment()
        {
            rupeeNum++;
            Update();
        }

        public void Decrement()
        {
            if (rupeeNum-- >= reset)
            {
                Update();
            }
            else ResetNum();
        }

        public void ResetNum()
        {
            rupeeNum = reset;
            rupeeNumTens = rupeeNum;
            rupeeNumOnes = rupeeNum;

        }
    }
}
