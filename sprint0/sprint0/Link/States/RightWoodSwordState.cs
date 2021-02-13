namespace sprint0
{
    internal class RightWoodSwordState : IPlayerState
    {
        private ISprite sprite;
        public ISprite Sprite { get => sprite; set => sprite = value; }

        public RightWoodSwordState(ISprite sprite)
        {
            this.sprite = sprite;
        }
    }
}