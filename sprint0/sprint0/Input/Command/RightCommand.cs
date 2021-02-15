namespace sprint0
{
    class RightCommand : ICommand
    {
        private Game1 game;
        public RightCommand(Game1 game)
        {
            this.game = game;
        }

        public void Execute()
        {
            game.Player.State.HandleRight();
        }
    }
}