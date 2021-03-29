// Author: Jesse He
namespace sprint0
{
    class CreditsCommand : ICommand
    {
        private readonly Game1 game;

        public CreditsCommand(Game1 game)
        {
            this.game = game;
        }

        public void Execute()
        {
            game.stateMachine.HandleCredits();
        }
    }
}
