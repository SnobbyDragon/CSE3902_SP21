using System;
using System.Diagnostics;

namespace sprint0
{
    //Author: Jacob Urick
    // Last updated 3/28/2021 by urick.9
    public class GameStateMachine
    {
        private Game1 game;
        public enum State { start, play, pause, test, over, credits, win };
        private State state;
        public GameStateMachine(Game1 game)
        {
            this.game = game;
            state = State.start;
        }

        public void HandleDeath()
        {
            state = State.over;
        }

        public void HandleTest()
        {
            if (state == State.test)
            {
                state = State.play;
            }
            else if (state == State.play)
            {
                state = State.test;
            }
        }

        public void HandlePause()
        {
            if (state == State.pause)
            {
                state = State.play;
            }
            else if (state == State.play)
            {
                state = State.pause;
            }

        }

        public void HandleRunItBack()
        {
            if (state == State.over || state == State.play || state == State.win || state == State.test)
            {
                game.RestartGame();
                state = State.play;
            }
        }

        public void HandleCredits()
        {
            if (state == State.start)
            {
                state = State.credits;
            }
        }


        public void HandleVictory()
        {
            state = State.win;
        }

        public void HandleStart()
        {
            state = State.start;
        }

        public void HandlePlay()
        {
            if (state == State.start)
            {
                state = State.play;
            }
        }
        public State GetState()
        {

            return state;
        }
    }
}
