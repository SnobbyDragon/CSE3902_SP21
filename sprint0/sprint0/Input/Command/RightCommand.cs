// Author: Jesse He
namespace sprint0
{
    class RightCommand : ICommand
    {
        private readonly Game1 game;

        public RightCommand(Game1 game)
        {
            this.game = game;
        }

        public void Execute()
        {
            if (game.stateMachine.GetState() != GameStateMachine.State.pause)
                game.Room.Player.HandleRight();
        }
    }
}