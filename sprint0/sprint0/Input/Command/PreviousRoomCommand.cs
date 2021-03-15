﻿//Author: Stuti Shah
namespace sprint0
{
    internal class PreviousRoomCommand : ICommand
    {
        private Game1 game;
        public PreviousRoomCommand(Game1 game)
        {
            this.game = game;
        }

        public void Execute()
        {
            game.roomIndex = (game.roomIndex - 1 + game.NumRooms) % game.NumRooms;
            game.ChangeRoom = true;
        }
    }
}