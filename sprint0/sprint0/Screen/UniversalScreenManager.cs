using Microsoft.Xna.Framework.Graphics;
//Author: Stuti Shah
namespace sprint0
{
    public class UniversalScreenManager
    {
        private readonly PauseScreenManager pauseScreenManager;
        public PauseScreenManager PauseScreenManager { get => pauseScreenManager; }
        private GameOverScreenManager gameOverScreenManager;
        private StartScreenManager startScreenManager;
        private CreditsScreenManager creditsScreenManager;
        private VictoryScreenManager victorScreenManager;
        private OptionsScreenManager optionsScreenManager;
        private OpeningScreenManager openingScreenManager;
        public UniversalScreenManager(Game1 game)
        {
            CreateScreens(game);
            pauseScreenManager = new PauseScreenManager(game);
        }

        public void Update(GameStateMachine.State state)
        {
            if (!state.Equals(GameStateMachine.State.pause))
                pauseScreenManager.Update();
            if (state.Equals(GameStateMachine.State.over))
                gameOverScreenManager.Update();
            else if (state.Equals(GameStateMachine.State.credits))
                creditsScreenManager.Update();
            else if (state.Equals(GameStateMachine.State.options))
                optionsScreenManager.Update();
            else if (state.Equals(GameStateMachine.State.start))
                startScreenManager.Update();
            else if (state.Equals(GameStateMachine.State.win))
                victorScreenManager.Update();
            else if (state.Equals(GameStateMachine.State.pause))
            {
                pauseScreenManager.SetupItemSelector();
                pauseScreenManager.UpdateItemSelection();
            }
            else if (state.Equals(GameStateMachine.State.opening))
                openingScreenManager.Update();
        }

        public void Draw(SpriteBatch _spriteBatch, GameStateMachine.State state)
        {
            if (state.Equals(GameStateMachine.State.pause))
                pauseScreenManager.Draw(_spriteBatch);
            else if (state.Equals(GameStateMachine.State.over))
                gameOverScreenManager.Draw(_spriteBatch);
            else if (state.Equals(GameStateMachine.State.start))
                startScreenManager.Draw(_spriteBatch);
            else if (state.Equals(GameStateMachine.State.credits))
                creditsScreenManager.Draw(_spriteBatch);
            else if (state.Equals(GameStateMachine.State.options))
                optionsScreenManager.Draw(_spriteBatch);
            else if (state.Equals(GameStateMachine.State.win))
                victorScreenManager.Draw(_spriteBatch);
            else if (state.Equals(GameStateMachine.State.opening))
                openingScreenManager.Draw(_spriteBatch);
        }

        private void CreateScreens(Game1 game)
        {
            ScreenFactory screenFactory = new ScreenFactory(game);
            openingScreenManager = screenFactory.MakeOpeningScreen();
            optionsScreenManager = screenFactory.MakeOptionsScreen();
            victorScreenManager = screenFactory.MakeVictoryScreen();
            gameOverScreenManager = screenFactory.MakeGameOverScreen();
            creditsScreenManager = screenFactory.MakeCreditsScreen();
            startScreenManager = screenFactory.MakeStartScreen();
        }
    }
}
