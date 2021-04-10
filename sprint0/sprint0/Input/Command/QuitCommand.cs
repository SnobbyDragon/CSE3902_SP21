// Author: Jesse He
namespace sprint0
{
    class QuitCommand : ICommand
    {
        private readonly Game1 game;
        public QuitCommand(Game1 game) => this.game = game;
        public void Execute() => game.Exit();
    }
}
