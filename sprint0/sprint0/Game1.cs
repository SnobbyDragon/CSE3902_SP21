using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace sprint0
{
    public class Game1 : Game
    {

        private readonly GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private List<IController> controllerList;

        private static PlayerSpriteFactory playerFactory;
        public static PlayerSpriteFactory PlayerFactory { get => playerFactory; }
        private IPlayer player;
        public IPlayer Player { get => player; set => player = value; }

        private ItemsWeaponsSpriteFactory itemFactory;
        private EnemiesSpriteFactory enemyFactory;

        private List<IProjectile> projectiles, projectilesToDie;
        private List<IWeapon> weapons, weaponsToDie;
        private List<IBlock> blocks;
        private List<IEnemy> enemies, enemiesToSpawn, enemiesToDie;
        private List<INpc> npcs;
        private List<IItem> items;
        private AllCollisionHandler collisionHandler;

        private List<ISprite> roomSprites, hudSprites, roomBaseSprites;
        private LevelLoader levelLoader;
        public bool changeRoom;
        public int roomIndex;
        public readonly int numRooms = 18;
        private Text text;

        private ISprite sprite;
        private SpriteFont font;
        public ISprite Sprite { get => sprite; set => sprite = value; }
        public SpriteFont Font { get => font; set => font = value; }

        // map width and height in pixels (does not include HUD)
        public static int Width { get; } = 256;
        public static int MapHeight { get; } = 176;
        public static int HUDHeight { get; } = 56;
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
            controllerList = new List<IController>
            {
                new KeyboardController(this),
                new MouseController(this)
            };
            playerFactory = new PlayerSpriteFactory(this);
            player = new Link(this, new Vector2(200, 250));

            //note: the integer refers to the room number to load
            changeRoom = true;
            roomIndex = 1;
            levelLoader = new LevelLoader(this, roomIndex);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            DungeonFactory dungeonFactory = new DungeonFactory(this);
            HUDFactory hudFactory = new HUDFactory(this);
            itemFactory = new ItemsWeaponsSpriteFactory(this);
            enemyFactory = new EnemiesSpriteFactory(this);

            weapons = new List<IWeapon>();
            projectiles = new List<IProjectile>();
            blocks = new List<IBlock>();
            enemies = new List<IEnemy>();
            npcs = new List<INpc>();

            collisionHandler = new AllCollisionHandler();

            /*
             * below code was commented out so it's not confusing when testing. The following code is stuff for after we get all of the level loading stuff done/to test level loading
             * commented out code:
             * 1. separates out hud and the base elements of the room (plain floor and room border)
             * 2. loads sprites for the level
             */
            weaponsToDie = new List<IWeapon>();
            projectilesToDie = new List<IProjectile>();
            (List<ISprite>, List<IProjectile>, List<IBlock>, List<IEnemy>, List<INpc>, List<IItem>) roomElements = levelLoader.LoadLevel();
            roomSprites = roomElements.Item1;
            projectiles = roomElements.Item2;
            blocks = roomElements.Item3;
            enemies = roomElements.Item4;
            npcs = roomElements.Item5;
            items = roomElements.Item6;
            enemiesToDie = new List<IEnemy>();
            enemiesToSpawn = new List<IEnemy>(); // used for spawning new enemies; avoids mutating enemies list during foreach
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

            text = new Text(this);
        }

        public void AddWeapon(Vector2 Location, Direction dir, string item, IPlayer source)
        {
            weapons.Add(itemFactory.MakeWeapon(item, Location, dir, source));
        }

        public void AddProjectile(Vector2 Location, Direction dir, string item, IEntity source)
        {
            projectiles.Add(itemFactory.MakeProjectile(item, Location, dir, source));
        }

        public void AddFireball(Vector2 location, Vector2 dir, IEntity source)
        {
            projectiles.Add(itemFactory.MakeFireball(location, dir, source));
        }

        public void AddEnemy(Vector2 location, string enemy)
        {
            enemiesToSpawn.Add(enemyFactory.MakeSprite(enemy, location));
        }

        public void RemoveEnemy(IEnemy enemy)
        {
            enemiesToDie.Add(enemy);
        }

        public void RemoveProjectile(IProjectile projectile)
        {
            projectilesToDie.Add(projectile);
        }

        public void RemoveWeapon(IWeapon weapon)
        {
            weaponsToDie.Add(weapon);
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            foreach (IController controller in controllerList)
                controller.Update();
            player.Update();

            //NOTE: changes room if needed
            if (changeRoom)
            {
                levelLoader = new LevelLoader(this, roomIndex);
                (List<ISprite>, List<IProjectile>, List<IBlock>, List<IEnemy>, List<INpc>, List<IItem>) roomElements = levelLoader.LoadLevel();
                roomSprites = roomElements.Item1;
                projectiles = roomElements.Item2;
                blocks = roomElements.Item3;
                enemies = roomElements.Item4;
                npcs = roomElements.Item5;
                items = roomElements.Item6;
                changeRoom = false;
            }

            //NOTE: to update level sprites and hud
            foreach (ISprite _sprite in roomSprites)
                _sprite.Update();
            foreach (ISprite _sprite in hudSprites)
                _sprite.Update();
            foreach (IProjectile projectile in projectiles)
                projectile.Update();
            foreach (IWeapon weapon in weapons)
                weapon.Update();
            foreach (IBlock block in blocks)
                block.Update();
            foreach (IEnemy enemy in enemies)
                enemy.Update();
            foreach (INpc npc in npcs)
                npc.Update();
            foreach (IItem item in items)
                item.Update();

            // handles collisions
            collisionHandler.HandleAllCollisions(Player, enemies, weapons, projectiles, blocks, npcs, items);
           
            // after all traversals, add new enemies
            if (enemiesToSpawn.Count > 0)
            {
                enemies.AddRange(enemiesToSpawn);
                enemiesToSpawn.Clear();
            }
            foreach (IEnemy enemy in enemiesToDie)
            {
                enemies.Remove(enemy);
            }

            foreach (IWeapon weapon in weapons)
            {
                if (!weapon.IsAlive()) RemoveWeapon(weapon);
            }
            foreach (IProjectile projectile in projectiles)
            {
                if (!projectile.IsAlive()) RemoveProjectile(projectile);
            }
            foreach (IWeapon weapon in weaponsToDie)
            {
                weapons.Remove(weapon);
            }
            foreach (IProjectile projectile in projectilesToDie)
            {
                projectiles.Remove(projectile);
            }

            foreach (IWeapon weapon in weaponsToDie)
            {
                weapons.Remove(weapon);
            }
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
            foreach (IBlock block in blocks)
                block.Draw(_spriteBatch);
            foreach (IWeapon weapon in weapons)
                weapon.Draw(_spriteBatch);
            foreach (IProjectile projectile in projectiles)
                projectile.Draw(_spriteBatch);
            foreach (IEnemy enemy in enemies)
                enemy.Draw(_spriteBatch);
            foreach (INpc npc in npcs)
                npc.Draw(_spriteBatch);
            foreach (IItem item in items)
                item.Draw(_spriteBatch);
            foreach (IProjectile projectile in projectiles)
                projectile.Draw(_spriteBatch);
            player.Draw(_spriteBatch);

            if (roomIndex == 4)
            {
                text.Draw(_spriteBatch);
            }

            _spriteBatch.End();
            base.Draw(gameTime);
        }

        public void ResetGame()
        {
            // reset game timer
            ResetElapsedTime();
            Initialize();
        }
    }
}
