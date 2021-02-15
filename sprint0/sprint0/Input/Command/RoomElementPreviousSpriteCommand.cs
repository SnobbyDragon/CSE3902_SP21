namespace sprint0
{
    internal class RoomElementPreviousSpriteCommand : ICommand
    {
        private Game1 game;
        public RoomElementPreviousSpriteCommand(Game1 game)
        {
            this.game = game;
        }

        public void Execute()
        {
            game.roomElementsIndex = ((game.roomElementsIndex - 1) + game.roomElementsSprites.Count) % game.roomElementsSprites.Count;
        }
    }
}