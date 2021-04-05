// Author: Stuti Shah
namespace sprint0
{
    class ToggleTestModeCommand : ICommand
    {
        private readonly Game1 game;

        public ToggleTestModeCommand(Game1 game)
        {
            this.game = game;
        }

        public void Execute()
        {
            game.stateMachine.HandleTest();

        }
    }
}
