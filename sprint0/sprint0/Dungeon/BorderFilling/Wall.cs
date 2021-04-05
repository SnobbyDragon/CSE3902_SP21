using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace sprint0
{
    public class Wall : AbstractBorderFilling
    {
        public IBlock CollisionBox { get; }
        public bool CanBeBombed { get; }

        public Wall(Texture2D texture, Vector2 location, Direction dir, Room room, bool canBeBombed) : base(texture, location, dir, room)
        {
            xOffset = 815;
            yOffset = 11;
            GetSource();

            CollisionBox = Room.LoadLevel.RoomBlocks.AddBlock(location, BlockEnum.InvisibleBlock, size, size);
            CanBeBombed = canBeBombed;
        }

        public void BombWall()
        {
            Room.LoadLevel.RoomBlocks.RemoveBlock(CollisionBox);
            Room.LoadLevel.RoomSprite.RemoveRoomSprite(this);
            Room.LoadLevel.RoomSprite.AddRoomSprite(new BombedOpening(Texture, Location.Location.ToVector2(), Side, Room));
        }
    }
}
