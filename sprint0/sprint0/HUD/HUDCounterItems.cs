using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
//Author: Stuti Shah
namespace sprint0
{
    public class HUDCounterItems : IHUDInventory
    {
        public Rectangle Location { get; set; }
        public Texture2D Texture { get; set; }
        public int CurrentNum { get => itemNum; }
        private int tens, ones, hundreds, itemNum;
        private readonly int mod = 10, reset = 0, sideLength = 8, xOffset = 528, yOffset = 117, hundredOffset = 519;
        private List<Rectangle> sources;

        public HUDCounterItems(Texture2D texture, Vector2 location)
        {
            Location = new Rectangle((int)location.X, (int)location.Y, reset, reset);
            Texture = texture;
            ResetNum();
            sources = SpritesheetHelper.GetFramesH(xOffset, yOffset, sideLength, sideLength, mod);
            sources.Add(new Rectangle(hundredOffset, yOffset, sideLength, sideLength));
        }
        public void Draw(SpriteBatch spriteBatch)
        {

            if (itemNum < reset || ones < reset) ResetNum();
            spriteBatch.Draw(Texture, new Rectangle(Location.X, Location.Y, (int)(sideLength * Game1.Scale), (int)(sideLength * Game1.Scale)), sources[hundreds], Color.White);
            spriteBatch.Draw(Texture, new Rectangle((int)(Location.X + sideLength * Game1.Scale), (int)Location.Y, (int)(sideLength * Game1.Scale), (int)(sideLength * Game1.Scale)), sources[tens], Color.White);
            spriteBatch.Draw(Texture, new Rectangle((int)(Location.X + 2 * sideLength * Game1.Scale), (int)Location.Y, (int)(sideLength * Game1.Scale), (int)(sideLength * Game1.Scale)), sources[ones], Color.White);
        }

        public void Update()
        {
            if (itemNum < reset) ResetNum();
            tens = itemNum / mod;
            ones = itemNum % mod;
            CheckHundreds();
        }

        public void ChangeNum(int change)
        {
            if ((itemNum += change) < reset) itemNum = reset;
        }
        public void Increment() => itemNum++;
        public void Decrement()
        {
            if (itemNum-- < reset) ResetNum();
        }

        public void ResetNum()
        {
            itemNum = reset;
            tens = itemNum;
            ones = itemNum;
            hundreds = mod;
        }

        private void CheckHundreds()
        {
            if (itemNum > 99)
            {
                hundreds = itemNum / (mod * mod);
                tens %= mod;
            }
            else hundreds = mod;
        }
    }
}
