using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace sprint0
{
    public class Room
    {
        private readonly Game1 game;

        private static PlayerSpriteFactory playerFactory;
        public static PlayerSpriteFactory PlayerFactory { get => playerFactory; }
        private IPlayer player;
        public IPlayer Player { get => player; set => player = value; }

        private WeaponsSpriteFactory weaponFactory;
        private ProjectileSpriteFactory projectileFactory;
        private EnemiesSpriteFactory enemyFactory;
        private DungeonFactory dungeonFactory;
        private HUDFactory hudFactory;

        private List<IProjectile> projectiles, projectilesToDie;
        private List<IWeapon> weapons, weaponsToDie;
        private List<IBlock> blocks;
        private List<IEnemy> enemies, enemiesToSpawn, enemiesToDie;
        private List<INpc> npcs;
        private List<IItem> items;
        private AllCollisionHandler collisionHandler;

        private List<ISprite> roomSprites, hudSprites, roomBaseSprites;
        private readonly int roomIndex;
        private Text text;

        private ISprite sprite;
        private SpriteFont font;
        public ISprite Sprite { get => sprite; set => sprite = value; }
        public SpriteFont Font { get => font; set => font = value; }

        public Room(Game1 game, int roomIndex)
        {
            this.game = game;
            this.roomIndex = roomIndex;
        }

        public void LoadContent()
        {
            LoadFactories();
            player = new Link(game, new Vector2(200, 250));
            LoadSpriteLists();
            collisionHandler = new AllCollisionHandler();
            LoadLevelSprites();
            LoadRoomBaseSprites();
            LoadHUDSprites();
            text = new Text(game);
        }

        private void LoadFactories()
        {
            playerFactory = new PlayerSpriteFactory(game);
            weaponFactory = new WeaponsSpriteFactory(game);
            projectileFactory = new ProjectileSpriteFactory(game);
            enemyFactory = new EnemiesSpriteFactory(game);
            dungeonFactory = new DungeonFactory(game);
            hudFactory = new HUDFactory(game);
        }

        private void LoadSpriteLists()
        {
            // avoids mutating enemies list during foreach
            weaponsToDie = new List<IWeapon>();
            projectilesToDie = new List<IProjectile>();
            enemiesToDie = new List<IEnemy>();
            enemiesToSpawn = new List<IEnemy>();

            weapons = new List<IWeapon>();
            projectiles = new List<IProjectile>();
            blocks = new List<IBlock>();
            enemies = new List<IEnemy>();
            npcs = new List<INpc>();
        }

        private void LoadLevelSprites()
        {
            LevelLoader levelLoader = new LevelLoader(game, roomIndex);
            (List<ISprite>, List<IProjectile>, List<IBlock>, List<IEnemy>, List<INpc>, List<IItem>) roomElements = levelLoader.LoadLevel();
            roomSprites = roomElements.Item1;
            projectiles = roomElements.Item2;
            blocks = roomElements.Item3;
            enemies = roomElements.Item4;
            npcs = roomElements.Item5;
            items = roomElements.Item6;
        }

        private void LoadRoomBaseSprites()
        {
            roomBaseSprites = new List<ISprite>
            {
                dungeonFactory.MakeSprite("room border", new Vector2(0, Game1.HUDHeight * Game1.Scale)),
                dungeonFactory.MakeSprite("room floor plain", new Vector2(32*Game1.Scale, Game1.HUDHeight * Game1.Scale + 32*Game1.Scale)),
            };
        }

        private void LoadHUDSprites()
        {
            hudSprites = new List<ISprite>
            {
                hudFactory.MakeSprite("hudM", new Vector2(0,0)),
                hudFactory.MakeSprite("rin 15", new Vector2(0,0)),
                hudFactory.MakeSprite("kin 5", new Vector2(0,0)),
                hudFactory.MakeSprite("bin 33", new Vector2(0,0)),
                hudFactory.MakeSprite("hin 5,10", new Vector2(0,0)),
                hudFactory.MakeSprite("hudA sword", new Vector2(0,0)),
                hudFactory.MakeSprite("hudB magical boomerang", new Vector2(0,0)),
            };
        }

        public void AddWeapon(Vector2 Location, Direction dir, string item, IPlayer source)
            => weapons.Add(weaponFactory.MakeWeapon(item, Location, dir, source));

        public void AddProjectile(Vector2 Location, Direction dir, string item, IEntity source)
            => projectiles.Add(projectileFactory.MakeProjectile(item, Location, dir, source));

        public void AddFireball(Vector2 location, Vector2 dir, IEntity source)
            => projectiles.Add(projectileFactory.MakeFireball(location, dir, source));

        public void AddEnemy(Vector2 location, string enemy)
            => enemiesToSpawn.Add(enemyFactory.MakeSprite(enemy, location));

        public void RegisterEnemies(IEnumerable<IEnemy> unregEnemies)
            => enemiesToSpawn.AddRange(unregEnemies);

        public void RemoveEnemy(IEnemy enemy) => enemiesToDie.Add(enemy);

        public void RemoveProjectile(IProjectile projectile) => projectilesToDie.Add(projectile);

        public void RemoveWeapon(IWeapon weapon) => weaponsToDie.Add(weapon);

        public void Update()
        {
            player.Update();

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

            collisionHandler.HandleAllCollisions(Player, enemies, weapons, projectiles, blocks, npcs, items);

            if (enemiesToSpawn.Count > 0)
            {
                enemies.AddRange(enemiesToSpawn);
                enemiesToSpawn.Clear();
            }

            RemoveDead();
        }

        private void RemoveDead()
        {
            foreach (IEnemy enemy in enemiesToDie)
                enemies.Remove(enemy);
            foreach (IWeapon weapon in weapons)
                if (!weapon.IsAlive()) RemoveWeapon(weapon);
            foreach (IProjectile projectile in projectiles)
                if (!projectile.IsAlive()) RemoveProjectile(projectile);
            foreach (IWeapon weapon in weaponsToDie)
                weapons.Remove(weapon);
            foreach (IProjectile projectile in projectilesToDie)
                projectiles.Remove(projectile);
            foreach (IWeapon weapon in weaponsToDie)
                weapons.Remove(weapon);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (ISprite _sprite in roomBaseSprites)
                _sprite.Draw(spriteBatch);
            foreach (ISprite _sprite in hudSprites)
                _sprite.Draw(spriteBatch);
            foreach (ISprite _sprite in roomSprites)
                _sprite.Draw(spriteBatch);
            foreach (IBlock block in blocks)
                block.Draw(spriteBatch);
            foreach (IWeapon weapon in weapons)
                weapon.Draw(spriteBatch);
            foreach (IProjectile projectile in projectiles)
                projectile.Draw(spriteBatch);
            foreach (IEnemy enemy in enemies)
                enemy.Draw(spriteBatch);
            foreach (INpc npc in npcs)
                npc.Draw(spriteBatch);
            foreach (IItem item in items)
                item.Draw(spriteBatch);
            foreach (IProjectile projectile in projectiles)
                projectile.Draw(spriteBatch);
            player.Draw(spriteBatch);

            if (roomIndex == 4)
            {
                text.Draw(spriteBatch);
            }
        }
    }
}
