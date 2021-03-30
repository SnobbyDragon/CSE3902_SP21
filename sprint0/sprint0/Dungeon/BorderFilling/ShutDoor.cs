using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace sprint0
{
    public class ShutDoor : AbstractBorderFilling
    {
        public IBlock CollisionBox { get; }

        public ShutDoor(Texture2D texture, Vector2 location, Direction dir, Game1 game) : base(texture, location, dir, game)
        {
            xOffset = 914;
            yOffset = 11;
            GetSource();
            CollisionBox = game.Room.LoadLevel.RoomBlocks.AddBlock(location, "invisible block", size, size);
        }
    }
}
