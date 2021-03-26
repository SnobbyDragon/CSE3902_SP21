using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

//Author: Stuti Shah
//Updated: 03/25/21 by shah.1440
namespace sprint0
{
    public class PauseScreen
    {
        public Texture2D Texture { get; set; }
        private readonly List<Rectangle> source;
        public PlayerItems Item { get; set; }
        private readonly int lXOffset = 258, lYOffset = 112, iXOffset = 1, iYOffset = 11, height = 88, XDraw = 0;
        private readonly List<int> yDraw;

        public PauseScreen(Game1 game)
        {
            Texture = new HUDFactory(game).Texture;
            yDraw = new List<int> { (int)(Game1.HUDHeight * Game1.Scale), (int)((Game1.HUDHeight + height) * Game1.Scale) };
            source = new List<Rectangle>{
                new Rectangle(iXOffset, iYOffset, Game1.Width, height),
                new Rectangle(lXOffset, lYOffset, Game1.Width, height),
            };
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            int yIndex = 0;
            foreach (Rectangle r in source)
            {
                spriteBatch.Draw(Texture, new Rectangle(XDraw, yDraw[yIndex], (int)(Game1.Width * Game1.Scale), (int)(height * Game1.Scale)), r, Color.White);
                yIndex++;
            }
        }
    }
}
