using Microsoft.Xna.Framework;
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
        private readonly Vector2 northOffset = new Vector2(0, -1 * (MapHeight + HUDHeight)*Scale);
        private readonly Vector2 southOffset = new Vector2(0, (MapHeight + HUDHeight)*Scale);
        private readonly Vector2 eastOffset = new Vector2(Width*Scale, 0) ;
        private readonly Vector2 westOffset = new Vector2(-1 * (Width*Scale) , 0);



        public SoundFactory SoundFactory { get => soundFactory; }
        private SoundFactory soundFactory;
        public BackgroundMusic Music { get => music; }
        private BackgroundMusic music;
        public UniversalScreenManager universalScreenManager;
        public HUDManager hudManager;
        public Room Room { get => room; set => room = value; }
        private Room room;
        public Room NextRoom  {set => nextRoom = value; }
        private Room nextRoom;
        public bool ChangeRoom { get; set; }
        public bool UseLoadedPos { get; set; }
        public int RoomIndex { get; set; }
        public  int NumRooms { get; } = 19;
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
            Rooms = new Dictionary<int, Room>();
            RoomIndex = 18;
            ChangeRoom = true;
            UseLoadedPos = false;
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
            Rooms.Clear();
            ResetElapsedTime();
            VisitedRooms.Clear();
            RoomIndex = 18;
            ChangeRoom = true;
            ResetManagers();

            Player = new Link(this, new Vector2(LinkDefaultX, LinkDefaultY));
        }

        protected override void LoadContent()
        {
            if (!VisitedRooms.Contains(RoomIndex))
            {
                VisitedRooms.Add(RoomIndex);
            }

            room = new Room(_spriteBatch, this, RoomIndex, new Vector2(0, 0));
            playerFactory = new PlayerSpriteFactory(this);
            Rooms.Add(RoomIndex, room);
            Player = new Link(this, new Vector2(LinkDefaultX, LinkDefaultY));

            List<int> frontier = new List<int>();
            frontier.Add(RoomIndex);
            while (Rooms.Count < 18 ) {
                List<int> newFrontier = new List<int>();
                foreach (int roomIndex in frontier) { 
                    Dictionary<Direction, int> adjacentRooms = new Dictionary<Direction, int>();
                    adjacentRooms = AdjacentRooms.ListOfAdjacentRooms(roomIndex);
                    foreach (Direction d in adjacentRooms.Keys) {
                        int idx = adjacentRooms[d];
                        if (!Rooms.ContainsKey(idx)) {
                            newFrontier.Add(idx);
                            if (d == Direction.n) Rooms[idx] = new Room(_spriteBatch, this, idx, Rooms[roomIndex].getOffset() + northOffset);
                            if (d == Direction.s) Rooms[idx] = new Room(_spriteBatch, this, idx, Rooms[roomIndex].getOffset() + southOffset);
                            if (d == Direction.w) Rooms[idx] = new Room(_spriteBatch, this, idx, Rooms[roomIndex].getOffset() + westOffset);
                            if (d == Direction.e) Rooms[idx] = new Room(_spriteBatch, this, idx, Rooms[roomIndex].getOffset() + eastOffset);
                        }
                       
                    }
                }
                frontier = newFrontier;
                    
            
            }
            foreach (Room rm in Rooms.Values)
            {
               rm.LoadContent();
            }

            ChangeRoom = false;
                UseLoadedPos = false;
            
        }

        public void Slide(Direction d) {
            Vector2 offst = new Vector2(0, 0);
            if (d == Direction.n) {
                offst.Y = 1;
            }
            if (d == Direction.s) {
                offst.Y = -1;
            }
            if (d == Direction.e) {
                offst.X = -1;
            }
            if (d == Direction.w) {
                offst.X = 1;
            }
            foreach (Room rm in Rooms.Values) {
                rm.UpdateOffsets(offst);
            }
        }

        protected override void Update(GameTime gameTime)
        {
            state = stateMachine.GetState();

            if (state == GameStateMachine.State.changeRoom) {
                Slide(stateMachine.GetChangeDirection());
            }
            
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            foreach (IController controller in controllerList)
                controller.Update();
            if (state.Equals(GameStateMachine.State.changeRoom)) { 
                
            }
            
            if (state.Equals(GameStateMachine.State.play) || state.Equals(GameStateMachine.State.test)) {

                if (state.Equals(GameStateMachine.State.play) || state.Equals(GameStateMachine.State.test))
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
            if (state.Equals(GameStateMachine.State.changeRoom))
            {
                room.Draw();
                nextRoom.Draw();
            }
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
       
    }
}
