using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

// Authors: Jesse He and Jacob Urick
namespace sprint0
{
    class Link : IPlayer
    {
        private readonly Game1 game;
        private IPlayerState state;
        private Vector2 position;
        private readonly int speed = 2;
        private Direction direction = Direction.n;
        public Vector2 Position { get => position; set => position = value; }
        public IPlayerState State { get => state; set => state = value; }
        private readonly Random rand;

        Direction IPlayer.direction => direction;

        public Link(Game1 game, Vector2 position)
        {
            this.game = game;
            this.position = position;
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
            int time = rand.Next(10, 20);
            game.AddArrow(position, direction, time);
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

        public void HandleZ()
        {
            State.HandleZ();
        }

        public void HandleN()
        {
            State.HandleN();
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
            throw new NotImplementedException();
        }

        public void HandleBoomerang()
        {
            throw new NotImplementedException();
        }
    }
}
