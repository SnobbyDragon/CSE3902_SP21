using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace sprint0
{
    class LinkUseItemHelper
    {
        private Room game;
        private IPlayer link;
        public LinkUseItemHelper(Room game, IPlayer link)
        {
            this.game = game;
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
            game.AddWeapon(offsetPos, link.Direction, "sword", link);
            if (beam)
            {
                game.AddProjectile(offsetPos, link.Direction, "sword beam", link);
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
                case PlayerItems.Candle:
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
            game.AddProjectile(offsetPos, link.Direction, "arrow", link);
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
            game.AddWeapon(offsetPos, link.Direction, "bomb", link);
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
            game.AddProjectile(offsetPos, link.Direction, "boomerang", link);
        }

        private void UseCandle()
        {
            Vector2 offsetPos = link.Pos;
            switch (link.Direction)
            {
                case Direction.n:
                    offsetPos = new Vector2(link.Pos.X, link.Pos.Y - 16);
                    break;
                case Direction.s:
                    offsetPos = new Vector2(link.Pos.X, link.Pos.Y + 16);
                    break;
                case Direction.e:
                    offsetPos = new Vector2(link.Pos.X + 16, link.Pos.Y);
                    break;
                case Direction.w:
                    offsetPos = new Vector2(link.Pos.X - 16, link.Pos.Y);
                    break;
            }
            game.AddProjectile(offsetPos, link.Direction, "flame", link);
        }
    }
}

