namespace sprint0
{
    internal class DownCommand : ICommand
    {
        private Game1 game;
        public DownCommand(Game1 game)
        {
            this.game = game;
        }

        public void Execute()
        {
            // no-op
        }
    }
}