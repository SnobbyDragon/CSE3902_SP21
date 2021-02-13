namespace sprint0
{
    internal class LeftWoodSwordState : IPlayerState
    {
        private ISprite sprite;
        public ISprite Sprite { get => sprite; set => sprite = value; }

        public LeftWoodSwordState(ISprite sprite)
        {
            this.sprite = sprite;
        }
    }
}