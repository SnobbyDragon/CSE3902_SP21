//Author: Hannah Johnson
namespace sprint0
{
    class ResetCommand : ICommand
    {
        private readonly Game1 game;
        public ResetCommand(Game1 game) => this.game = game;
        public void Execute() => game.stateMachine.HandleRunItBack();
    }
}
