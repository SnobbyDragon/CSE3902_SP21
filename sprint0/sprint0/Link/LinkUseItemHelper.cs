using Microsoft.Xna.Framework;
using System.Collections.Generic;
namespace sprint0
{
    public class LinkUseItemHelper
    {
        private readonly Game1 game;
        private readonly IPlayer link;
        private readonly int linkSize = 16;
        private HUDManager HUD;
        private readonly Dictionary<Direction, Vector2> swordOffsets = new Dictionary<Direction, Vector2>()
            {
                { Direction.North, new Vector2(8, -16) }, { Direction.South, new Vector2(12, 16) }, {Direction.East, new Vector2(16, 15) }, {Direction.West, new Vector2(-12, 15) }
            };
        private readonly Dictionary<Direction, Vector2> arrowOffsets = new Dictionary<Direction, Vector2>()
            {
                { Direction.North, new Vector2(6, -11) }, { Direction.South, new Vector2(6, 16) }, {Direction.East, new Vector2(16, 0) }, {Direction.West, new Vector2(0, 0) }
            };
        private readonly Dictionary<Direction, Vector2> boomerangOffsets = new Dictionary<Direction, Vector2>()
            {
                { Direction.North, new Vector2(3, 0) }, { Direction.South, new Vector2(5, 16) }, {Direction.East, new Vector2(16, 6) },  {Direction.West, new Vector2(0, 6) }
            };
        private readonly Dictionary<Direction, Vector2> bombOffsets = new Dictionary<Direction, Vector2>()
            {
                { Direction.North, new Vector2(3, -16) }, { Direction.South, new Vector2(5, 16) }, {Direction.East, new Vector2(16, 0) },  {Direction.West, new Vector2(-10, 0) }
            };

        public LinkUseItemHelper(Game1 game, IPlayer link, HUDManager HUD)
        {
            this.game = game;
            this.link = link;
            this.HUD = HUD;
        }

        public void UseSword(bool beam)
        {
            Vector2 offsetPos = link.Pos + swordOffsets[link.Direction];
            game.Room.LoadLevel.RoomWeapon.AddWeapon(offsetPos, link.Direction, WeaponEnum.Sword, link);
            game.Room.RoomSound.AddSoundEffect(SoundEnum.SwordSlash);
            if (beam || HUD.HasItem(PlayerItems.MagicalRod))
            {
                game.Room.LoadLevel.RoomProjectile.AddProjectile(offsetPos, link.Direction, ProjectileEnum.SwordBeam, link);
                game.Room.RoomSound.AddSoundEffect(SoundEnum.SwordShoot);
            }
        }

        public void UseItem()
        {
            HUD.Decrement(link.CurrentItem);
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
                case PlayerItems.MagicalRod:
                    UseCandle();
                    break;
            }
        }

        private void UseArrow()
        {
            Vector2 offsetPos = link.Pos + arrowOffsets[link.Direction];
            game.Room.LoadLevel.RoomProjectile.AddProjectile(offsetPos, link.Direction, ProjectileEnum.Arrow, link);
            game.Room.RoomSound.AddSoundEffect(SoundEnum.Arrow);
        }

        private void UseBomb()
        {
            Vector2 offsetPos = link.Pos + bombOffsets[link.Direction];
            game.Room.LoadLevel.RoomWeapon.AddWeapon(offsetPos, link.Direction, WeaponEnum.Bomb, link);
            game.Room.RoomSound.AddSoundEffect(SoundEnum.UseBomb);
        }

        private void UseBoomerang()
        {
            Vector2 offsetPos = link.Pos + boomerangOffsets[link.Direction];
            game.Room.LoadLevel.RoomProjectile.AddProjectile(offsetPos, link.Direction, ProjectileEnum.Boomerang, link);
            game.Room.RoomSound.AddSoundEffect(SoundEnum.Boomerang);
        }

        private void UseCandle()
        {
            Vector2 offsetPos = link.Pos + linkSize * link.Direction.ToVector2();
            game.Room.LoadLevel.RoomProjectile.AddProjectile(offsetPos, link.Direction, ProjectileEnum.Flame, link);
            game.Room.RoomSound.AddSoundEffect(SoundEnum.Candle);
        }
    }
}