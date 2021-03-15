// Author: Jacob Urick
namespace sprint0
{
    class OneCommand : ICommand
    {
        private Game1 game;
        public OneCommand(Game1 game)
        {
            this.game = game;
        }

        public void Execute()
        {
            game.Player.CurrentItem = PlayerItems.Arrow;
            game.Player.HandleItem();
        }
    }
}
