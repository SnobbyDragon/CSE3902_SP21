
namespace sprint0
{
    class OptionsCommand : ICommand
    {
        private readonly Game1 game;

        public OptionsCommand(Game1 game) => this.game = game;

        public void Execute() => game.stateMachine.HandleOptions();
    }
}
