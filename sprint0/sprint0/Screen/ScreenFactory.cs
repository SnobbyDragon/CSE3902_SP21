using Microsoft.Xna.Framework.Graphics;
namespace sprint0
{
    public enum ScreenEnum
    {
        Opening, Start, Credit, Option, Over, Victory
    }
    public class ScreenFactory
    {
        private readonly Game1 game;
        private readonly Texture2D texture;
        public Texture2D Texture { get => texture; }
        public ScreenFactory(Game1 game)
        {
            this.game = game;
            texture = game.Content.Load<Texture2D>("Images/TitleScreen");
        }
        public OpeningScreenManager MakeOpeningScreen() => new OpeningScreenManager(game, texture);
        public StartScreenManager MakeStartScreen() => new StartScreenManager(game);
        public CreditsScreenManager MakeCreditsScreen() => new CreditsScreenManager(game);
        public OptionsScreenManager MakeOptionsScreen() => new OptionsScreenManager(game);
        public GameOverScreenManager MakeGameOverScreen() => new GameOverScreenManager(game);
        public VictoryScreenManager MakeVictoryScreen() => new VictoryScreenManager(game);
    }
}
