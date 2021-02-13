using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace sprint0
{
    public interface IPlayerState
    {
        void HandleUp();
        void HandleDown();
        void HandleLeft();
        void HandleRight();
        void Update();
        void Draw(SpriteBatch spritebatch);
    }
}
