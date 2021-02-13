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
    }
}