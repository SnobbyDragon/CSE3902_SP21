using System;
//Author: Stuti Shah
namespace sprint0
{
    class OpeningCommand : ICommand
    {
        private readonly Game1 game;
        public OpeningCommand(Game1 game) => this.game = game;
        public void Execute() => game.stateMachine.HandleStart();
    }
}

