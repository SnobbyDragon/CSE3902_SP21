// Author: Jacob Urick
namespace sprint0
{
    class StartCommand : ICommand
    {
        private readonly Game1 game;
        public StartCommand(Game1 game) => this.game = game;
        public void Execute() => game.stateMachine.HandlePlay();
    }
}
