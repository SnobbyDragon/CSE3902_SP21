using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace sprint0
{
    public class LockedDoor : AbstractBorderFilling
    {
        public IBlock CollisionBox { get; }

        public LockedDoor(Texture2D texture, Vector2 location, Direction dir, Room room) : base(texture, location, dir, room)
        {
            xOffset = 881;
            yOffset = 11;
            GetSource();
            CollisionBox = Room.LoadLevel.RoomBlocks.AddBlock(location, "invisible block", size, size);
        }

        public void OpenDoor()
        {
            Room.LoadLevel.RoomBlocks.RemoveBlock(CollisionBox);
            Room.LoadLevel.RoomSprite.RemoveRoomSprite(this);
            Room.LoadLevel.RoomSprite.AddRoomSprite(new OpenDoor(Texture, Location.Location.ToVector2() - Room.Offset, Side, Room));
        }
    }
}
