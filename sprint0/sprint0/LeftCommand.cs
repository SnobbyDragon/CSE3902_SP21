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
            game.Player.State = new LeftIdleState(game.PlayerFactory.MakeSprite("link left idle", game.Player.Position));
        }
    }
}