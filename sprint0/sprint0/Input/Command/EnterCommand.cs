// Author: Jesse He
namespace sprint0
{
    class EnterCommand : ICommand
    {
        private readonly Game1 game;

        public EnterCommand(Game1 game)
        {
            this.game = game;
        }

        public void Execute()
        {
            game.stateMachine.HandleCredits();
        }
    }
}
