using Microsoft.Xna.Framework.Graphics;

namespace sprint0
{
    internal class UpWoodSwordState : IPlayerState
    {
        private ISprite sprite;
        public ISprite Sprite { get => sprite; set => sprite = value; }

        public UpWoodSwordState(ISprite sprite)
        {
            this.sprite = sprite;
        }

        public void HandleUp()
        {
            throw new System.NotImplementedException();
        }

        public void HandleDown()
        {
            throw new System.NotImplementedException();
        }

        public void HandleLeft()
        {
            throw new System.NotImplementedException();
        }

        public void HandleRight()
        {
            throw new System.NotImplementedException();
        }

        public void Update()
        {
            throw new System.NotImplementedException();
        }

        public void Draw(SpriteBatch spritebatch)
        {
            throw new System.NotImplementedException();
        }
    }
}