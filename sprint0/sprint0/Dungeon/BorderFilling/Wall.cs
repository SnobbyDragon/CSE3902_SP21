using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace sprint0
{
    public class Wall : AbstractBorderFilling
    {
        public IBlock CollisionBox { get; }

        public Wall(Texture2D texture, Vector2 location, Direction dir, Game1 game) : base(texture, location, dir, game)
        {
            xOffset = 815;
            yOffset = 11;
            GetSource();
            CollisionBox = game.Room.LoadLevel.RoomBlocks.AddBlock(location, "invisible block", size, size);
        }
    }
}
