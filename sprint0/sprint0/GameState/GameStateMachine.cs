using System;
using System.Diagnostics;

namespace sprint0
{
    //Author: Jacob Urick
    // Last updated 3/28/2021 by urick.9
    public class GameStateMachine
    {
        private Game1 game;
        public enum State { start, play, pause, test, over, credits, win, changeRoom, options };
        private State state;
        private Direction direction;
        private int counter;
        private int bound;
        private State prev;
        public int ScrollSpeed = 4;
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
            if (state == State.start)
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
            else if (state == State.play || state == State.test)
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

        public void HandleOptions() {
            if (state == State.play || state == State.test) {
                prev = state;
                state = State.options;
            }
        }

        public Direction GetChangeDirection() {
            
                return direction;
            
        }
        public void HandleNewRoom(Direction d, int dest)
        {
            prev = state;
            counter = 0;
            direction = d;
            if (d == Direction.n || d == Direction.s)
            {
                bound = (int)(Game1.MapHeight * Game1.Scale) / ScrollSpeed;
            }
            if (d == Direction.e || d == Direction.w)
            {
                bound = (int)(Game1.Width * Game1.Scale) / ScrollSpeed;
            }
            state = State.changeRoom;
            game.NextRoomIndex = dest;
            game.NextRoom = game.Rooms[dest];
            game.Room.SuspendPlayer = true;
            game.NextRoom.SuspendPlayer = true;

        }

        public void HandleFinishRoomChange(int dest)
        {
            if (counter >= bound)
            {
                game.RoomIndex = dest;
                game.Room = game.Rooms[dest];
                game.Room.SuspendPlayer = false;
                state = prev;
            }
            else {
                counter++;
            }

        }

        public void HandleSnapRoomChange(int dest) {
            state = State.test;
            game.RoomIndex = dest;
            if (game.Rooms[dest].Offset.X > 0)
            {
                game.Slide(Direction.e, (int)game.Rooms[dest].Offset.X);
            }
            else if (game.Rooms[dest].Offset.X < 0)
            {
                game.Slide(Direction.w, (int)game.Rooms[dest].Offset.X);
            }
            if (game.Rooms[dest].Offset.Y > 0)
            {
                game.Slide(Direction.s, (int)game.Rooms[dest].Offset.Y);
            }
            else if (game.Rooms[dest].Offset.Y < 0)
            {
                game.Slide(Direction.n, (int)game.Rooms[dest].Offset.Y);
            }
            
            game.Room = game.Rooms[dest];
            game.Player.Pos = game.Room.LoadLevel.locations[dest];
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
