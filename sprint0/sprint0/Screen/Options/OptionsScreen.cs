using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

//Author: Jacob Urick
//Updated: 03/28/21 by urick.9
namespace sprint0
{
    public class OptionsScreen
    {
        private readonly string message0 = "Options Screen";
       
        private List<Text> textList;
        private readonly int xCoord = 25;
        private readonly int yCoord = 100;

        private readonly int mandatoryCreditsTimer = 800;
        private int counter;
        private readonly Game1 game;

        public OptionsScreen(Game1 game)
        {
            this.game = game;
            counter = 0;
            textList = new List<Text> {
                new Text(game, message0, new Vector2(xCoord, yCoord), Color.Black),
            };
        }

        public void Update()
        {
            if (counter > mandatoryCreditsTimer)
            {
                counter = 0;
                textList = new List<Text>
                {
                    new Text(game, message0, new Vector2(xCoord, yCoord), Color.Black)
                };
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
