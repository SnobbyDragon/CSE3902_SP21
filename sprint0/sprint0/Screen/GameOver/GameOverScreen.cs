using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

//Author: Jacob Urick
//Updated: 03/28/21 by urick.9
namespace sprint0
{
    public class GameOverScreen
    {
        private readonly string message = "You have perished. \nPress 'R' to run it back or 'Q' to quit.";
        private readonly Text text;
        private readonly int xCoord = 150;
        private readonly int yCoord = 150;
        private readonly Color textColor = Color.White;
        public GameOverScreen(Game1 game) => text = new Text(game, message, new Vector2(xCoord, yCoord), textColor);
        public void Draw(SpriteBatch spriteBatch) => text.Draw(spriteBatch);
    }
}
