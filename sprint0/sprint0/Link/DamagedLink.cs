using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

// Author: Jesse He
/*
 * Last updated: 2/22/21 by he.1528
 */
namespace sprint0
{
    class DamagedLink : IPlayer
    {
        readonly Game1 game;
        private readonly IPlayer decoratedLink;
        readonly Direction direction;
        int timer = 80;
        public Vector2 Pos { get => decoratedLink.Pos; set => decoratedLink.Pos = value; }
        public IPlayerState State { get => decoratedLink.State; set => decoratedLink.State = value; }
        Direction IPlayer.Direction { get => decoratedLink.Direction; set => decoratedLink.Direction = value; }

        public DamagedLink(IPlayer decoratedLink, Game1 game, Direction direction)
        {
            this.game = game;
            this.decoratedLink = decoratedLink;
            this.direction = direction;
        }

        public void Move(int x, int y)
        {
            decoratedLink.Move(x, y);
        }

        public void TakeDamage(Direction direction)
        {
            // no-op: does not take damage
        }

        public void RemoveDecorator()
        {
            game.Player = decoratedLink;
        }

        public void Stop()
        {
            decoratedLink.Stop();
        }

        public void HandleUp()
        {
            decoratedLink.HandleUp();
        }

        public void HandleDown()
        {
            decoratedLink.HandleDown();
        }

        public void HandleLeft()
        {
            decoratedLink.HandleLeft();
        }

        public void HandleRight()
        {
            decoratedLink.HandleRight();
        }

        public void HandleSword()
        {
            decoratedLink.HandleSword();
        }

        public void HandleShoot()
        {
            decoratedLink.HandleShoot();
        }

        public void HandleBomb()
        {
            decoratedLink.HandleBomb();
        }

        public void HandleBoomerang()
        {
            decoratedLink.HandleBoomerang();
        }


        public void Draw(SpriteBatch spriteBatch)
        {
            // TODO: Change sprites to hurt pallates?--for now Link flashes on every frame
            if (timer % 2 == 0)
                decoratedLink.Draw(spriteBatch);
        }

        public void Update()
        {
            timer--;
            if (timer > 75)
            {
                switch (direction) {
                    case Direction.n:
                        decoratedLink.Move(0, 6);
                        break;
                    case Direction.s:
                        decoratedLink.Move(0, -6);
                        break;
                    case Direction.e:
                        decoratedLink.Move(-6, 0);
                        break;
                    case Direction.w:
                        decoratedLink.Move(6, 0);
                        break;
                }
            }
            else if (timer == 0)
            {
                RemoveDecorator();
            }

            decoratedLink.Update();
        }
    }
}
