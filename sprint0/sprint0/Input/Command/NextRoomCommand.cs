//Author: Stuti Shah
namespace sprint0
{
    internal class NextRoomCommand : ICommand
    {
        private Game1 game;
        public NextRoomCommand(Game1 game)
        {
            this.game = game;
        }

        public void Execute()
        {
            game.roomIndex = ((game.roomIndex + 1) % 17);
            game.changeRoom = true;
        }
    }
}