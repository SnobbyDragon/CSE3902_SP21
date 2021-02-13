namespace sprint0
{
    internal class RightCommand : ICommand
    {
        private Game1 game;
        public RightCommand(Game1 game)
        {
            this.game = game;
        }

        public void Execute()
        {
            // temp no-op
        }
    }
}