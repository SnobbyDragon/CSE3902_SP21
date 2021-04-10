// Author: Stuti Shah
namespace sprint0
{
    class LeftItemCommand : ICommand
    {
        private readonly Game1 game;

        public LeftItemCommand(Game1 game) => this.game = game;

        public void Execute()
        {
            if (game.stateMachine.GetState() == GameStateMachine.State.pause)
                game.universalScreenManager.PauseScreenManager.HandleLeft();
        }
    }
}