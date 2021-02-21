// Author: Jacob Urick
namespace sprint0
{
    class TwoCommand : ICommand
    {
        private Game1 game;
        public TwoCommand(Game1 game)
        {
            this.game = game;
        }

        public void Execute()
        {
            game.Player.HandleTwo();
        }
    }
}
