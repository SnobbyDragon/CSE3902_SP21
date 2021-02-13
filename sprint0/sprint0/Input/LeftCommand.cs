namespace sprint0
{
    internal class LeftCommand : ICommand
    {
        private Game1 game;
        public LeftCommand(Game1 game)
        {
            this.game = game;
        }

        public void Execute()
        {
            // temp no-op
        }
    }
}