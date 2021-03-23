using System;
namespace sprint0
{
    public class ToggleMusicCommand : ICommand
    {
        private readonly Game1 game;

        public ToggleMusicCommand(Game1 game)
        {
            this.game = game;
        }

        public void Execute()
        {
            game.Music.Toggle();
        }

    }
}
