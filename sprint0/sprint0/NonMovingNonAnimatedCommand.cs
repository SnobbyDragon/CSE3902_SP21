namespace sprint0
{
    public class NonMovingNonAnimatedCommand : ICommand
    {
        private Game1 game;
        public NonMovingNonAnimatedCommand(Game1 game)
        {
            this.game = game;
        }
        public void Execute()
        {
            game.Sprite = new NonMovingNonAnimatedSprite(game.Texture);
        }
    }
}