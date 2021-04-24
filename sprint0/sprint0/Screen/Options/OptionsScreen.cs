using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

//Author: Jacob Urick
//Updated: 04/12/21 by urick.9
namespace sprint0
{
    public class OptionsScreen
    {
        private readonly string message0 = "Options Screen";
        private readonly string message1 = "The current room scroll speed:     ";

        private readonly string message2 = "Use the left and right arrow keys to adjust";
        private readonly string message3 = "You are currently in";
        private readonly string message4 = "mode.";
        private readonly string message5 = "Press E for easy mode and H for hard mode.";
        private readonly string easy = " easy ";
        private readonly string hard = " hard ";
        private List<Text> textList;
        private readonly int xCoord = 25;
        private readonly int yCoord = 100;
        private int yCoord1 = 150;
        private int yCoord2 = 200;
        private int yCoord3 = 250;
        private int yCoord4 = 300;
        private string mode = "";
        private readonly Game1 game;
        private string speed;
        private readonly Color textColor = Color.White;
        public OptionsScreen(Game1 game)
        {
            this.game = game;
            BuildSpeed();
            textList = new List<Text> {
                new Text(game, message0, new Vector2(xCoord, yCoord), textColor),
                new Text(game, message1, new Vector2(xCoord, yCoord1), textColor),
                new Text(game, message2 + speed, new Vector2(xCoord, yCoord2), textColor),
                new Text(game, message3 + mode + message4, new Vector2(xCoord, yCoord3), textColor),
                new Text(game, message5, new Vector2(xCoord, yCoord4), textColor),
            };
        }

        private void BuildSpeed()
        {
            speed = "";
            int sp = game.ScrollSpeed;
            for (int i = 0; i < sp; i++)
            {
                speed += "#";
            }
            for (int i = 0; i < game.scrollSpeedUbound - sp; i++)
            {
                speed += "=";
            }
        }

        private void BuildMode()
        {
            if (game.stateMachine.GetMode() == GameStateMachine.Mode.easy)
            {
                mode = easy;
            }
            if (game.stateMachine.GetMode() == GameStateMachine.Mode.hard)
            {
                mode = hard;
            }
        }
        public void Update()
        {
            BuildMode();
            BuildSpeed();
            textList = new List<Text> {
              new Text(game, message0, new Vector2(xCoord, yCoord), textColor),
                new Text(game, message1, new Vector2(xCoord, yCoord1), textColor),
                new Text(game, message2 + speed, new Vector2(xCoord, yCoord2), textColor),
                new Text(game, message3 + mode + message4, new Vector2(xCoord, yCoord3),textColor),
                new Text(game, message5, new Vector2(xCoord, yCoord4), textColor),
            };
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (Text text in textList)
                text.Draw(spriteBatch);
        }
    }

}
