// Author: Jesse He
namespace sprint0
{
    class FourCommand : ICommand
    {
        private readonly Game1 game;

        public FourCommand(Game1 game) => this.game = game;

        public void Execute()
        {
            if (CanUse())
            {
                game.Room.Player.CurrentItem = PlayerItems.BlueCandle;
                game.Room.Player.HandleItem();
            }
        }

        private bool CanUse()
            => game.hudManager.HasItem(PlayerItems.BlueCandle) || game.hudManager.HasItem(PlayerItems.RedCandle) || game.stateMachine.GetState().Equals(GameStateMachine.State.test)
            || (game.hudManager.HasItem(PlayerItems.MagicalRod) && game.hudManager.HasItem(PlayerItems.BookOfMagic));
    }
}
