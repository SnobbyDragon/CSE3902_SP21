using Microsoft.Xna.Framework;

namespace sprint0
{
    public class NonMovingAnimatedCommand : ICommand
    {
        private Game1 game;
        public NonMovingAnimatedCommand(Game1 game)
        {
            this.game = game;
        }
        public void Execute()
        {
            game.Sprite = new NonMovingAnimatedSprite(game.Texture, new Vector2(400, 200));
        }
    }
}