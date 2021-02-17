﻿using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace sprint0
{
    class Link : IPlayer
    {
        private IPlayerState state;
        private Vector2 position;
        private int speed = 2;
        public Vector2 Position { get => position; set => position = value; }
        public IPlayerState State { get => state; set => state = value; }

        public Link(Vector2 position)
        {
            this.position = position;
            State = new UpIdleState(this);
            speed = 2;
        }
        public void Move(int x, int y)
        {
            position += new Vector2(speed*x, speed*y);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            State.Draw(spriteBatch);
        }

        public void Update()
        {
            State.Update();
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
    }
}
