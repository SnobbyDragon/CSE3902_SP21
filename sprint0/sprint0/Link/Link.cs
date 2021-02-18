using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

// Authors: Jesse He and Jacob Urick
namespace sprint0
{
    class Link : IPlayer
    {
        private Game1 game;
        private IPlayerState state;
        private Vector2 position;
        private int speed = 2;
        public Vector2 Position { get => position; set => position = value; }
        public IPlayerState State { get => state; set => state = value; }

        public Link(Game1 game, Vector2 position)
        {
            this.game = game;
            this.position = position;
            State = new UpIdleState(this);
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
    }
}
