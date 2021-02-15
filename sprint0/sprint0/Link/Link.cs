using System;
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
        public IPlayerState State { get => state; set => state = value; }
        public Vector2 Position { get => position; set => position = value; }

        public Link(Vector2 position)
        {
            this.position = position;
            state = new UpIdleState(this);
            speed = 2;
        }

        public void Move(int x, int y)
        {
            position += new Vector2(speed*x, speed*y);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            state.Draw(spriteBatch);
        }

        public void Update()
        {
            state.Update();
        }
    }
}
