namespace sprint0
{
    internal class LeftIdleState : IPlayerState
    {
        private ISprite sprite;
        public ISprite Sprite { get => sprite; set => sprite = value; }

        public LeftIdleState(ISprite sprite)
        {
            this.sprite = sprite;
        }
    }
}