// Author: Jacob Urick
namespace sprint0
{
    class TwoCommand : ICommand
    {
        private readonly Game1 game;

        public TwoCommand(Game1 game)
        {
            this.game = game;
        }

        public void Execute()
        {
            if (game.hudManager.CanUseBomb() || game.stateMachine.getState().Equals(GameStateMachine.State.test)) //Take out TestMode when not needed
            {
                game.Room.Player.CurrentItem = PlayerItems.Bomb;
                game.Room.Player.HandleItem();
            }
        }
    }
}
