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
        private int rupeeNumTens, rupeeNumOnes, rupeeNumHundreds, rupeeNum;
        public int CurrentNum { get => rupeeNum; }
        private readonly int mod = 10, xOffset = 528, yOffset = 117, reset = 0;
        private readonly List<Rectangle> sources;
        private readonly int sideLength = 8, totalFrames = 10;

        public RupeeHUD(Texture2D texture, Vector2 location)
        {
            Location = new Rectangle((int)location.X, (int)location.Y, reset, reset);
            Texture = texture;
            ResetNum();
            sources = SpritesheetHelper.GetFramesH(xOffset, yOffset, sideLength, sideLength, totalFrames);
            sources.Add(new Rectangle(519, yOffset, sideLength, sideLength));
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, new Rectangle((int)Location.X, (int)Location.Y, (int)(sideLength * Game1.Scale), (int)(sideLength * Game1.Scale)), sources[rupeeNumHundreds], Color.White);
            spriteBatch.Draw(Texture, new Rectangle((int)(Location.X + sideLength * Game1.Scale), (int)Location.Y, (int)(sideLength * Game1.Scale), (int)(sideLength * Game1.Scale)), sources[rupeeNumTens], Color.White);
            spriteBatch.Draw(Texture, new Rectangle((int)(Location.X + 2 * sideLength * Game1.Scale), (int)Location.Y, (int)(sideLength * Game1.Scale), (int)(sideLength * Game1.Scale)), sources[rupeeNumOnes], Color.White);
        }

        public void Update()
        {
            rupeeNumTens = rupeeNum / mod;
            rupeeNumOnes = rupeeNum % mod;
            CheckHundreds();
        }

        public void ChangeNum(int change)
        {
            if ((rupeeNum += change) < reset) ResetNum();
        }

        public void Increment()
        {
            rupeeNum++;
        }

        public void Decrement()
        {
            if (rupeeNum-- < reset) ResetNum();
        }

        public void ResetNum()
        {
            rupeeNum = reset;
            rupeeNumTens = rupeeNum;
            rupeeNumOnes = rupeeNum;
            rupeeNumHundreds = mod;
        }

        private void CheckHundreds()
        {
            if (rupeeNum > 99)
            {
                rupeeNumHundreds = rupeeNum / (mod * mod);
                rupeeNumTens %= mod;
            }
            else
            {
                rupeeNumHundreds = mod;
            }
        }
    }
}
