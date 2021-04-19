// Author: Hannah Johnson
namespace sprint0
{
    class FairyEnlargementCommand : ICommand
    {
        private readonly Game1 game;
        public FairyEnlargementCommand(Game1 game) => this.game = game;
        public void Execute()
        {
            int roomWithFairyEnemy = 21;
            if(game.Room.RoomIndex==roomWithFairyEnemy)
                game.Room.LoadLevel.RoomEnemies.MakeFairyLarge();
        }
    }
}
