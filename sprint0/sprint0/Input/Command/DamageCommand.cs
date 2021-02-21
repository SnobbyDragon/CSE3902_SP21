// Author: Jesse He
namespace sprint0
{
    class DamageCommand : ICommand
    {
        private Game1 game;

        public DamageCommand(Game1 game)
        {
            this.game = game;
        }

        public void Execute()
        {
            game.Player.TakeDamage(Direction.e); // Link gets damaged from the right for now
        }
    }
}