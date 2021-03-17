// Author: Jesse He
namespace sprint0
{
    class FourCommand : ICommand
    {
        private readonly Game1 game;

        public FourCommand(Game1 game)
        {
            this.game = game;
        }

        public void Execute()
        {
            game.Room.Player.CurrentItem = PlayerItems.Candle;
            game.Room.Player.HandleItem();
        }
    }
}
