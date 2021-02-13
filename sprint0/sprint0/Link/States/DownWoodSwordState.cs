namespace sprint0
{
    internal class DownWoodSwordState : IPlayerState
    {
        private ISprite sprite;
        public ISprite Sprite { get => sprite; set => sprite = value; }

        public DownWoodSwordState(ISprite sprite)
        {
            this.sprite = sprite;
        }
    }
}