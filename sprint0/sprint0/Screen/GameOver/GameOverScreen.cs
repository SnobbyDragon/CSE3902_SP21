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
        private readonly string message = "You have perished. Press r to run it back or q to quit.";
        private readonly Text text;
        private readonly int xCoord = 150;
        private readonly int yCoord = 150;
        public GameOverScreen(Game1 game) => text = new Text(game, message, new Vector2(xCoord, yCoord), Color.Black);
        public void Draw(SpriteBatch spriteBatch) => text.Draw(spriteBatch);
    }
}
