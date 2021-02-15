namespace sprint0
{
    internal class ItemPreviousSpriteCommand : ICommand
    {
        private Game1 game;
        public ItemPreviousSpriteCommand(Game1 game)
        {
            this.game = game;
        }

        public void Execute()
        {
            game.itemIndex = ((game.itemIndex - 1) + game.itemSprites.Count) % game.itemSprites.Count;
        }
    }
}