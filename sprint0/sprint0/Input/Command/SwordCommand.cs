namespace sprint0
{
    class SwordCommand : ICommand
    {
        private Game1 game;
        public SwordCommand(Game1 game)
        {
            this.game = game;
        }

        public void Execute()
        {
            game.Player.HandleSword();
        }
    }
}