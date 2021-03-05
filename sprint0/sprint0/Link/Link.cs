using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

// Authors: Jesse He and Jacob Urick

/*
 * Last updated: 2/21/21 by urick.9
 */
namespace sprint0
{
     class Link : IPlayer
    {
        private readonly Game1 game;
        private IPlayerState state;
        public static Vector2 position;
        private readonly int speed = 2;
        private Direction direction = Direction.n;
        public Vector2 Pos { get => position; set => position = value; }
        public IPlayerState State { get => state; set => state = value; }
        private readonly Random rand;
        Direction IPlayer.Direction { get => direction; set => direction = value; }

        public Link(Game1 game, Vector2 pos)
        {
            this.game = game;
            position = pos;
            State = new UpIdleState(this);
            rand = new Random();
            speed = 2;
        }

        public void Move(int x, int y)
        {
            position += new Vector2(speed*x, speed*y);
        }

        public void TakeDamage(Direction direction)
        {
            game.Player = new DamagedLink(this, game, direction);
        }

        public void Shoot() {
            // Random time for arrows is neat :)
            int time = rand.Next(50, 65);
            Vector2 offsetPos = position;
            if (direction == Direction.n || direction == Direction.s)
            {
                offsetPos = new Vector2(position.X + 6, position.Y);
            }

            game.AddProjectile(offsetPos, direction, time, "arrow");
        }

        public void ThrowBomb()
        {
            Vector2 offsetPos = position;
            if (direction == Direction.n || direction == Direction.s)
            {
                offsetPos = new Vector2(position.X + 6, position.Y);
            }

            game.AddProjectile(offsetPos, direction, 30, "bomb");
        }

        public void ThrowBoomerang()
        {
            Vector2 offsetPos = position;
            if (direction == Direction.n || direction == Direction.s)
            {
                offsetPos = new Vector2(position.X + 6, position.Y);
            }
            game.AddProjectile(offsetPos, direction, 0, "boomerang");
        }


        public void Stop()
        {
            State.Stop();
        }

        public void HandleUp()
        {
            State.HandleUp();
        }

        public void HandleDown()
        {
            State.HandleDown();
        }

        public void HandleLeft()
        {
            State.HandleLeft();
        }

        public void HandleRight()
        {
            State.HandleRight();
        }

        public void HandleSword()
        {
            State.HandleSword();
            Vector2 offsetPos = position;
            switch(direction)
            {
                case Direction.n:
                    offsetPos = new Vector2(position.X + 3, position.Y);
                    break;
                case Direction.s:
                    offsetPos = new Vector2(position.X + 5, position.Y);
                    break;
                case Direction.e:
                    offsetPos = new Vector2(position.X + 8, position.Y + 6);
                    break;
                case Direction.w:
                    offsetPos = new Vector2(position.X, position.Y + 6);
                    break;
            }
            game.AddItem(offsetPos, direction, 0, "sword beam");
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            State.Draw(spriteBatch);
        }

        public void Update()
        {
            State.Update();
        }

        public void HandleShoot()
        {
            Shoot();
            State.UseItem();
        }

        public void HandleBomb()
        {
            ThrowBomb();
            State.UseItem();
        }

        public void HandleBoomerang()
        {
            ThrowBoomerang();
            State.UseItem();
        }
    }
}
