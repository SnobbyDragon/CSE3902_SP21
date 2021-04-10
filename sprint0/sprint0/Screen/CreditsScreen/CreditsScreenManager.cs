using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

//Author: Jacob Urick
//Updated: 03/28/21 by urick.9
namespace sprint0
{
    public class CreditsScreenManager
    {
        private readonly CreditsScreen creditsScreen;
        public CreditsScreenManager(Game1 game) => creditsScreen = new CreditsScreen(game);
        public void Draw(SpriteBatch spriteBatch) => creditsScreen.Draw(spriteBatch);
        public void Update() => creditsScreen.Update();
    }
}
