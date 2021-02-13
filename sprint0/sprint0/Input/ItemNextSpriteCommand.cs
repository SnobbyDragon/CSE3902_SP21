namespace sprint0
{
    internal class ItemNextSpriteCommand : ICommand
    {
        private Game1 game;
        public ItemNextSpriteCommand(Game1 game)
        {
            this.game = game;
        }

        public void Execute()
        {
            game.itemIndex = (game.itemIndex + 1) % game.itemSprites.Count;
        }
    }
}