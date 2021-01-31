namespace sprint0
{
    public class MovingAnimatedCommand : ICommand
    {
        private Game1 game;
        public MovingAnimatedCommand(Game1 game)
        {
            this.game = game;
        }
        public void Execute()
        {
            game.Sprite = new MovingAnimatedSprite(game.Texture);
        }
    }
}