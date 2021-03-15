using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;

//Author: Hannah Johnson

namespace sprint0
{
    class ResetCommand : ICommand
    {
        readonly Game1 game;
        public ResetCommand(Game1 game)
        {
            this.game = game;
        }

        public void Execute()
        {
            game.ResetGame();
        }
    }
}
