using Microsoft.Xna.Framework.Graphics;

namespace sprint0
{
    public interface IPlayerState
    {
        void Stop() { }
        void HandleUp() { }
        void HandleDown() { }
        void HandleLeft() { }
        void HandleRight() { }
        void HandleSword() { }
        void UseItem() { }
        void Update();
        void Draw(SpriteBatch spritebatch);
    }
}
