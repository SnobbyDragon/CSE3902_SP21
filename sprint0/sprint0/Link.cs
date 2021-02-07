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

        public Link(IPlayerState state, Vector2 position)
        {
            this.state = state;
            this.position = position;
        }
    }
}
