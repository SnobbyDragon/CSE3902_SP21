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
        Direction IPlayer.Direction => direction;

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

            game.AddItem(offsetPos, direction, time, "arrow");
        }

        public void ThrowBomb()
        {
            Vector2 offsetPos = position;
            if (direction == Direction.n || direction == Direction.s)
            {
                offsetPos = new Vector2(position.X + 6, position.Y);
            }

            game.AddItem(offsetPos, direction, 30, "bomb");
        }

        public void ThrowBoomerang()
        {
            Vector2 offsetPos = position;
            if (direction == Direction.n || direction == Direction.s)
            {
                offsetPos = new Vector2(position.X + 6, position.Y);
            }
            game.AddItem(offsetPos, direction, 0, "boomerang");
        }


        public void Stop()
        {
            State.Stop();
        }

        public void HandleUp()
        {
            direction = Direction.n;
            State.HandleUp();
        }

        public void HandleDown()
        {
            direction = Direction.s;
            State.HandleDown();
        }

        public void HandleLeft()
        {
            direction = Direction.w;
            State.HandleLeft();
        }

        public void HandleRight()
        {
            direction = Direction.e;
            State.HandleRight();

        }

        public void HandleSword()
        {
            State.HandleSword();
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
        }

        public void HandleBomb()
        {
            ThrowBomb();
        }

        public void HandleBoomerang()
        {
            ThrowBoomerang();
        }
    }
}
