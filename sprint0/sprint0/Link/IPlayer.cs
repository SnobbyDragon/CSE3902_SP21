using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

// Authors: Jesse He and Jacob Urick
namespace sprint0
{
    public interface IPlayer
    {

        Direction direction { get; }
        Vector2 Position { get; set; }
        IPlayerState State { get; set; }

        void Move(int x, int y);
        void Stop();
        void TakeDamage(Direction direction);
        void HandleUp();
        void HandleDown();
        void HandleLeft();
        void HandleRight();
        void HandleSword();
        void HandleOne();
        void HandleTwo();
        void HandleThree();
        void HandleZ();
        void HandleN();
        void Draw(SpriteBatch spriteBatch);
        void Update();
    }
}
