namespace sprint0
{
    internal class EnemyNPCPreviousSpriteCommand : ICommand
    {
        private Game1 game;
        public EnemyNPCPreviousSpriteCommand(Game1 game)
        {
            this.game = game;
        }

        public void Execute()
        {
            game.enemyNPCIndex = ((game.enemyNPCIndex - 1) + game.enemyNPCSprites.Count) % game.enemyNPCSprites.Count;
        }
    }
}