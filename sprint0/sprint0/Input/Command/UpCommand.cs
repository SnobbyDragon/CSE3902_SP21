// Author: Jesse He
namespace sprint0
{
    class UpCommand : ICommand
    {
        private Game1 game;
        public UpCommand(Game1 game)
        {
            this.game = game;
        }

        public void Execute()
        {
            game.Player.HandleUp();
        }
    }
}
