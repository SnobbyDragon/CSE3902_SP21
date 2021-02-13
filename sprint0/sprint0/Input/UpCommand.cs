using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;

namespace sprint0
{
    class UpCommand : ICommand
    {
        private Game1 game;
        public UpCommand(Game1 game)
        {
            this.game = game;
        }

        public void Execute()
        {
            game.Player.State.HandleUp();
        }
    }
}
