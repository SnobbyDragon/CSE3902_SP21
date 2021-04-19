namespace sprint0
{
    public class ChangeSwordCommand : ICommand
    {
        private readonly Game1 game;
        public ChangeSwordCommand(Game1 game) => this.game = game;
        public void Execute() => game.hudManager.ChangeSword();
    }
}
