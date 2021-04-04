using Microsoft.Xna.Framework;
using System.Collections.Generic;
// Updated: 04/01/21 by he.1528
namespace sprint0
{
    class LinkUseItemHelper
    {
        private readonly Game1 game;
        private readonly IPlayer link;
        private readonly int linkSize = 16;
        private readonly Dictionary<Direction, Vector2> swordOffsets = new Dictionary<Direction, Vector2>()
            {
                { Direction.n, new Vector2(8, 0) }, { Direction.s, new Vector2(12, 16) }, {Direction.e, new Vector2(Game1.BorderThickness, 15) }, {Direction.w, new Vector2(0, 15) }
            };
        private readonly Dictionary<Direction, Vector2> arrowOffsets = new Dictionary<Direction, Vector2>()
            {
                { Direction.n, new Vector2(6, -11) }, { Direction.s, new Vector2(6, 16) }, {Direction.e, new Vector2(16, 0) }, {Direction.w, new Vector2(0, 0) }
            };
        private readonly Dictionary<Direction, Vector2> boomerangOffsets = new Dictionary<Direction, Vector2>()
            {
                { Direction.n, new Vector2(3, 0) }, { Direction.s, new Vector2(5, 16) }, {Direction.e, new Vector2(16, 6) },  {Direction.w, new Vector2(0, 6) }
            };
        private readonly Dictionary<Direction, Vector2> bombOffsets = new Dictionary<Direction, Vector2>()
            {
                { Direction.n, new Vector2(3, -16) }, { Direction.s, new Vector2(5, 16) }, {Direction.e, new Vector2(16, 0) },  {Direction.w, new Vector2(-10, 0) }
            };

        public LinkUseItemHelper(Game1 game, IPlayer link)
        {
            this.game = game;
            this.link = link;
        }

        public void UseSword(bool beam)
        {
            link.State.HandleSword();
            Vector2 offsetPos = link.Pos + swordOffsets[link.Direction];
            game.Room.LoadLevel.RoomWeapon.AddWeapon(offsetPos, link.Direction, "sword", link);
            game.Room.RoomSound.AddSoundEffect("sword slash");
            if (beam)
            {
                game.Room.LoadLevel.RoomProjectile.AddProjectile(offsetPos, link.Direction, "sword beam", link);
                game.Room.RoomSound.AddSoundEffect("sword shoot");
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
            Vector2 offsetPos = link.Pos + arrowOffsets[link.Direction];
            game.Room.LoadLevel.RoomProjectile.AddProjectile(offsetPos, link.Direction, "arrow", link);
            game.Room.RoomSound.AddSoundEffect("arrow");
        }

        private void UseBomb()
        {
            Vector2 offsetPos = link.Pos + bombOffsets[link.Direction];
            game.Room.LoadLevel.RoomWeapon.AddWeapon(offsetPos, link.Direction, "bomb", link);
            game.Room.RoomSound.AddSoundEffect("use bomb");
        }

        private void UseBoomerang()
        {
            Vector2 offsetPos = link.Pos + boomerangOffsets[link.Direction];
            game.Room.LoadLevel.RoomProjectile.AddProjectile(offsetPos, link.Direction, "boomerang", link);
            game.Room.RoomSound.AddSoundEffect("boomerang");
        }

        private void UseCandle()
        {
            Vector2 offsetPos = link.Pos + linkSize * link.Direction.ToVector2();
            game.Room.LoadLevel.RoomProjectile.AddProjectile(offsetPos, link.Direction, "flame", link);
            game.Room.RoomSound.AddSoundEffect("candle");
        }
    }
}