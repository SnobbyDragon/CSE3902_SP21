namespace sprint0
{
    //Author: Jacob Urick
    // Last updated 3/28/2021 by urick.9
    public class GameStateMachine
    {
        private readonly Game1 game;
        public enum State { start, play, pause, test, over, credits, win, changeRoom, options };
        public enum Mode { easy, hard };
        private Mode mode;
        private State state;
        private Direction direction;
        private int counter;
        private int bound;
        private State prev;
        public GameStateMachine(Game1 game)
        {
            this.game = game;
            state = State.start;
        }

        public void HandleEasy()
        {
            if (state == State.options)
            {
                game.UpdateDifficulty(Mode.easy);
                mode = Mode.easy;
            }

        }
        public void HandleHard()
        {
            if (state == State.options)
            {
                game.UpdateDifficulty(Mode.hard);
                mode = Mode.hard;
            }
        }
        public void SetMode(Mode mode)
        {
            this.mode = mode;
        }

        public Mode GetMode()
        {
            return mode;
        }

        public void HandleDeath() => state = State.over;
        public void HandleTest()
        {
            if (state == State.play) state = State.test;
            else if (state == State.test) state = State.play;
        }

        public void HandlePause()
        {
            if (state == State.pause) state = State.play;
            else if (state == State.play || state == State.test) state = State.pause;
        }

        public void HandleRunItBack()
        {
            if (state == State.over || state == State.play || state == State.win || state == State.test)
            {
                game.RestartGame();
                state = State.start;
            }
        }

        public void HandleOptions()
        {
            if (state == State.play || state == State.test)
            {
                prev = state;
                state = State.options;
            }
            else if (state == State.options) state = prev;
        }

        public Direction GetChangeDirection() => direction;

        public void HandleNewRoom(Direction d, int dest)
        {
            prev = state;
            counter = 0;
            direction = d;
            if (d == Direction.North || d == Direction.South)
                bound = (int)(Game1.MapHeight * Game1.Scale) / game.ScrollSpeed - 1;
            if (d == Direction.East || d == Direction.West)
                bound = (int)(Game1.Width * Game1.Scale) / game.ScrollSpeed - 1;
            state = State.changeRoom;
            game.NextRoomIndex = dest;
            game.NextRoom = game.Rooms[dest];
            game.Room.SuspendPlayer = true;
            game.NextRoom.SuspendPlayer = true;
            game.Room.FreezeEnemies = false;
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
            else
                counter++;
        }

        public void HandleLevelSelectOne()
        {
            if (state == State.start)
            {
                game.levelMachine.SetLevel(GameLevelMachine.Level.Level1);
                game.RestartGame();
                state = State.play;
                game.NumRooms = game.levelMachine.GetNumberOfTotalRooms();
            }
        }
        public void HandleLevelSelectThree()
        {
            if (state == State.start)
            {
                game.levelMachine.SetLevel(GameLevelMachine.Level.Level3);
                game.RestartGame();
                state = State.play;
                game.NumRooms = game.levelMachine.GetNumberOfTotalRooms();

            }

        }

        public void HandleLevelSelectFour()
        {
            if (state == State.start)
            {
                game.levelMachine.SetLevel(GameLevelMachine.Level.Level4);
                game.RestartGame();
                state = State.play;
                game.NumRooms = game.levelMachine.GetNumberOfTotalRooms();

            }

        }

        public void HandleLevelSelectTwo()
        {
            if (state == State.start)
            {
                game.levelMachine.SetLevel(GameLevelMachine.Level.Level2);
                game.RestartGame();
                state = State.play;
                game.NumRooms = game.levelMachine.GetNumberOfTotalRooms();

            }
        }

        public void HandleLevelSelectLoad()
        {
            if (state == State.start)
            {
                game.levelMachine.SetLevel(GameLevelMachine.Level.Level1);
                game.LoadSavedGame();
                state = State.play;
                game.NumRooms = game.levelMachine.GetNumberOfTotalRooms();
            }
        }

        public void HandleSnapRoomChange(int dest)
        {
            state = State.test;
            game.RoomIndex = dest;
            if (game.Rooms[dest].Offset.X > 0)
                game.Slide(Direction.East, (int)game.Rooms[dest].Offset.X);
            else if (game.Rooms[dest].Offset.X < 0)
                game.Slide(Direction.West, (int)game.Rooms[dest].Offset.X);
            if (game.Rooms[dest].Offset.Y > 0)
                game.Slide(Direction.South, (int)game.Rooms[dest].Offset.Y);
            else if (game.Rooms[dest].Offset.Y < 0)
                game.Slide(Direction.North, (int)game.Rooms[dest].Offset.Y);
            game.Room = game.Rooms[dest];
            game.Player.Pos = game.Room.LoadLevel.locations[dest];
            game.Room.SuspendPlayer = false;
            game.Room.FreezeEnemies = false;

        }

        public void HandleCredits()
        {
            if (state == State.start) state = State.credits;
        }

        public void HandleVictory() => state = State.win;
        public void HandleStart() => state = State.start;
        public void HandlePlay()
        {
            if (state == State.test) state = State.play;
        }
        public State GetState() => state;
    }
}
