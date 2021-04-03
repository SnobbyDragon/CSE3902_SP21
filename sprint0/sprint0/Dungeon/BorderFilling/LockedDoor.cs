using System;
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
            Game.Room.LoadLevel.RoomBlocks.RemoveBlock(CollisionBox);
            Game.Room.LoadLevel.RoomSprite.RemoveRoomSprite(this);
            Game.Room.LoadLevel.RoomSprite.AddRoomSprite(new OpenDoor(Texture, Location.Location.ToVector2(), Side, Game));
        }
    }
}
