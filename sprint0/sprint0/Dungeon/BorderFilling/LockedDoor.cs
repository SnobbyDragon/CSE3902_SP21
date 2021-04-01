﻿using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace sprint0
{
    public class LockedDoor : AbstractBorderFilling
    {
        public IBlock CollisionBox { get; }

        public LockedDoor(Texture2D texture, Vector2 location, Direction dir, Game1 game) : base(texture, location, dir, game)
        {
            xOffset = 881;
            yOffset = 11;
            GetSource();
            CollisionBox = game.Room.LoadLevel.RoomBlocks.AddBlock(location, "invisible block", size, size);
        }

        public void OpenDoor()
        {
            game.Room.LoadLevel.RoomBlocks.RemoveBlock(CollisionBox);
            // TODO switch this into an open door
        }
    }
}