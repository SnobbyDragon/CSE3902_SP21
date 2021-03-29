using System;
using Microsoft.Xna.Framework.Graphics;

namespace sprint0
{
    public class UniversalScreenManager
    {
        public PauseScreenManager pauseScreenManager;
        public GameOverScreenManager gameOverScreenManager;
        public StartScreenManager startScreenManager;
        public CreditsScreenManager creditsScreenManager;
        public UniversalScreenManager(Game1 game)
        {
            pauseScreenManager = new PauseScreenManager(game);
            gameOverScreenManager = new GameOverScreenManager(game);
            creditsScreenManager = new CreditsScreenManager(game);
            startScreenManager = new StartScreenManager(game);
        }

        public void Update(GameStateMachine.State state)
        {
            if (false) { }
            else if (state.Equals(GameStateMachine.State.pause))
                pauseScreenManager.Update();
            else if (state.Equals(GameStateMachine.State.over))
                gameOverScreenManager.Update();
            else if (state.Equals(GameStateMachine.State.credits))
                creditsScreenManager.Update();
            else if (state.Equals(GameStateMachine.State.start))
                startScreenManager.Update();
        }

        public void Draw(SpriteBatch _spriteBatch, GameStateMachine.State state)
        {

            if (false) { }
            else if (state.Equals(GameStateMachine.State.pause))
                pauseScreenManager.Draw(_spriteBatch);
            else if (state.Equals(GameStateMachine.State.over))
                gameOverScreenManager.Draw(_spriteBatch);
            else if (state.Equals(GameStateMachine.State.start))
                startScreenManager.Draw(_spriteBatch);
            else if (state.Equals(GameStateMachine.State.credits))
                creditsScreenManager.Draw(_spriteBatch);
        }
    }
}
