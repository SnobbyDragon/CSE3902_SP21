namespace sprint0
{
    internal class DownIdleState : IPlayerState
    {
        private ISprite sprite;
        public ISprite Sprite { get => sprite; set => sprite = value; }

        public DownIdleState(ISprite sprite)
        {
            this.sprite = sprite;
        }
    }
}