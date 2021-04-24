using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

//Author: Stuti Shah
namespace sprint0
{
    public class InstructionScreen
    {
        private readonly string messageGoal = "Your objective: \nPick up the triforce piece \nlocated in one of the rooms. \nGood Luck!";
        private readonly string messageIntro = "Controls:";
        private readonly string messageLinkMovement = "WASD / Arrow Keys: Move Link";
        private readonly string messageLinkSword = " 'N' / 'Z': Use Sword";
        private readonly string messageChangeSword = " 'F': Changes Sword";
        private readonly string messageBItem = " 'X' [Playing]: Use B Item";

        private readonly string messageMusicControls = "Music Controls:";
        private readonly string messageSoundMute = " 'M': Toggle Music";
        private readonly string messageSoundEffectMute = " [COMMA]: Toggle Sound Effects";
        private readonly string messageSoundChange = " [PERIOD]: Change Music";

        private readonly string messageMenu = "Menu/Mode Controls:";
        private readonly string messageOptions = " 'O': Opens Options Menu";
        private readonly string messagePause = " 'E': Pauses Game / Opens Inventory";
        private readonly string messageTestMode = " 'T': Toggle Test Mode";
        private readonly string messageSelectItem = " 'X' [Paused]: Select B Item and Unpause Game";
        private readonly string messageItemSelection = " 'G' / 'H' [Paused] : Switch through possible B Items";
        private readonly string messageQuit = "Q: Quit game";
        private readonly string messageReset = "R: Reset Game";
        private List<Text> textList;
        private readonly int xCoord = 25;
        private readonly int yCoord = 50;
        private readonly int firstOffset = 2;
        private readonly int secondOffset = 3;
        private readonly int thirdOffset = 4;
        private readonly int fourthOffset = 5;
        private readonly int mandatoryCreditsTimer = 1000;
        private int counter, musicOffset, menuOffset = 12;
        private readonly Color textColor = Color.White;
        private readonly Game1 game;

        public InstructionScreen(Game1 game)
        {
            this.game = game;
            musicOffset = fourthOffset + 2;
            counter = 0;
            textList = GetText();
        }

        public void Update()
        {
            if (counter > mandatoryCreditsTimer)
            {
                counter = 0;
                textList = GetText();
                game.stateMachine.HandleInstructionToPrev();
                musicOffset = fourthOffset + 2;
                menuOffset = 12;

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

        private List<Text> GetText()
            => new List<Text> {
                new Text(game, messageIntro, new Vector2(xCoord, yCoord), textColor),
                new Text(game, messageLinkMovement, new Vector2(xCoord, yCoord*firstOffset), textColor),
                new Text(game, messageLinkSword, new Vector2(xCoord, yCoord*secondOffset), textColor),
                new Text(game, messageChangeSword, new Vector2(xCoord, yCoord*thirdOffset), textColor),
                new Text(game, messageBItem, new Vector2(xCoord, yCoord*fourthOffset), textColor),

                new Text(game, messageMusicControls, new Vector2(xCoord, yCoord*musicOffset++), textColor),
                new Text(game, messageSoundMute, new Vector2(xCoord, yCoord*musicOffset++), textColor),
                new Text(game, messageSoundEffectMute, new Vector2(xCoord, yCoord*musicOffset++), textColor),
                new Text(game, messageSoundChange, new Vector2(xCoord, yCoord*musicOffset++), textColor),

                new Text(game, messageMenu, new Vector2(xCoord, yCoord*menuOffset++), textColor),
                new Text(game, messageOptions, new Vector2(xCoord, yCoord*menuOffset++), textColor),
                new Text(game, messagePause, new Vector2(xCoord, yCoord*menuOffset++), textColor),
                new Text(game, messageTestMode, new Vector2(xCoord, yCoord*menuOffset++), textColor),
                new Text(game, messageSelectItem, new Vector2(xCoord, yCoord*menuOffset++), textColor),
                new Text(game, messageItemSelection, new Vector2(xCoord, yCoord*menuOffset++), textColor),
                new Text(game, messageQuit, new Vector2(xCoord, yCoord*menuOffset++), textColor),
                new Text(game, messageReset, new Vector2(xCoord, yCoord*menuOffset++), textColor),
                new Text(game, messageGoal, new Vector2(xCoord, yCoord*++menuOffset), textColor),
            };
    }
}
