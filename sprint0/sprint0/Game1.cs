﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.Linq;
namespace sprint0
{
    public class Game1 : Game
    {
        private readonly GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private List<IController> controllerList;
        public List<int> VisitedRooms;
        public Dictionary<int, Room> Rooms;
        public IPlayer Player { get; set; }
        private static PlayerSpriteFactory playerFactory;
        public static PlayerSpriteFactory PlayerFactory { get => playerFactory; }
        private readonly Vector2 northOffset = new Vector2(0, -1 * (MapHeight) * Scale);
        private readonly Vector2 southOffset = new Vector2(0, (MapHeight) * Scale);
        private readonly Vector2 eastOffset = new Vector2(Width * Scale, 0);
        private readonly Vector2 westOffset = new Vector2(-1 * (Width * Scale), 0);

        public bool ChangeRoom { get; set; }

        public SoundFactory SoundFactory { get; private set; }
        public BackgroundMusic Music { get; private set; }

        public UniversalScreenManager universalScreenManager;
        public HUDManager hudManager;
        public Room Room { get; set; }
        public Room NextRoom { set; get; }
        public int RoomIndex { get; set; }

        public int NextRoomIndex { get; set; }
        public int NumRooms { get; } = 19;
        public readonly GameStateMachine stateMachine;
        private readonly int LinkDefaultX = 250;
        private readonly int LinkDefaultY = 280;
        private GameStateMachine.State state;
        public static int Width { get; } = 256;
        public static int MapHeight { get; } = 176;
        public static int HUDHeight { get; } = 56;
        public static int BorderThickness { get; } = 32;
        public static float Scale { get; } = 2.5f;

        private Vector2 zeroVector = new Vector2(0, 0);
        public Game1()
        {
            stateMachine = new GameStateMachine(this);
            _graphics = new GraphicsDeviceManager(this)
            {
                IsFullScreen = false,
            };
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            _graphics.PreferredBackBufferWidth = (int)(Width * Scale);
            _graphics.PreferredBackBufferHeight = (int)((HUDHeight + MapHeight) * Scale);
            _graphics.ApplyChanges();
            _spriteBatch = new SpriteBatch(_graphics.GraphicsDevice);

            controllerList = new List<IController>
            {
                new KeyboardController(this),
                new MouseController(this)
            };
            InitializeManagers();
            SoundFactory = new SoundFactory(this);
            Music = SoundFactory.MakeBackgroundMusic();
            stateMachine.HandleStart();
            VisitedRooms = new List<int>();

            Rooms = new Dictionary<int, Room>();
            RoomIndex = 18;

            base.Initialize();
        }

        private void InitializeManagers()
        {
            universalScreenManager = new UniversalScreenManager(this);
            hudManager = new HUDManager(this);
            hudManager.LoadHUD();
        }

        public void RestartGame()
        {
            Rooms.Clear();
            ResetElapsedTime();
            VisitedRooms.Clear();
            RoomIndex = 18;
            InitializeManagers();
            LoadContent();
            Player = new Link(this, new Vector2(LinkDefaultX, LinkDefaultY));
        }

        protected override void LoadContent()
        {
            Room = new Room(_spriteBatch, this, RoomIndex, new Vector2(0, 0));
            playerFactory = new PlayerSpriteFactory(this);
            Rooms.Add(RoomIndex, Room);
            Player = new Link(this, new Vector2(LinkDefaultX, LinkDefaultY));

            List<int> frontier = new List<int> { RoomIndex };
            while (Rooms.Count < 17)
            {
                List<int> newFrontier = new List<int>();
                foreach (int roomIndex in frontier)
                {
                    Dictionary<Direction, int> adjacentRooms = new Dictionary<Direction, int>();
                    adjacentRooms = AdjacentRooms.ListOfAdjacentRooms(roomIndex);
                    foreach (Direction d in adjacentRooms.Keys)
                    {
                        int idx = adjacentRooms[d];
                        if (!Rooms.ContainsKey(idx))
                        {
                            newFrontier.Add(idx);
                            if (d == Direction.North) Rooms[idx] = new Room(_spriteBatch, this, idx, Rooms[roomIndex].Offset + northOffset);
                            else if (d == Direction.South) Rooms[idx] = new Room(_spriteBatch, this, idx, Rooms[roomIndex].Offset + southOffset);
                            else if (d == Direction.West) Rooms[idx] = new Room(_spriteBatch, this, idx, Rooms[roomIndex].Offset + westOffset);
                            else if (d == Direction.East) Rooms[idx] = new Room(_spriteBatch, this, idx, Rooms[roomIndex].Offset + eastOffset);
                        }
                    }
                }
                frontier = newFrontier;
            }
            Rooms[0] = new Room(_spriteBatch, this, 0, Rooms[1].Offset + eastOffset);
            foreach (Room rm in Rooms.Values)
                rm.LoadContent();
        }

        public void Slide(Direction d, int ammount)
        {
            Vector2 offst = zeroVector;
            ammount = System.Math.Abs(ammount);
            if (d == Direction.North)
            {
                offst.Y = 1 * ammount;

            }
            else if (d == Direction.South)
            {
                offst.Y = -ammount;
            }
            else if (d == Direction.East)
            {
                offst.X = -ammount;
            }
            else if (d == Direction.West)
            {
                offst.X = ammount;
            }
            foreach (Room rm in Rooms.Values)
            {
                rm.UpdateOffsets(offst);
            }
        }

        protected override void Update(GameTime gameTime)
        {
            state = stateMachine.GetState();
            if (!VisitedRooms.Contains(RoomIndex))
            {
                VisitedRooms.Add(RoomIndex);
            }
            if (state == GameStateMachine.State.changeRoom)
            {
                Slide(stateMachine.GetChangeDirection(), stateMachine.ScrollSpeed);
                stateMachine.HandleFinishRoomChange(NextRoomIndex);
            }

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            foreach (IController controller in controllerList)
                controller.Update();
            if (state.Equals(GameStateMachine.State.play) || state.Equals(GameStateMachine.State.test))
            {
                Room.Update();
            }
            if (ChangeHUD())
                hudManager.Update();
            universalScreenManager.Update(state);
            hudManager.Update();
            Music.Update();
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Gray);
            _spriteBatch.Begin();
            if (state.Equals(GameStateMachine.State.changeRoom))
            {
                Room.Draw();
                NextRoom.Draw();
                hudManager.Draw(_spriteBatch);
            }



            if (state.Equals(GameStateMachine.State.play) || state.Equals(GameStateMachine.State.test))
            {
                Room.Draw();
            }
            if (ChangeHUD())
                hudManager.Draw(_spriteBatch);
            universalScreenManager.Draw(_spriteBatch, state);
            _spriteBatch.End();
            base.Draw(gameTime);
        }

        private bool ChangeHUD()
        {
            return state.Equals(GameStateMachine.State.play) ||
                state.Equals(GameStateMachine.State.test) ||
                state.Equals(GameStateMachine.State.pause);
        }
    }
}
