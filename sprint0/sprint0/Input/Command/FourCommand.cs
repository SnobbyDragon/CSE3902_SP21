// Author: Jesse He
namespace sprint0
{
    class FourCommand : ICommand
    {
        private Game1 game;
        public FourCommand(Game1 game)
        {
            this.game = game;
        }

        public void Execute()
        {
            game.Player.CurrentItem = PlayerItems.Candle;
            game.Player.HandleItem();
        }
    }
}
