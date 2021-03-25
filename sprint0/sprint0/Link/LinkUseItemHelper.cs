using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace sprint0
{
    class LinkUseItemHelper
    {
        private readonly Room room;
        private readonly IPlayer link;

        public LinkUseItemHelper(Room room, IPlayer link)
        {
            this.room = room;
            this.link = link;
        }

        public void UseSword(bool beam)
        {
            link.State.HandleSword();
            Vector2 offsetPos = link.Pos;
            switch (link.Direction)
            {
                case Direction.n:
                    offsetPos = new Vector2(link.Pos.X + 8, link.Pos.Y);
                    break;
                case Direction.s:
                    offsetPos = new Vector2(link.Pos.X + 12, link.Pos.Y + 16);
                    break;
                case Direction.e:
                    offsetPos = new Vector2(link.Pos.X + Game1.BorderThickness, link.Pos.Y + 15);
                    break;
                case Direction.w:
                    offsetPos = new Vector2(link.Pos.X, link.Pos.Y + 15);
                    break;
            }
            room.AddWeapon(offsetPos, link.Direction, "sword", link);
            room.AddSoundEffect("sword slash");
            if (beam)
            {
                room.AddProjectile(offsetPos, link.Direction, "sword beam", link);
                room.AddSoundEffect("sword shoot");
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
            Vector2 offsetPos = link.Pos;
            switch (link.Direction)
            {
                case Direction.n:
                    offsetPos = new Vector2(link.Pos.X + 6, link.Pos.Y - 11);
                    break;
                case Direction.s:
                    offsetPos = new Vector2(link.Pos.X + 6, link.Pos.Y + 16);
                    break;
                case Direction.e:
                    offsetPos = new Vector2(link.Pos.X + 16, link.Pos.Y);
                    break;
                case Direction.w:
                    offsetPos = new Vector2(link.Pos.X, link.Pos.Y);
                    break;
            }
            room.AddProjectile(offsetPos, link.Direction, "arrow", link);
            room.AddSoundEffect("arrow");
        }

        private void UseBomb()
        {
            Vector2 offsetPos = link.Pos;
            switch (link.Direction)
            {
                case Direction.n:
                    offsetPos = new Vector2(link.Pos.X + 3, link.Pos.Y - 16);
                    break;
                case Direction.s:
                    offsetPos = new Vector2(link.Pos.X + 5, link.Pos.Y + 16);
                    break;
                case Direction.e:
                    offsetPos = new Vector2(link.Pos.X + 16, link.Pos.Y);
                    break;
                case Direction.w:
                    offsetPos = new Vector2(link.Pos.X - 10, link.Pos.Y);
                    break;
            }
            room.AddWeapon(offsetPos, link.Direction, "bomb", link);
            room.AddSoundEffect("use bomb");
        }

        private void UseBoomerang()
        {
            Vector2 offsetPos = link.Pos;
            switch (link.Direction)
            {
                case Direction.n:
                    offsetPos = new Vector2(link.Pos.X + 3, link.Pos.Y);
                    break;
                case Direction.s:
                    offsetPos = new Vector2(link.Pos.X + 5, link.Pos.Y + 16);
                    break;
                case Direction.e:
                    offsetPos = new Vector2(link.Pos.X + 16, link.Pos.Y + 6);
                    break;
                case Direction.w:
                    offsetPos = new Vector2(link.Pos.X, link.Pos.Y + 6);
                    break;
            }
            room.AddProjectile(offsetPos, link.Direction, "boomerang", link);
            room.AddSoundEffect("boomerang");
        }

        private void UseCandle()
        {
            Vector2 offsetPos = link.Pos + 16 * link.Direction.ToVector2();
            room.AddProjectile(offsetPos, link.Direction, "flame", link);
            room.AddSoundEffect("candle");
        }
    }
}

