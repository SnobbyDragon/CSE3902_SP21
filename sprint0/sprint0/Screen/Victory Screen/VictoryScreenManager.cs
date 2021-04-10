using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

//Author: Jacob Urick
//Updated: 03/28/21 by urick.9
namespace sprint0
{
    public class VictoryScreenManager
    {
        private readonly VictoryScreen gameOverScreen;
        public VictoryScreenManager(Game1 game) => gameOverScreen = new VictoryScreen(game);
        public void Draw(SpriteBatch spriteBatch) => gameOverScreen.Draw(spriteBatch);
        public void Update() { } //Nothing yet, todo add buttons
    }
}
