// Author: Jacob Urick
namespace sprint0
{
    class ThreeCommand : ICommand
    {
        private readonly Game1 game;
        public ThreeCommand(Game1 game) => this.game = game;
        public void Execute()
        {
            game.stateMachine.HandleLevelSelectThree();

            if (CanUseBoomerang())
            {
                game.Room.Player.CurrentItem = PlayerItems.Boomerang;
                game.Room.Player.HandleItem();
            }
        }
        private bool CanUseBoomerang()
            => (game.hudManager.HasBoomerang() || game.stateMachine.GetState().Equals(GameStateMachine.State.test)) && game.Player.ItemCounts[(int)PlayerItems.Boomerang] != 0;
    }
}
