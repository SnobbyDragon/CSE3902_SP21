using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace sprint0
{
    public class Wall : AbstractBorderFilling
    {
        public IBlock CollisionBox { get; }
        private readonly bool canBeBombed;

        public Wall(Texture2D texture, Vector2 location, Direction dir, Game1 game, bool canBeBombed) : base(texture, location, dir, game)
        {
            xOffset = 815;
            yOffset = 11;
            GetSource();
            CollisionBox = game.Room.LoadLevel.RoomBlocks.AddBlock(location, BlockEnum.InvisibleBlock, size, size);
            this.canBeBombed = canBeBombed;
        }

        public void BombWall()
        {
            if (canBeBombed)
            {
                Game.Room.LoadLevel.RoomBlocks.RemoveBlock(CollisionBox);
                Game.Room.LoadLevel.RoomSprite.RemoveRoomSprite(this);
                Game.Room.LoadLevel.RoomSprite.AddRoomSprite(new BombedOpening(Texture, Location.Location.ToVector2(), Side, Game));
            }
        }
    }
}
