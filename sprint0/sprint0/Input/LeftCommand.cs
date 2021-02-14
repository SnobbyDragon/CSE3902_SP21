namespace sprint0
{
    class LeftCommand : ICommand
    {
        private Game1 game;
        public LeftCommand(Game1 game)
        {
            this.game = game;
        }

        public void Execute()
        {
            game.Player.State.HandleLeft();
        }
    }
}