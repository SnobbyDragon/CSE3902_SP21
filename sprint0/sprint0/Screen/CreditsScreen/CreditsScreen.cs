using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

//Author: Jacob Urick
//Updated: 03/28/21 by urick.9
namespace sprint0
{
    public class CreditsScreen
    {
        private readonly string message0 = "This game is based on the original Zelda.";
        private readonly string message1 = "It was created for CSE 3902 in Spring 2021 at the OSU";
        private readonly string message2 = "Its authors include:\n\nNeha Gupta,\n\nJesse He,\n\nHannah Johnson,\n\nAngela Li,\n\nStutti Shah,\n\nJacob Urick";
        private readonly string message3 = "We hope you enjoy it :)";
        private readonly string message4 = "Special thanks to Grace McKenzie and Dr. Matt Bogus for lots of invaluable feedback.";
        private readonly List<Text> textList;
        private readonly int xCoord = 25;
        private readonly int yCoord = 100;
        private readonly int firstOffset = 2;
        private readonly int secondOffset = 3;
        private readonly int thirdOffset = 6;
        private readonly int fourthOffset = 7;
        private readonly int mandatoryCreditsTimer = 800;
        private int counter;
        private readonly Game1 game;

        public CreditsScreen(Game1 game)
        {
            this.game = game;
            counter = 0;
            textList = new List<Text> {
                new Text(game, message0, new Vector2(xCoord, yCoord), Color.Black),
                new Text(game, message1, new Vector2(xCoord, yCoord*firstOffset), Color.Black),
                new Text(game, message2, new Vector2(xCoord, yCoord*secondOffset), Color.Black),
                new Text(game, message3, new Vector2(xCoord, yCoord*thirdOffset), Color.Black),
                new Text(game, message4, new Vector2(xCoord, yCoord*fourthOffset), Color.Black)
            };
        }

        public void Update()
        {
            if (counter > mandatoryCreditsTimer)
            {
                game.stateMachine.HandleStart();
            }
            counter++;
            foreach (Text text in textList)
                text.Location = new Vector2(xCoord, text.Location.Y - 1);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (Text text in textList)
                text.Draw(spriteBatch);
        }
    }
}
