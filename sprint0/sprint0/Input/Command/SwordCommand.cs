namespace sprint0
{
    class SwordCommand : ICommand
    {
        private readonly Game1 game;

        public SwordCommand(Game1 game)
        {
            this.game = game;
        }

        public void Execute()
        {
            game.Room.Player.HandleSword();
        }
    }
}