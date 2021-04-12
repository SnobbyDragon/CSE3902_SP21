using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

//Author: Jacob Urick
//Updated: 03/28/21 by urick.9
namespace sprint0
{
    public class OptionsScreenManager
    {
        private readonly OptionsScreen optionsScreen;
        public OptionsScreenManager(Game1 game) => optionsScreen = new OptionsScreen(game);
        public void Draw(SpriteBatch spriteBatch) => optionsScreen.Draw(spriteBatch);
        public void Update() => optionsScreen.Update();
    }
}
