﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace sprint0
{
    public enum Direction { n, s, e, w };
    public class Game1 : Game
    {
        private static PlayerSpriteFactory playerFactory;
        public static PlayerSpriteFactory PlayerFactory { get => playerFactory; }

        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private List<IController> controllerList;
        private List<ISprite> sprites;
        private ISprite sprite;
        private SpriteFont font;
        private IPlayer player;

        public ISprite Sprite { get => sprite; set => sprite = value; }
        public SpriteFont Font { get => font; set => font = value; }
        public IPlayer Player { get => player; set => player = value; }
        public List<ISprite> itemSprites, enemyNPCSprites, roomElementsSprites;
        public int itemIndex, enemyNPCIndex, roomElementsIndex;
        public ItemsWeaponsSpriteFactory itemFactory;
        //private ISprite roomBorder;

        // map width and height in pixels (does not include HUD) TODO scale up?
        public static int MapWidth { get; } = 256;
        public static int MapHeight { get; } = 176;
        public static int HUDHeight { get; } = 56;

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
            playerFactory = new PlayerSpriteFactory(this);
            player = new Link(this, new Vector2(200, 250));

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            DungeonFactory dungeonFactory = new DungeonFactory(this);
            itemFactory = new ItemsWeaponsSpriteFactory(this);
            HUDFactory hudFactory = new HUDFactory(this);

            itemIndex = enemyNPCIndex = 0;
            sprites = new List<ISprite> // testing sprites here
            {

                hudFactory.MakeSprite("hudM", new Vector2(400,0)),
                hudFactory.MakeSprite("rin 15", new Vector2(400,0)),
                hudFactory.MakeSprite("kin 5", new Vector2(400,0)),
                hudFactory.MakeSprite("bin 33", new Vector2(400,0)),
                hudFactory.MakeSprite("hin 5,10", new Vector2(400,0)),
                hudFactory.MakeSprite("hudA sword", new Vector2(400,0)),
                hudFactory.MakeSprite("hudB magical boomerang", new Vector2(400,0)),
                dungeonFactory.MakeSprite("room border", new Vector2(0, 56)),
                dungeonFactory.MakeSprite("room floor plain", new Vector2(97, 134)),
                dungeonFactory.MakeSprite("down open door", new Vector2(349, 55)),
                dungeonFactory.MakeSprite("up open door", new Vector2(349, 404)),
                dungeonFactory.MakeSprite("left open door", new Vector2(700, 231)),
                dungeonFactory.MakeSprite("right open door", new Vector2(0, 231)),
            };

            itemSprites = new List<ISprite>
            {
                itemFactory.MakeSprite("fairy", new Vector2(640,300),Direction.n,0),
                itemFactory.MakeSprite("bomb", new Vector2(660,300),Direction.n,0),
                itemFactory.MakeSprite("clock", new Vector2(680,300),Direction.n,0),
                itemFactory.MakeSprite("arrow", new Vector2(700,300),Direction.n,0),
                itemFactory.MakeSprite("compass", new Vector2(720,300),Direction.n,0),
                itemFactory.MakeSprite("key", new Vector2(740,300),Direction.n,0),
                itemFactory.MakeSprite("rupee", new Vector2(760,300),Direction.n,0),

            };

            //list of enemy, npc, and boss sprites
            EnemyNPCSprites enbSprite = new EnemyNPCSprites(this);
            enemyNPCSprites = enbSprite.LoadEnemyNPCSprites();

            //list of room element sprites
            DungeonSprites dungeonSprite = new DungeonSprites(this);
            roomElementsSprites = dungeonSprite.LoadDungeonSprites();
        }

        //Temporary until we get projectiles figured out
        public void AddArrow(Vector2 Location, Direction dir, int lifespan)
        {
            itemSprites.Add(itemFactory.MakeSprite("arrow", Location, dir, lifespan));
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
            foreach (ISprite _sprite in sprites)
                _sprite.Update();
            foreach (ISprite _sprite in itemSprites)
                _sprite.Update();
            foreach (ISprite _sprite in enemyNPCSprites)
                _sprite.Update();

            base.Update(gameTime);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Gray);
            _spriteBatch.Begin();
           
           
            foreach (ISprite _sprite in sprites)
                _sprite.Draw(_spriteBatch);
            itemSprites[itemIndex].Draw(_spriteBatch);
            enemyNPCSprites[enemyNPCIndex].Draw(_spriteBatch);
            roomElementsSprites[roomElementsIndex].Draw(_spriteBatch);
            player.Draw(_spriteBatch);
            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
