using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace sprint0
{
    public interface IPlayer
    {
        Vector2 Position { get; set; }
        IPlayerState State { get; set; }
        void Move(int x, int y);
        void Stop();
        void HandleUp();
        void HandleDown();
        void HandleLeft();
        void HandleRight();
        void HandleSword();
        void HandleZ();
        void HandleN();
        void Draw(SpriteBatch spriteBatch);
        void Update();
    }
}
