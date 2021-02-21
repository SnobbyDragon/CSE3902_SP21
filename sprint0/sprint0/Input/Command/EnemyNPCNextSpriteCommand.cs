//Author: Stuti Shah
namespace sprint0
{
    internal class EnemyNPCNextSpriteCommand : ICommand
    {
        private Game1 game;
        public EnemyNPCNextSpriteCommand(Game1 game)
        {
            this.game = game;
        }

        public void Execute()
        {
            //go to next sprite
            game.enemyNPCIndex = (game.enemyNPCIndex + 1) % game.enemyNPCSprites.Count;
        }
    }
}