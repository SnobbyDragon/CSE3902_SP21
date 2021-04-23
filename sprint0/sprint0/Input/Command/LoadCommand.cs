using System;
namespace sprint0
{
    public class LoadCommand : ICommand
    {
        private readonly Game1 game;

        public LoadCommand(Game1 game) => this.game = game;

        public void Execute() => game.stateMachine.HandleLevelSelectLoad();
    }
}
