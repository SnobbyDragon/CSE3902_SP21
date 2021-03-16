// Author: Jesse He
namespace sprint0
{
    class LeftCommand : ICommand
    {
        private readonly Game1 game;

        public LeftCommand(Game1 game)
        {
            this.game = game;
        }

        public void Execute()
        {
            game.Room.Player.HandleLeft();
        }
    }
}