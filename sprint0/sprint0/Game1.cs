using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace sprint0
{
    public class Game1 : Game
    {
        private readonly GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private List<IController> controllerList;
        public List<int> VisitedRooms;

        public SoundFactory SoundFactory { get => soundFactory; }
        private SoundFactory soundFactory;
        public BackgroundMusic Music { get => music; }
        private BackgroundMusic music;
        public UniversalScreenManager universalScreenManager;
        public HUDManager hudManager;
        public Room Room { get => room; }
        private Room room;
        public bool ChangeRoom { get; set; }
        public int RoomIndex { get; set; }
        public int NumRooms { get; } = 19;

        public readonly GameStateMachine stateMachine;

        private readonly int LinkDefaultX = 250;
        private readonly int LinkDefaultY = 250;

        private GameStateMachine.State state;
        public static int Width { get; } = 256;
        public static int MapHeight { get; } = 176;
        public static int HUDHeight { get; } = 56;
        public static int BorderThickness { get; } = 32;
        public static float Scale { get; } = 2.5f;

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

            soundFactory = new SoundFactory(this);
            music = SoundFactory.MakeBackgroundMusic();
            ResetManagers();
            stateMachine.HandleStart();
            VisitedRooms = new List<int>();
            RoomIndex = 18;
            ChangeRoom = true;

            base.Initialize();
        }

        private void ResetManagers()
        {
            universalScreenManager = new UniversalScreenManager(this);
            hudManager = new HUDManager(this);
            hudManager.LoadHUD();
        }

        public void RestartGame()
        {
            ResetElapsedTime();
            VisitedRooms.Clear();
            RoomIndex = 18;
            ChangeRoom = true;
            ResetManagers();
            room.Player = new Link(this, new Vector2(LinkDefaultX, LinkDefaultY));
        }

        protected override void LoadContent()
        {
            if (!VisitedRooms.Contains(RoomIndex))
                VisitedRooms.Add(RoomIndex);
            room = new Room(_spriteBatch, this, RoomIndex);
            room.LoadContent();
            ChangeRoom = false;
        }

        protected override void Update(GameTime gameTime)
        {

            state = stateMachine.GetState();
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            foreach (IController controller in controllerList)
                controller.Update();

            if (state.Equals(GameStateMachine.State.play) || state.Equals(GameStateMachine.State.test))
            {
                if (ChangeRoom) LoadContent();
                
            }
            if (state.Equals(GameStateMachine.State.play) || state.Equals(GameStateMachine.State.test)) {
               
                room.Update();
            }
            if (ChangeHUD())
                hudManager.Update();
            universalScreenManager.Update(state);
            music.Update();
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Gray);
            _spriteBatch.Begin();
            if (state.Equals(GameStateMachine.State.play) || state.Equals(GameStateMachine.State.test))
                room.Draw();
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
        /*
         *  This is deprecated.
         */
        public void ResetGame()
        {
            ResetElapsedTime();
            Initialize();
        }
    }
}
