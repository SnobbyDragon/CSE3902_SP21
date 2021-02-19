// Author: Jesse He
namespace sprint0
{
    class ThreeCommand : ICommand
    {
        private Game1 game;
        public ThreeCommand(Game1 game)
        {
            this.game = game;
        }

        public void Execute()
        {
            game.Player.HandleThree();
        }
    }
}