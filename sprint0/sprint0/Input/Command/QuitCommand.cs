// Author: Jesse He
namespace sprint0
{
    class QuitCommand : ICommand
    {
        Game1 game;
        public QuitCommand(Game1 game)
        {
            this.game = game;
        }
        public void Execute()
        {
            game.Exit();
        }
    }
}
