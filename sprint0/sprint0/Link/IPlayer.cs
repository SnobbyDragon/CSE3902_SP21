using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace sprint0
{
    public interface IPlayer
    {
        IPlayerState State { get; set; }
        Vector2 Position { get; set; }

        void Move(int x, int y);
        void Draw(SpriteBatch spriteBatch);
        void Update();
    }
}
