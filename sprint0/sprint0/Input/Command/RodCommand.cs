using System;
namespace sprint0
{
    public class RodCommand : ICommand
    {
        private readonly Game1 game;
        private readonly PlayerItems companionItem = PlayerItems.BookOfMagic;
        private readonly ICommand flameCommand;
        private readonly ICommand swordCommand;

        public RodCommand(Game1 game)
        {
            this.game = game;
            flameCommand = new FourCommand(this.game);
            swordCommand = new SwordCommand(this.game);
        }

        public void Execute()
        {
            swordCommand.Execute();

            //can't execute both sword and flame at the same time?
            if (game.hudManager.HasItem(companionItem))
                flameCommand.Execute();
        }
    }
}
