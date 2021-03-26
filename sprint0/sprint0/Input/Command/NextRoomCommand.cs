﻿//Author: Stuti Shah
namespace sprint0
{
    internal class NextRoomCommand : ICommand
    {
        private readonly Game1 game;

        public NextRoomCommand(Game1 game)
        {
            this.game = game;
        }

        public void Execute()
        {
            if (game.TestMode)
            {
                game.RoomIndex = ((game.RoomIndex + 1) % game.NumRooms);
                game.ChangeRoom = true;
            }
        }
    }
}