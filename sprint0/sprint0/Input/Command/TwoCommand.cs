// Author: Jacob Urick
namespace sprint0
{
    class TwoCommand : ICommand
    {
        private readonly Game1 game;
        public TwoCommand(Game1 game) => this.game = game;
        public void Execute()
        {
            game.stateMachine.HandleLevelSelectTwo();

            if (game.hudManager.CanUseBomb() || game.stateMachine.GetState().Equals(GameStateMachine.State.test)) //Take out TestMode when not needed
            {
                game.Room.Player.CurrentItem = PlayerItems.Bomb;
                game.Room.Player.HandleItem();
                game.hudManager.RemoveBomb();
            }
        }
    }
}
