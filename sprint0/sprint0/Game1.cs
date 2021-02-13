using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace sprint0
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private List<IController> controllerList;
        private List<ISprite> sprites;
        private ISprite sprite;
        private Texture2D texture;
        private SpriteFont font;
        private IPlayer player;
        private PlayerSpriteFactory playerFactory;
        public ISprite Sprite { get => sprite; set => sprite = value; }
        public Texture2D Texture { get => texture; }
        public SpriteFont Font { get => font; set => font = value; }
        public IPlayer Player { get => player; set => player = value; }
        internal PlayerSpriteFactory PlayerFactory { get => playerFactory; set => playerFactory = value; }

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            controllerList = new List<IController>();
            controllerList.Add(new KeyboardController(this));
            controllerList.Add(new MouseController(this));

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            BossesSpriteFactory bossSpriteFactory = new BossesSpriteFactory(this);
            DungeonFactory dungeonFactory = new DungeonFactory(this);
            ItemsWeaponsSpriteFactory itemFactory = new ItemsWeaponsSpriteFactory(this);
            EnemiesSpriteFactory enemyFactory = new EnemiesSpriteFactory(this);
            NpcsSpriteFactory npcFactory = new NpcsSpriteFactory(this);
            playerFactory = new PlayerSpriteFactory(this);
            player = new Link(new UpIdleState(playerFactory.MakeSprite("link up idle", new Vector2(200, 250))), new Vector2(200, 250));
            player = new Link(new UpIdleState(playerFactory.MakeSprite("link up sword", new Vector2(250, 250))), new Vector2(250, 250));
            sprites = new List<ISprite> // testing sprites here
            {
                bossSpriteFactory.MakeSprite("ganon fireball center", new Vector2(400, 200)),
                bossSpriteFactory.MakeSprite("ganon fireball up", new Vector2(415, 200)),
                bossSpriteFactory.MakeSprite("ganon fireball up left", new Vector2(430, 200)),
                bossSpriteFactory.MakeSprite("ganon fireball left", new Vector2(445, 200)),
                bossSpriteFactory.MakeSprite("ganon fireball down left", new Vector2(460, 200)),
                bossSpriteFactory.MakeSprite("ganon fireball down", new Vector2(475, 200)),
                bossSpriteFactory.MakeSprite("ganon fireball down right", new Vector2(490, 200)),
                bossSpriteFactory.MakeSprite("ganon fireball right", new Vector2(505, 200)),
                bossSpriteFactory.MakeSprite("ganon fireball up right", new Vector2(520, 200)),
                bossSpriteFactory.MakeSprite("orange gohma", new Vector2(420, 420)),
                bossSpriteFactory.MakeSprite("blue gohma", new Vector2(450, 450)),
                bossSpriteFactory.MakeSprite("patra", new Vector2(300, 150)),
                bossSpriteFactory.MakeSprite("patra minion", new Vector2(320, 150)),
                bossSpriteFactory.MakeSprite("manhandla", new Vector2(100,100)),
                bossSpriteFactory.MakeSprite("dodongo", new Vector2(250,100)),
                dungeonFactory.MakeSprite("block", new Vector2(600,200)),
                dungeonFactory.MakeSprite("tile", new Vector2(620,200)),
                dungeonFactory.MakeSprite("gap", new Vector2(640,200)),
                dungeonFactory.MakeSprite("stairs", new Vector2(660,200)),
                dungeonFactory.MakeSprite("ladder", new Vector2(680,200)),
                dungeonFactory.MakeSprite("brick", new Vector2(700,200)),
                itemFactory.MakeSprite("fairy", new Vector2(700,300)),
                itemFactory.MakeSprite("bomb", new Vector2(720,300)),
                itemFactory.MakeSprite("clock", new Vector2(740,300)),
                enemyFactory.MakeSprite("teal gel", new Vector2(340,300)),
                enemyFactory.MakeSprite("blkwhite gel", new Vector2(360,300)),
                enemyFactory.MakeSprite("green zol", new Vector2(440,300)),
                enemyFactory.MakeSprite("snake", new Vector2(460,300)),
                npcFactory.MakeSprite("flame", new Vector2(560,300)),
            };
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

            foreach (ISprite _sprite in sprites)
                _sprite.Update();
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Gray);
            _spriteBatch.Begin();
            //text.Draw(_spriteBatch);
            player.State.Sprite.Draw(_spriteBatch);
            foreach (ISprite _sprite in sprites)
                _sprite.Draw(_spriteBatch);
            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
