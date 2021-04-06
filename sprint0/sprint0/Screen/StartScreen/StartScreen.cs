﻿using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

//Author: Jacob Urick
//Updated: 03/28/21 by urick.9
namespace sprint0
{
    public class StartScreen
    {
        private readonly string message0 = "Welcome to our take on \"The Legend of Zelda\"";
        private readonly string message1 = "Press C to view the credits!";
        private readonly string message2 = "Press Space to start the game in play mode!";
        private readonly string message3 = "Press T to start the game in test mode!(unlimited items, click to change rooms)";
        private readonly List<Text> textList;
        private readonly int xCoord0 = 150;
        private readonly int yCoord0 = 150;
        private readonly int xCoord1 = 50;
        private readonly int yCoord12 = 250;
        private readonly int yCoord2 = 350;
        private readonly int xCoord2 = 250;
        private readonly Game1 game;

        public StartScreen(Game1 game)
        {
            this.game = game;
            textList = new List<Text> {
                new Text(game, message0, new Vector2(xCoord0, yCoord0), Color.Black),
                new Text(game, message1, new Vector2(xCoord1, yCoord12), Color.Black),
                new Text(game, message2, new Vector2(xCoord2, yCoord12), Color.Black),
                new Text(game, message3, new Vector2(xCoord1, yCoord2), Color.Black)
        };

        }

        public void Update() {
            //no-op
        }
        public void Draw(SpriteBatch spriteBatch) 
        {
            foreach (Text text in textList)
            {
                text.Draw(spriteBatch);
            }
        }
    }
}
