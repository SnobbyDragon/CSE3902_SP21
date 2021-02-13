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
        public IPlayerState State { get => state; set => state = value; }
        public Vector2 Position { get => position; set => position = value; }

        public Link(Vector2 position)
        {
            this.position = position;
            state = new UpIdleState(this);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            state.Draw(spriteBatch);
        }

        public void Update()
        {
            state.Update();
        }

        private void move(int xa, int ya) {
            //TODO: check for collisions here
            position.X += xa;
            position.Y += ya;
        }

        public void update() { 
            //no-op for now
        }

        public void draw() { 
        
        }
    }
}
