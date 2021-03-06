﻿// Author: Jesse He
namespace sprint0
{
    class UpCommand : ICommand
    {
        private readonly Game1 game;
        public UpCommand(Game1 game) => this.game = game;
        public void Execute() => game.Room.Player.HandleUp();
    }
}
