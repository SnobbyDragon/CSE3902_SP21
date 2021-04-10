namespace sprint0
{
    public class SkipSongCommand : ICommand
    {
        private readonly Game1 game;
        public SkipSongCommand(Game1 game) => this.game = game;
        public void Execute() => game.Music.SkipSong();
    }
}
