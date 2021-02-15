using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace sprint0
{
    public interface IPlayerState
    {
        void Stop() { }
        void HandleUp() { }
        void HandleDown() { }
        void HandleSword() { }
        void HandleLeft() { }
        void HandleRight() { }
        void HandleZ() { }
        void HandleN() { }
        void Update();
        void Draw(SpriteBatch spritebatch);
    }
}
