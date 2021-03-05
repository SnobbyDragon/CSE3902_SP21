using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

// Authors: Jesse He and Jacob Urick
namespace sprint0
{
    public interface IPlayer
    {

        Direction Direction { get; set; }

        //Pos is deprecated
        Vector2 Pos { get; set; }
        IPlayerState State { get; set; }

        //Use position, not Pos
        static Vector2 Position;
        void Move(int x, int y);
        void Stop();
        void TakeDamage(Direction direction);
        void HandleUp();
        void HandleDown();
        void HandleLeft();
        void HandleRight();
        void HandleSword();
        void HandleShoot();
        void HandleBomb();
        void HandleBoomerang();
        void Draw(SpriteBatch spriteBatch);
        void Update();
    }
}
