using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

//Author: Stuti Shah
//Updated: 03/15/21 by shah.1440
namespace sprint0
{
    public class BombHUD : IHUDInventory
    {
        public Rectangle Location { get; set; }
        public Texture2D Texture { get; set; }
        private int bombNumTens, bombNumOnes, bombNum;
        private readonly int mod = 10, xOffset = 528, yOffset = 117, reset = 0, sideLength = 8;
        private readonly List<Rectangle> sources;

        public BombHUD(Texture2D texture, Vector2 location)
        {
            Location = new Rectangle((int)location.X, (int)location.Y, reset, reset);
            Texture = texture;
            ResetNum();
            int totalFrames = mod;
            sources = new List<Rectangle>();
            for (int frame = reset; frame < totalFrames; frame++)
            {
                sources.Add(new Rectangle(xOffset, yOffset, sideLength, sideLength));
                xOffset += sideLength + 1;
            }
            sources.Add(new Rectangle(519, yOffset, sideLength, sideLength));
        }


        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, new Rectangle((int)Location.X, (int)Location.Y, (int)(sideLength * Game1.Scale), (int)(sideLength * Game1.Scale)), sources[10], Color.White);
            spriteBatch.Draw(Texture, new Rectangle((int)(Location.X + sideLength * Game1.Scale), (int)Location.Y, (int)(sideLength * Game1.Scale), (int)(sideLength * Game1.Scale)), sources[bombNumTens], Color.White);
            spriteBatch.Draw(Texture, new Rectangle((int)(Location.X + 2 * sideLength * Game1.Scale), (int)Location.Y, (int)(sideLength * Game1.Scale), (int)(sideLength * Game1.Scale)), sources[bombNumOnes], Color.White);
        }

        public void Update()
        {
            bombNumTens = bombNum / mod;
            bombNumOnes = bombNum % mod;
        }

        public void ChangeNum(int change)
        {
            if ((bombNum += change) >= reset)
            {
                Update();
            }
            else bombNum = reset;

        }
        public void Increment()
        {

            bombNum++;
            Update();
        }

        public void Decrement()
        {
            if (bombNum-- >= reset)
            {
                Update();
            }
            else ResetNum();

        }

        public void ResetNum()
        {
            bombNum = reset;
            bombNumTens = bombNum;
            bombNumOnes = bombNum;
        }
    }
}
