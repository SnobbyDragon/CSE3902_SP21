using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

//Author: Jacob Urick
//Updated: 03/28/21 by urick.9
namespace sprint0
{
    public class StartScreen
    {
        private readonly string messageWelcome = "Welcome to our take on \"The Legend of Zelda\"";
        private readonly string messageCredits = "Press C to view the credits!";
        private readonly string messageInstructions = "Press I to view the controls!";
        private readonly string messageLvl1 = "Press 1 to begin with level 1";
        private readonly string messageLvl2 = "Press 2 to begin in level 2";
        private readonly string messageLvl3 = "Press 3 to begin in level 3";
        private readonly string messageLvl4 = "Press 4 to begin in level 4";
        private readonly List<Text> textList;
        private readonly int yCoord0 = 150;
        private readonly int xCoord1 = 50;

        private readonly int yCoord12 = 250;
        private readonly int yCoord2 = 350;
        private readonly int yCoordLvl2 = 400;
        private readonly int yCoordLvl4 = 500;
        private readonly int yCoord3 = 450;
        //private readonly int xCoord2 = 250;
        private readonly Game1 game;
        private readonly Color textColor = Color.White;

        public StartScreen(Game1 game)
        {
            this.game = game;
            textList = new List<Text> {
                new Text(game, messageWelcome, new Vector2(xCoord1, yCoord0 - xCoord1), textColor),
                new Text(game, messageCredits, new Vector2(xCoord1, yCoord12 - xCoord1), textColor),
                new Text(game, messageInstructions, new Vector2(xCoord1, yCoord12), textColor),
                new Text(game, messageLvl1, new Vector2(xCoord1, yCoord2), textColor),
                new Text(game, messageLvl2, new Vector2(xCoord1, yCoordLvl2), textColor),
                new Text(game, messageLvl3, new Vector2(xCoord1, yCoord3), textColor),
                new Text(game, messageLvl4, new Vector2(xCoord1, yCoordLvl4), textColor)
            };
        }

        public void Update() { }
        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (Text text in textList)
                text.Draw(spriteBatch);
        }
    }
}
