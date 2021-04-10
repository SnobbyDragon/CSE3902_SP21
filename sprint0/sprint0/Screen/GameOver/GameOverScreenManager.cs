using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

//Author: Jacob Urick
//Updated: 03/28/21 by urick.9
namespace sprint0
{
    public class GameOverScreenManager
    {
        private readonly GameOverScreen gameOverScreen;
        public GameOverScreenManager(Game1 game) => gameOverScreen = new GameOverScreen(game);
        public void Draw(SpriteBatch spriteBatch) => gameOverScreen.Draw(spriteBatch);
        public void Update() { } //Nothing yet, todo add buttons
    }
}
