// Author: Jesse He
namespace sprint0
{
    class LeftCommand : ICommand
    {
        private readonly Game1 game;

        public LeftCommand(Game1 game) => this.game = game;

        public void Execute()
        {
            if (game.stateMachine.GetState() == GameStateMachine.State.play || game.stateMachine.GetState() == GameStateMachine.State.test)
                game.Room.Player.HandleLeft();
            else if (game.stateMachine.GetState() == GameStateMachine.State.options)
            {
                game.UpdateScrollSpeed(false);
            }
        }
}
}