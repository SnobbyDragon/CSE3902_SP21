using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace sprint0
{
    public class ShutDoor : AbstractBorderFilling
    {
        public IBlock CollisionBox { get; }

        public ShutDoor(Texture2D texture, Vector2 location, Direction dir, Room room) : base(texture, location, dir, room)
        {
            xOffset = 914;
            yOffset = 11;
            GetSource();

            CollisionBox = game.Room.LoadLevel.RoomBlocks.AddBlock(location, BlockEnum.InvisibleBlock, size, size);
        }

        public void OpenDoor(bool openedByBlock)
        {
            int roomWithDoorOpenedByBlock = 5;
            if (openedByBlock || Room.Game.RoomIndex != roomWithDoorOpenedByBlock)
            {
                Room.LoadLevel.RoomBlocks.RemoveBlock(CollisionBox);
                Room.LoadLevel.RoomSprite.RemoveRoomSprite(this);
                Room.LoadLevel.RoomSprite.AddRoomSprite(new OpenDoor(Texture, Location.Location.ToVector2(), Side, Room));
            }
        }
    }
}
