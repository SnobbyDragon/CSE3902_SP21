using System;
using Microsoft.Xna.Framework.Graphics;

namespace sprint0
{
    public class InstructionScreenManager
    {
        private readonly InstructionScreen instructionScreen;
        public InstructionScreenManager(Game1 game) => instructionScreen = new InstructionScreen(game);
        public void Draw(SpriteBatch spriteBatch) => instructionScreen.Draw(spriteBatch);
        public void Update() => instructionScreen.Update();
    }
}
