using System;
using Microsoft.Xna.Framework.Graphics;
//Author: Stuti Shah
namespace sprint0
{
    public class OpeningScreenManager
    {
        private readonly OpeningScreen openingScreen;
        public OpeningScreenManager(Game1 game, Texture2D texture) => openingScreen = new OpeningScreen(game, texture);
        public void Draw(SpriteBatch spriteBatch) => openingScreen.Draw(spriteBatch);
        public void Update() => openingScreen.Update();
    }
}
