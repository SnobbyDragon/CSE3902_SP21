using System;
//Author: Stuti Shah
namespace sprint0
{
    class InstructionCommand : ICommand
    {
        private readonly Game1 game;
        public InstructionCommand(Game1 game) => this.game = game;
        public void Execute() => game.stateMachine.HandleInstructions();
    }
}

