namespace sprint0
{
    class RightIdleState : IPlayerState
    {
        private ISprite sprite;
        public ISprite Sprite { get => sprite; set => sprite = value; }

        public RightIdleState(ISprite sprite)
        {
            this.sprite = sprite;
        }
    }
}