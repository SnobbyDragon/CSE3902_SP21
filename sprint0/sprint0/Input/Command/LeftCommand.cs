// Author: Jesse He
namespace sprint0
{
    class LeftCommand : ICommand
    {
        private readonly Game1 game;

        public LeftCommand(Game1 game) => this.game = game;

        public void Execute()
        {
            if (game.stateMachine.GetState() != GameStateMachine.State.pause)
                game.Room.Player.HandleLeft();
        }
    }
}