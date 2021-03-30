// Author: Jacob Urick
namespace sprint0
{
    class ThreeCommand : ICommand
    {
        private readonly Game1 game;

        public ThreeCommand(Game1 game)
        {
            this.game = game;
        }

        public void Execute()
        {
            if (game.hudManager.HasBoomerang() || game.stateMachine.GetState().Equals(GameStateMachine.State.test)) //Take out TestMode when not needed
            {
                game.Room.Player.CurrentItem = PlayerItems.Boomerang;
                game.Room.Player.HandleItem();
            }
        }
    }
}
