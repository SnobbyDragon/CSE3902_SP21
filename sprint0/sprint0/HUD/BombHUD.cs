using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

//Author: Stuti Shah
//Updated: 03/27/21 by shah.1440
namespace sprint0
{
    public class BombHUD : IHUDInventory
    {
        public Rectangle Location { get; set; }
        public Texture2D Texture { get; set; }
        public int CurrentNum { get => bombNum; }
        private int bombNumTens, bombNumOnes, bombNumHundreds, bombNum;
        private readonly int mod = 10, xOffset = 528, yOffset = 117, reset = 0, sideLength = 8;
        private readonly List<Rectangle> sources;

        public BombHUD(Texture2D texture, Vector2 location)
        {
            Location = new Rectangle((int)location.X, (int)location.Y, reset, reset);
            Texture = texture;
            ResetNum();
            int totalFrames = mod;
            sources = SpritesheetHelper.GetFramesH(xOffset, yOffset, sideLength, sideLength, totalFrames);
            sources.Add(new Rectangle(519, yOffset, sideLength, sideLength));
        }


        public void Draw(SpriteBatch spriteBatch)
        {

            if (bombNum < reset || bombNumOnes < reset) ResetNum();
            spriteBatch.Draw(Texture, new Rectangle(Location.X, Location.Y, (int)(sideLength * Game1.Scale), (int)(sideLength * Game1.Scale)), sources[bombNumHundreds], Color.White);
            spriteBatch.Draw(Texture, new Rectangle((int)(Location.X + sideLength * Game1.Scale), (int)Location.Y, (int)(sideLength * Game1.Scale), (int)(sideLength * Game1.Scale)), sources[bombNumTens], Color.White);
            spriteBatch.Draw(Texture, new Rectangle((int)(Location.X + 2 * sideLength * Game1.Scale), (int)Location.Y, (int)(sideLength * Game1.Scale), (int)(sideLength * Game1.Scale)), sources[bombNumOnes], Color.White);
        }

        public void Update()
        {
            if (bombNum < reset) ResetNum();
            bombNumTens = bombNum / mod;
            bombNumOnes = bombNum % mod;
            CheckHundreds();
        }

        public void ChangeNum(int change)
        {
            if ((bombNum += change) < reset) bombNum = reset;


        }
        public void Increment()
        {
            bombNum++;
        }

        public void Decrement()
        {
            if (bombNum-- < reset) ResetNum();

        }

        public void ResetNum()
        {
            bombNum = reset;
            bombNumTens = bombNum;
            bombNumOnes = bombNum;
            bombNumHundreds = mod;
        }

        private void CheckHundreds()
        {
            if (bombNum > 99)
            {
                bombNumHundreds = bombNum / (mod * mod);
                bombNumTens %= mod;
            }
            else
            {
                bombNumHundreds = mod;
            }
        }
    }
}
