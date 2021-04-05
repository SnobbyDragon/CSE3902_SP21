using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace sprint0
{
    public class Game1 : Game
    {
        private readonly GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private List<IController> controllerList;
        public List<int> VisitedRooms;
        public IPlayer Player { get; set; }
        public static PlayerSpriteFactory PlayerFactory { get; private set; }
        public SoundFactory SoundFactory { get; private set; }
        public BackgroundMusic Music { get; private set; }
        public UniversalScreenManager universalScreenManager;
        public HUDManager hudManager;
        public Room Room { get; private set; }
        public bool ChangeRoom { get; set; }
        public bool UseLoadedPos { get; set; }
        public int RoomIndex { get; set; }
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
            RoomIndex = 16;
            ChangeRoom = true;
            UseLoadedPos = false;
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
            ResetElapsedTime();
            VisitedRooms.Clear();
            RoomIndex = 16;
            ChangeRoom = true;
            InitializeManagers();
            Player = new Link(this, new Vector2(LinkDefaultX, LinkDefaultY));
        }

        protected override void LoadContent()
        {
            if (!VisitedRooms.Contains(RoomIndex))
                VisitedRooms.Add(RoomIndex);
            if (Room != null)
            {
                Vector2 playerPos = Player.Pos;
                Room = new Room(_spriteBatch, this, RoomIndex, playerPos.X, playerPos.Y, UseLoadedPos);
            }
            else
            {
                Room = new Room(_spriteBatch, this, RoomIndex);
                PlayerFactory = new PlayerSpriteFactory(this);
                Player = new Link(this, new Vector2(LinkDefaultX, LinkDefaultY));
            }
            Room.LoadContent();
            ChangeRoom = false;
            UseLoadedPos = false;
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
            if (state.Equals(GameStateMachine.State.play) || state.Equals(GameStateMachine.State.test))
                Room.Draw();
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
