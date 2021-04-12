namespace sprint0
{
    class DownCommand : ICommand
    {
        private readonly Game1 game;

        public DownCommand(Game1 game) => this.game = game;

        public void Execute() => game.Room.Player.HandleDown();
    }
}