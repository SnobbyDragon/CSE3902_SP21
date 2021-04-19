namespace sprint0
{
    public class FluteCommand : ICommand
    {
        private readonly Game1 game;
        public FluteCommand(Game1 game) => this.game = game;
        public void Execute() => game.Room.LoadLevel.RoomEnemies.ChangeDigdoggerSize();
    }
}
