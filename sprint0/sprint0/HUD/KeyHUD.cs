﻿using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

//Author: Stuti Shah
//Updated: 03/15/21 by shah.1440
namespace sprint0
{
    public class KeyHUD : IHUDInventory
    {
        public Rectangle Location { get; set; }
        public Texture2D Texture { get; set; }
        private int keyNumTens, keyNumOnes, keyNum;
        private readonly int xOffset = 528, yOffset = 117, reset = 0, mod = 10;
        private List<Rectangle> sources;
        private readonly int sideLength = 8;

        public KeyHUD(Texture2D texture, Vector2 location)
        {
            Location = new Rectangle((int)location.X, (int)location.Y, reset, reset);
            Texture = texture;
            ResetNum();
            int totalFrames = mod;
            sources = new List<Rectangle>();
            for (int frame = 0; frame < totalFrames; frame++)
            {
                sources.Add(new Rectangle(xOffset, yOffset, sideLength, sideLength));
                xOffset += sideLength + 1;
            }
            sources.Add(new Rectangle(519, yOffset, sideLength, sideLength));
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, new Rectangle((int)Location.X, (int)Location.Y, (int)(sideLength * Game1.Scale), (int)(sideLength * Game1.Scale)), sources[10], Color.White);
            spriteBatch.Draw(Texture, new Rectangle((int)(Location.X + sideLength * Game1.Scale), (int)Location.Y, (int)(sideLength * Game1.Scale), (int)(sideLength * Game1.Scale)), sources[keyNumTens], Color.White);
            spriteBatch.Draw(Texture, new Rectangle((int)(Location.X + 2 * sideLength * Game1.Scale), (int)Location.Y, (int)(sideLength * Game1.Scale), (int)(sideLength * Game1.Scale)), sources[keyNumOnes], Color.White);
        }

        public void Update()
        {
            keyNumTens = keyNum / mod;
            keyNumOnes = keyNum % mod;
        }
        public void ChangeNum(int change)
        {
            if ((keyNum += change) >= reset)
            {
                Update();
            }
            else ResetNum();
        }
        public void Increment()
        {
            keyNum++;
            Update();
        }

        public void Decrement()
        {
            if (keyNum-- >= reset)
            {
                Update();
            }
            else ResetNum();
        }

        public void ResetNum()
        {
            keyNum = reset;
            keyNumTens = keyNum;
            keyNumOnes = keyNum;
        }
    }
}
