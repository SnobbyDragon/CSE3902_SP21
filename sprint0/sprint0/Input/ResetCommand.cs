using System;
using System.Collections.Generic;
using System.Text;

namespace sprint0
{
    class ResetCommand : ICommand
    {
        Game1 game;
        public ResetCommand(Game1 game)
        {
            this.game = game;
        }
        public void Execute()
        {
            game.ResetElapsedTime();
        }
    }
}
