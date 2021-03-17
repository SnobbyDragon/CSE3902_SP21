﻿// Author: Jesse He
namespace sprint0
{
    class RightCommand : ICommand
    {
        private readonly Game1 game;

        public RightCommand(Game1 game)
        {
            this.game = game;
        }

        public void Execute()
        {
            game.Room.Player.HandleRight();
        }
    }
}