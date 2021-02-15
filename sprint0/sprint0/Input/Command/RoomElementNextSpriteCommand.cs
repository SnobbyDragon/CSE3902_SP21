namespace sprint0
{
    internal class RoomElementNextSpriteCommand : ICommand
    {
        private Game1 game;
        public RoomElementNextSpriteCommand(Game1 game)
        {
            this.game = game;
        }

        public void Execute()
        {
            game.roomElementsIndex = (game.roomElementsIndex + 1) % game.roomElementsSprites.Count;
        }
    }
}