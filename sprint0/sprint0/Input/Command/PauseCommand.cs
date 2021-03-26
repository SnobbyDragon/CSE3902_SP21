// Author: Stuti Shah
namespace sprint0
{
    class PauseCommand : ICommand
    {
        private readonly Game1 game;

        public PauseCommand(Game1 game)
        {
            this.game = game;
        }

        public void Execute()
        {
            game.PauseScreen = !game.PauseScreen;
        }
    }
}
