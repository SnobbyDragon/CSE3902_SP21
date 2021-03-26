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

        public SoundFactory SoundFactory { get => soundFactory; }
        private SoundFactory soundFactory;
        public BackgroundMusic Music { get => music; }
        private BackgroundMusic music;
        public HUDManager hudManager;
        public PauseScreenManager pauseScreenManager;
        public bool PauseScreen { get; set; }

        public Room Room { get => room; }
        private Room room;
        public bool ChangeRoom { get; set; }
        public int RoomIndex { get; set; }
        public int NumRooms { get; } = 19;

        public static int Width { get; } = 256;
        public static int MapHeight { get; } = 176;
        public static int HUDHeight { get; } = 56;
        public static int BorderThickness { get; } = 32;
        public static float Scale { get; } = 2.5f;

        public Game1()
        {
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
            hudManager = new HUDManager(this);
            pauseScreenManager = new PauseScreenManager(this);
            hudManager.LoadHUD();
            RoomIndex = 18;
            ChangeRoom = true;

            base.Initialize();
        }

        protected override void LoadContent()
        {
            room = new Room(_spriteBatch, this, RoomIndex);
            room.LoadContent();
            ChangeRoom = false;
            PauseScreen = false;
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            foreach (IController controller in controllerList)
                controller.Update();

            if (!PauseScreen)
            {
                if (ChangeRoom) LoadContent();
                room.Update();
            }
            hudManager.Update();
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Gray);
            _spriteBatch.Begin();
            if (!PauseScreen)
                room.Draw();
            else pauseScreenManager.Draw(_spriteBatch);
            hudManager.Draw(_spriteBatch);

            _spriteBatch.End();
            base.Draw(gameTime);
        }

        public void ResetGame()
        {
            ResetElapsedTime();
            Initialize();
        }
    }
}
