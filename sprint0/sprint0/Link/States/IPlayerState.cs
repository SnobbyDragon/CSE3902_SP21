using Microsoft.Xna.Framework.Graphics;

namespace sprint0
{
    public interface IPlayerState
    {
        public void Stop() { }
        public void HandleUp() { }
        public void HandleDown() { }
        public void HandleLeft() { }
        public void HandleRight() { }
        public void HandleSword(LinkUseItemHelper itemHelper) { }
        public void UseItem(LinkUseItemHelper itemHelper) { }
        public void PickUpItem() { }
        public void Update();
        public void Draw(SpriteBatch spritebatch);
    }
}
