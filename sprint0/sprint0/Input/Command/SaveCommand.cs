using System;
namespace sprint0
{
    public class SaveCommand : ICommand
    {
        private readonly Game1 game;

        public SaveCommand(Game1 game) => this.game = game;

        public void Execute() => game.SaveGame();
    }
}
