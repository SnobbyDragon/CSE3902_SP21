namespace sprint0
{
    class SwordCommand : ICommand
    {
        private readonly Game1 game;

        public SwordCommand(Game1 game)
        {
            this.game = game;
        }

        public void Execute()
        {
            if (game.hudManager.HasSword() || game.stateMachine.GetState().Equals(GameStateMachine.State.test)) //Take out TestMode when not needed
            {
                game.Room.Player.HandleSword();
            }
        }
    }
}