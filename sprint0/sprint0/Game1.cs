using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace sprint0
{
    public enum Direction { n, s, e, w, ne, nw, se, sw };
    public enum Collision { Left, Right, Top, Bottom, None };

    public class Game1 : Game
    {
        private static PlayerSpriteFactory playerFactory;
        public static PlayerSpriteFactory PlayerFactory { get => playerFactory; }

        private readonly GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private List<IController> controllerList;
        private List<IProjectile> projectiles;
        private ISprite sprite;
        private SpriteFont font;
        private IPlayer player;

        private List<ISprite> roomSprites, hudSprites, roomBaseSprites;
        private LevelLoader levelLoader;
        public bool changeRoom;
        public int roomIndex;

        public ISprite Sprite { get => sprite; set => sprite = value; }
        public SpriteFont Font { get => font; set => font = value; }
        public IPlayer Player { get => player; set => player = value; }
        public ItemsWeaponsSpriteFactory itemFactory;

        // map width and height in pixels (does not include HUD) TODO scale up?
        public static int Width { get; } = 256;
        public static int MapHeight { get; } = 176;
        public static int HUDHeight { get; } = 56;
        public static float Scale { get; } = 2.5f; //TODO change later?

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
            controllerList = new List<IController>
            {
                new KeyboardController(this),
                new MouseController(this)
            };
            playerFactory = new PlayerSpriteFactory(this);
            player = new Link(this, new Vector2(200, 250));

            //note: the integer refers to the room number to load
            changeRoom = true;
            roomIndex = 10;
            levelLoader = new LevelLoader(this, roomIndex);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            DungeonFactory dungeonFactory = new DungeonFactory(this);
            HUDFactory hudFactory = new HUDFactory(this);

            /*
             * below code was commented out so it's not confusing when testing. The following code is stuff for after we get all of the level loading stuff done/to test level loading
             * commented out code:
             * 1. separates out hud and the base elements of the room (plain floor and room border)
             * 2. loads sprites for the level
             */

            roomSprites = levelLoader.LoadLevel();
            roomBaseSprites = new List<ISprite> // miscellaneous sprites that are not controlled by anything
            {
                dungeonFactory.MakeSprite("room border", new Vector2(0, HUDHeight * Scale)),
                dungeonFactory.MakeSprite("room floor plain", new Vector2(32*Scale, HUDHeight * Scale + 32*Scale)), // location = borderX + 32*scale, borderY + 32*scale
            };

            hudSprites = new List<ISprite> // miscellaneous sprites that are not controlled by anything
            {
                hudFactory.MakeSprite("hudM", new Vector2(0,0)),
                hudFactory.MakeSprite("rin 15", new Vector2(0,0)),
                hudFactory.MakeSprite("kin 5", new Vector2(0,0)),
                hudFactory.MakeSprite("bin 33", new Vector2(0,0)),
                hudFactory.MakeSprite("hin 5,10", new Vector2(0,0)),
                hudFactory.MakeSprite("hudA sword", new Vector2(0,0)),
                hudFactory.MakeSprite("hudB magical boomerang", new Vector2(0,0)),
            };
            //projectile sprites (starts with none)
            itemFactory = new ItemsWeaponsSpriteFactory(this);
            projectiles = new List<IProjectile>();
        }

        public void AddProjectile(Vector2 Location, Direction dir, int lifespan, string item)
        {
            projectiles.Add(itemFactory.MakeProjectile(item, Location, dir, lifespan));
        }

        public void AddFireball(Vector2 location, Vector2 dir)
        {
            projectiles.Add(itemFactory.MakeFireball(location, dir));
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            //TODO need to make new commands
            foreach (IController controller in controllerList)
            {
                controller.Update();
            }
            player.Update();

            //NOTE: changes room if needed
            if (changeRoom)
            {
                levelLoader = new LevelLoader(this, roomIndex);
                roomSprites = levelLoader.LoadLevel();
                changeRoom = false;
            }

            //NOTE: to update level sprites and hud
            foreach (ISprite _sprite in roomSprites)
                _sprite.Update();
            foreach (ISprite _sprite in hudSprites)
                _sprite.Update();
            foreach (IProjectile projectile in projectiles)
                projectile.Update();

            base.Update(gameTime);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Gray);
            _spriteBatch.Begin();

            //NOTE: draws room base, hud, and level elements
            foreach (ISprite _sprite in roomBaseSprites)
                _sprite.Draw(_spriteBatch);
            foreach (ISprite _sprite in hudSprites)
                _sprite.Draw(_spriteBatch);
            foreach (ISprite _sprite in roomSprites)
                _sprite.Draw(_spriteBatch);
            foreach (IProjectile projectile in projectiles)
                projectile.Draw(_spriteBatch);
            player.Draw(_spriteBatch);
            _spriteBatch.End();
            base.Draw(gameTime);
        }

        public void ResetGame()
        {
            // reset game timer
            ResetElapsedTime();

            //reset player state
            Player.Pos = new Vector2(200, 250);
            Player.State = new UpIdleState(Player);
        }
    }
}
