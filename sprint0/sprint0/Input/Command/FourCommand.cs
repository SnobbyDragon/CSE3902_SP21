// Author: Jesse He
namespace sprint0
{
    class FourCommand : ICommand
    {
        private readonly Game1 game;

        public FourCommand(Game1 game)
        {
            this.game = game;
        }

        public void Execute()
        {
            if (game.hudManager.HasBlueCandle() || game.stateMachine.getState().Equals(GameStateMachine.State.test)) //Take out TestMode when not needed
            {
                game.Room.Player.CurrentItem = PlayerItems.BlueCandle;
                game.Room.Player.HandleItem();
            }
        }
    }
}
