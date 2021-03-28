using Microsoft.Xna.Framework;
using System.Collections.Generic;
// Updated: 3/28/21 by he.1528
namespace sprint0
{
    class LinkUseItemHelper
    {
        private readonly Room room;
        private readonly IPlayer link;
        private readonly List<Vector2> swordOffsets;
        private readonly List<Vector2> arrowOffsets;
        private readonly List<Vector2> boomerangOffsets;
        private readonly List<Vector2> bombOffsets;

        public LinkUseItemHelper(Room room, IPlayer link)
        {
            this.room = room;
            this.link = link;
            swordOffsets = new List<Vector2>()
            {
                new Vector2(8, 0), new Vector2(12, 16), new Vector2(Game1.BorderThickness, 15), new Vector2(0, 15)
            };
            arrowOffsets = new List<Vector2>()
            {
                new Vector2(6, -11), new Vector2(6, 16), new Vector2(16, 0), new Vector2(0, 0)
            };
            boomerangOffsets = new List<Vector2>()
            {
                new Vector2(3, 0), new Vector2(5, 16), new Vector2(16, 6), new Vector2(0, 6),
            };
            bombOffsets = new List<Vector2>()
            {
                new Vector2(3, -16), new Vector2(5, 16), new Vector2(16, 0), new Vector2(-10, 0)
            };
        }

        public void UseSword(bool beam)
        {
            link.State.HandleSword();
            Vector2 offsetPos = link.Pos + swordOffsets[(int)link.Direction];
            room.LoadLevel.RoomWeapon.AddWeapon(offsetPos, link.Direction, "sword", link);
            room.RoomSound.AddSoundEffect("sword slash");
            if (beam)
            {
                room.LoadLevel.RoomProjectile.AddProjectile(offsetPos, link.Direction, "sword beam", link);
                room.RoomSound.AddSoundEffect("sword shoot");
            }
        }

        public void UseItem()
        {
            link.State.UseItem();
            switch (link.CurrentItem)
            {
                case PlayerItems.Arrow:
                    UseArrow();
                    break;
                case PlayerItems.Bomb:
                    UseBomb();
                    break;
                case PlayerItems.Boomerang:
                    UseBoomerang();
                    break;
                case PlayerItems.BlueCandle:
                    UseCandle();
                    break;
            }
        }

        private void UseArrow()
        {
            Vector2 offsetPos = link.Pos + arrowOffsets[(int)link.Direction];
            room.LoadLevel.RoomProjectile.AddProjectile(offsetPos, link.Direction, "arrow", link);
            room.RoomSound.AddSoundEffect("arrow");
        }

        private void UseBomb()
        {
            Vector2 offsetPos = link.Pos + bombOffsets[(int)link.Direction];
            room.LoadLevel.RoomWeapon.AddWeapon(offsetPos, link.Direction, "bomb", link);
            room.RoomSound.AddSoundEffect("use bomb");
        }

        private void UseBoomerang()
        {
            Vector2 offsetPos = link.Pos + boomerangOffsets[(int)link.Direction];
            room.LoadLevel.RoomProjectile.AddProjectile(offsetPos, link.Direction, "boomerang", link);
            room.RoomSound.AddSoundEffect("boomerang");
        }

        private void UseCandle()
        {
            Vector2 offsetPos = link.Pos + 16 * link.Direction.ToVector2();
            room.LoadLevel.RoomProjectile.AddProjectile(offsetPos, link.Direction, "flame", link);
            room.RoomSound.AddSoundEffect("candle");
        }
    }
}