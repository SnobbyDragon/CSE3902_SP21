//Author: Stuti Shah
namespace sprint0
{
    internal class PreviousRoomCommand : ICommand
    {
        private readonly Game1 game;

        public PreviousRoomCommand(Game1 game)
        {
            this.game = game;
        }

        public void Execute()
        {
            if (game.stateMachine.GetState().Equals(GameStateMachine.State.test))
            {
               game.stateMachine.HandleSnapRoomChange((game.RoomIndex - 1 + game.NumRooms) % game.NumRooms);
                //game.stateMachine.HandleFinishRoomChange((game.RoomIndex - 1 + game.NumRooms) % game.NumRooms);
                /* game.RoomIndex = (game.RoomIndex - 1 + game.NumRooms) % game.NumRooms; */
                // game.ChangeRoom = true;
            }
        }
    }
}