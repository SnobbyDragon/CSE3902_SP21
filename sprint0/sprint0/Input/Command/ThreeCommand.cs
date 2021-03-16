// Author: Jacob Urick
namespace sprint0
{
    class ThreeCommand : ICommand
    {
        private readonly Game1 game;

        public ThreeCommand(Game1 game)
        {
            this.game = game;
        }

        public void Execute()
        {
            game.Room.Player.CurrentItem = PlayerItems.Boomerang;
            game.Room.Player.HandleItem();
        }
    }
}
