namespace sprint0
{
    class StartGameCommand : ICommand
    {
        private readonly Game1 game;

        public StartGameCommand(Game1 game)
        {
            this.game = game;
        }

        public void Execute()
        {
            game.stateMachine.HandlePlay();

        }
    }
}
