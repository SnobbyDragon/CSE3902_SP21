using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

//Author: Jacob Urick
//Updated: 03/28/21 by urick.9
namespace sprint0
{
    public class StartScreenManager
    {
        private readonly StartScreen startScreen;
        public StartScreenManager(Game1 game) => startScreen = new StartScreen(game);
        public void Draw(SpriteBatch spriteBatch) => startScreen.Draw(spriteBatch);
        public void Update() => startScreen.Update();
    }
}
