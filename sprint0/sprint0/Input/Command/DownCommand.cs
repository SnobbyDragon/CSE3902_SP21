﻿namespace sprint0
{
    class DownCommand : ICommand
    {
        private Game1 game;
        public DownCommand(Game1 game)
        {
            this.game = game;
        }

        public void Execute()
        {
            game.Player.HandleDown();
        }
    }
}