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
        private List<ISprite> sprites, projectiles;
        private ISprite sprite;
        private SpriteFont font;
        private IPlayer player;
        private List<ISprite> roomSprites, hudSprites, roomBaseSprites;
        private ParseTest levelLoader;

        public ISprite Sprite { get => sprite; set => sprite = value; }
        public SpriteFont Font { get => font; set => font = value; }
        public IPlayer Player { get => player; set => player = value; }
        public List<ISprite> itemSprites, enemyNPCSprites, roomElementsSprites;
        public int itemIndex, enemyNPCIndex, roomElementsIndex;
        public ItemsWeaponsSpriteFactory itemFactory;
        //private ISprite roomBorder;

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
            levelLoader = new ParseTest(this, "13");


            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            DungeonFactory dungeonFactory = new DungeonFactory(this);
            itemFactory = new ItemsWeaponsSpriteFactory(this);
            HUDFactory hudFactory = new HUDFactory(this);
            itemIndex = enemyNPCIndex = 0;

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

            sprites = new List<ISprite> // miscellaneous sprites that are not controlled by anything
            {

                hudFactory.MakeSprite("hudM", new Vector2(0,0)),
                hudFactory.MakeSprite("rin 15", new Vector2(0,0)),
                hudFactory.MakeSprite("kin 5", new Vector2(0,0)),
                hudFactory.MakeSprite("bin 33", new Vector2(0,0)),
                hudFactory.MakeSprite("hin 5,10", new Vector2(0,0)),
                hudFactory.MakeSprite("hudA sword", new Vector2(0,0)),
                hudFactory.MakeSprite("hudB magical boomerang", new Vector2(0,0)),
                dungeonFactory.MakeSprite("room border", new Vector2(0, HUDHeight * Scale)),
                dungeonFactory.MakeSprite("room floor plain", new Vector2(32*Scale, HUDHeight * Scale + 32*Scale)), // location = borderX + 32*scale, borderY + 32*scale
                dungeonFactory.MakeSprite("down open door", new Vector2(112*Scale, HUDHeight * Scale)), // location = borderX + 112*scale, borderY
                dungeonFactory.MakeSprite("up open door", new Vector2(112*Scale, HUDHeight * Scale + 144*Scale)), // location = borderX + 112*scale, borderY + 144*scale
                dungeonFactory.MakeSprite("left open door", new Vector2(224*Scale, HUDHeight * Scale + 72*Scale)), // location = borderX + 224*scale, borderY + 72*scale
                dungeonFactory.MakeSprite("right open door", new Vector2(0, HUDHeight * Scale + 72*Scale)), // location = borderX, borderY + 72*scale
            };

            itemSprites = new List<ISprite>
            {
                itemFactory.MakeSprite("fairy", new Vector2(200,300),Direction.n,-1),
                itemFactory.MakeSprite("bomb", new Vector2(200,300),Direction.n,-1),
                itemFactory.MakeSprite("clock", new Vector2(200,300),Direction.n,-1),
                itemFactory.MakeSprite("compass", new Vector2(200,300),Direction.n,-1),
                itemFactory.MakeSprite("key", new Vector2(200,300),Direction.n,-1),
                itemFactory.MakeSprite("rupee", new Vector2(200,300),Direction.n, -1),
                itemFactory.MakeSprite("boomerang", new Vector2(200, 300), Direction.n, -1)
            };

            //list of enemy, npc, and boss sprites
            EnemyNPCSprites enbSprite = new EnemyNPCSprites(this);
            enemyNPCSprites = enbSprite.LoadEnemyNPCSprites();

            //list of room element sprites
            DungeonSprites dungeonSprite = new DungeonSprites(this);
            roomElementsSprites = dungeonSprite.LoadDungeonSprites();

            //projectile sprites (starts with none)
            projectiles = new List<ISprite>();
        }

        public void AddProjectile(Vector2 Location, Direction dir, int lifespan, String item)
        {
            projectiles.Add(itemFactory.MakeSprite(item, Location, dir, lifespan));
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
            //foreach (ISprite _sprite in sprites)
            //    _sprite.Update();
            foreach (ISprite projectile in projectiles)
                projectile.Update();
            //foreach (ISprite _sprite in itemSprites)
            //    _sprite.Update();
            //foreach (ISprite _sprite in enemyNPCSprites)
            //    _sprite.Update();
            foreach (ISprite _sprite in roomSprites)
                _sprite.Update();
            foreach (ISprite _sprite in hudSprites)
                _sprite.Update();
            base.Update(gameTime);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Gray);
            _spriteBatch.Begin();

            foreach (ISprite _sprite in roomBaseSprites)
                _sprite.Draw(_spriteBatch);
            foreach (ISprite _sprite in hudSprites)
                _sprite.Draw(_spriteBatch);
            foreach (ISprite _sprite in roomSprites)
                _sprite.Draw(_spriteBatch);
            //foreach (ISprite _sprite in sprites)
            //    _sprite.Draw(_spriteBatch);
            foreach (ISprite projectile in projectiles)
                projectile.Draw(_spriteBatch);
            //itemSprites[itemIndex].Draw(_spriteBatch);
            //enemyNPCSprites[enemyNPCIndex].Draw(_spriteBatch);
            //roomElementsSprites[roomElementsIndex].Draw(_spriteBatch);
            player.Draw(_spriteBatch);
            _spriteBatch.End();
            base.Draw(gameTime);
        }

        public void ResetGame()
        {
            // reset game timer
            ResetElapsedTime();

            //reset ItemIndex
            itemIndex = 0; // tight coupling :(

            //reset enemyNPCIndex
            enemyNPCIndex = 0;

            //reset roomElementsIndex
            roomElementsIndex = 0;

            //reset player state
            Player.Pos = new Vector2(200, 250);
            Player.State = new UpIdleState(Player);
        }
    }
}
