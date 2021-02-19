using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace sprint0
{
    public interface IPlayerState
    {
        void Stop() { }
        void TakeDamage(Direction direction) { }
        void HandleUp() { }
        void HandleDown() { }
        void HandleLeft() { }
        void HandleRight() { }
        void HandleSword() { }
        void HandleZ() { }
        void HandleN() { }
        void HandleOne(Direction direction, int life) { }
        void Update();
        void Draw(SpriteBatch spritebatch);
    }
}
