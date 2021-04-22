namespace sprint0
{
    class JumpCommand : ICommand
    {
        private readonly Game1 game;
        public JumpCommand(Game1 game) => this.game = game;
        public void Execute() => game.Room.Player.HandleJump();
    }
}
