// Author: Hannah Johnson
namespace sprint0
{
    class OwlDeathCommand : ICommand
    {
        private readonly Game1 game;
        public OwlDeathCommand(Game1 game) => this.game = game;
        public void Execute()
        {
            int roomWithOwl = 19;
            if(game.Room.RoomIndex==roomWithOwl)
                game.Room.LoadLevel.RoomEnemies.KillOwl();
        }
    }
}
