namespace sprint0
{
    public class MovingNonAnimatedCommand : ICommand
    {
        private Game1 game;
        public MovingNonAnimatedCommand(Game1 game)
        {
            this.game = game;
        }
        public void Execute()
        {
            game.Sprite = new MovingNonAnimatedSprite(game.Texture);
        }
    }
}