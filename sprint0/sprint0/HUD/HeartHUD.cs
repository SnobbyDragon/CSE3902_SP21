using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

//Author: Stuti Shah
//Updated: 03/24/21 by shah.1440
namespace sprint0
{
    public class HeartHUD : IHUDInventory
    {
        public Rectangle Location { get; set; }
        public Texture2D Texture { get; set; }
        public int CurrentNum { get => currentHealth; }
        private readonly int[] heartState;
        private readonly List<Rectangle> sources;
        private const int heartType = 3;
        private readonly int sideLength = 8, heartsPerRow = 8,
            healthToHeart = 2, reset = 0, xOffset = 627,
            yOffset = 117, maxPossibleHearts = 32;
        private int currentHealth, numHearts, maxHealth = 28;

        public HeartHUD(Texture2D texture, Vector2 location)
        {
            Location = new Rectangle((int)location.X, (int)location.Y, 0, 0);
            Texture = texture;
            numHearts = maxHealth / 2;
            heartState = new int[heartType] { reset, reset, numHearts };
            ResetNum();
            sources = SpritesheetHelper.GetFramesH(xOffset, yOffset, sideLength, sideLength, heartType);
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
                    spriteBatch.Draw(Texture, new Rectangle(Location.X + xShift, Location.Y + yShift, (int)(sideLength * Game1.Scale), (int)(sideLength * Game1.Scale)), sources[i], Color.White);
                    xShift += (int)(sideLength * Game1.Scale);
                    heartCount++;
                }
            }
        }

        public void Update()
        {
            heartState[2] = currentHealth / healthToHeart;
            heartState[1] = currentHealth % healthToHeart;
            heartState[0] = numHearts - heartState[2] - heartState[1];
        }

        public void ChangeNum(int damage)
        {
            if ((currentHealth -= damage) <= reset) ZeroHealth();
            else if (currentHealth > maxHealth) ResetNum();
        }

        public void Increment()
        {
            if (maxHealth + healthToHeart <= maxPossibleHearts)
            {
                maxHealth += healthToHeart;
                currentHealth += healthToHeart;
                numHearts++;
            }
        }

        public void Decrement() { }
        public void ResetNum() => currentHealth = maxHealth;
        public void ZeroHealth()
        {
            currentHealth = reset;
            heartState[reset] = numHearts;
            for (int i = reset + 1; i < heartState.Length; i++)
                heartState[i] = reset;
        }
    }
}
