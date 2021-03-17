using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

//Author: Stuti Shah
//Updated: 03/16/21 by li.10011
namespace sprint0
{
    public class HeartHUD : IHUDInventory
    {
        public Rectangle Location { get; set; }
        public Texture2D Texture { get; set; }
        private readonly int[] heartState;
        private readonly List<Rectangle> sources;
        private readonly int sideLength = 8, maxHealth = 32, heartType = 3, heartsPerRow = 8, numHearts = 16, healthToHeart = 2, reset = 0, xOffset = 627, yOffset = 117;
        private int currentHealth;

        public HeartHUD(Texture2D texture, Vector2 location)
        {
            Location = new Rectangle((int)location.X, (int)location.Y, 0, 0);
            Texture = texture;
            heartState = new int[3] { reset, reset, numHearts };
            ResetNum();
            int totalFrames = 3;
            sources = SpritesheetHelper.GetFramesH(xOffset, yOffset, sideLength, sideLength, totalFrames);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            int xShift = reset;
            int yShift = reset;
            int heartCount = reset;
            for (int i = reset; i < heartType; i++)
            {
                for (int num = reset; num < heartState[i]; num++)
                {
                    if (heartCount == heartsPerRow)
                    {
                        xShift = reset;
                        yShift = (int)(sideLength * Game1.Scale);
                    }
                    spriteBatch.Draw(Texture, new Rectangle((int)(Location.X + xShift), (int)(Location.Y + yShift), (int)(sideLength * Game1.Scale), (int)(sideLength * Game1.Scale)), sources[i], Color.White);
                    xShift += (int)(sideLength * Game1.Scale);
                    heartCount++;
                }
            }
        }

        public void Update()
        {
        }

        public void ChangeNum(int damage)
        {
            if ((currentHealth -= damage) >= reset)
            {
                heartState[2] = currentHealth / healthToHeart;
                heartState[1] = currentHealth % healthToHeart;
                heartState[0] = numHearts - heartState[2] - heartState[1];
            }
            else ZeroHealth();
        }

        public void Increment()
        {
        }

        public void Decrement()
        {
        }

        public void ResetNum()
        {
            currentHealth = maxHealth;
        }
        public void ZeroHealth()
        {
            currentHealth = reset;
            heartState[reset] = numHearts;
            for (int i = reset + 1; i < heartState.Length; i++)
            {
                heartState[i] = reset;
            }
        }
    }
}
