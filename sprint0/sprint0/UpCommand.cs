using System;
using System.Collections.Generic;
using System.Text;

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
            game.Player.State = new UpIdleState(game.PlayerFactory.MakeSprite("link up idle", game.Player.Position));
        }
    }
}
