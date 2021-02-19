// Author: Jesse He
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
            game.Player.HandleOne();
        }
    }
}