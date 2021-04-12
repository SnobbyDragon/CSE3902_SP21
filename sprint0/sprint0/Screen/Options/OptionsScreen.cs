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
        private List<Text> textList;
        private readonly int xCoord = 25;
        private readonly int yCoord = 100;
        private int yCoord1 = 150;
        private int yCoord2 = 200;
        private readonly Game1 game;
        private string speed;
        public OptionsScreen(Game1 game)
        {
            this.game = game;
            BuildSpeed();
            textList = new List<Text> {
                new Text(game, message0, new Vector2(xCoord, yCoord), Color.Black),
                new Text(game, message1, new Vector2(xCoord, yCoord1), Color.Black),
                new Text(game, message2 + speed, new Vector2(xCoord, yCoord2), Color.Black),

            };
        }

        private void BuildSpeed() {
            speed = "";
            int sp = game.ScrollSpeed;
            for (int i = 0; i < sp; i++) {
                speed += "#";
            }
            for (int i = 0; i < game.scrollSpeedUbound - sp ; i++)
            {
                speed += "=";
            }
        }
    
    public void Update()
        {
            BuildSpeed();
            textList = new List<Text> {
                new Text(game, message0, new Vector2(xCoord, yCoord), Color.Black),
                new Text(game, message2, new Vector2(xCoord, yCoord1), Color.Black),
                new Text(game, message1 + speed, new Vector2(xCoord, yCoord2), Color.Black),

            };
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (Text text in textList)
                text.Draw(spriteBatch);
        }
    }
  
}
