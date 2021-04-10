namespace sprint0
{
    class SwordCommand : ICommand
    {
        private readonly Game1 game;
        public SwordCommand(Game1 game) => this.game = game;
        public void Execute()
        {
            if (CanUse())
                game.Room.Player.HandleSword();
        }

        private bool CanUse()
            => game.hudManager.HasSword() || game.stateMachine.GetState().Equals(GameStateMachine.State.test) || game.hudManager.HasItem(PlayerItems.MagicalRod);
    }
}