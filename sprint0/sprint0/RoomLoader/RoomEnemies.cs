using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace sprint0
{
    public class RoomEnemies
    {
        private readonly EnemiesSpriteFactory enemyFactory;
        private readonly BossesSpriteFactory bossFactory;
        public List<IEnemy> Enemies { get => enemies; set => enemies = value; }
        public List<IEnemy> EnemiesToDie { get => enemiesToDie; set => enemiesToDie = value; }
        public List<IEnemy> EnemiesToSpawn { get => enemiesToSpawn; set => enemiesToSpawn = value; }
        private List<IEnemy> enemies, enemiesToSpawn, enemiesToDie;
        private Vector2 keySpawnLocation;
        private bool endBehaviorExecuted;
        private readonly Game1 game;

        public RoomEnemies(Game1 game)
        {
            enemyFactory = new EnemiesSpriteFactory(game);
            bossFactory = new BossesSpriteFactory(game);
            enemiesToSpawn = new List<IEnemy>();
            enemies = new List<IEnemy>();
            enemiesToDie = new List<IEnemy>();
            this.game = game;
            endBehaviorExecuted = false;
        }

        public void AddEnemy(Vector2 location, EnemyEnum enemy)
        {
            if (enemy == EnemyEnum.Dodongo || enemy == EnemyEnum.Aquamentus)
                enemiesToSpawn.Add(bossFactory.MakeSprite(enemy, location));
            else
                enemiesToSpawn.Add(enemyFactory.MakeSprite(enemy, location));
        }
        public void UpdateOffset(Vector2 Offset)
        {
            EnemySpawnUpdate();
            foreach (IEnemy item in enemies)
                item.Location = new Rectangle(item.Location.X + (int)Offset.X, item.Location.Y + (int)Offset.Y, item.Location.Width, item.Location.Height);
        }


        public void RegisterEnemies(IEnumerable<IEnemy> unregEnemies)
            => enemiesToSpawn.AddRange(unregEnemies);

        public void RemoveEnemy(IEnemy enemy) => enemiesToDie.Add(enemy);

        public void RemoveDead()
        {
            foreach (IEnemy enemy in enemiesToDie)
            {
                keySpawnLocation = enemy.Location.Location.ToVector2();
                enemies.Remove(enemy);
            }
        }

        public void Update()
        {
            foreach (IEnemy enemy in enemies)
                enemy.Update();
            if (enemies.Count == 0 && !endBehaviorExecuted && game.Room.LoadLevel.RoomEffect.RoomEffects.Count == 0)
                RoomEndBehavior();
        }

        public void EnemySpawnUpdate()
        {
            if (enemiesToSpawn.Count > 0)
            {
                enemies.AddRange(enemiesToSpawn);
                enemiesToSpawn.Clear();
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (IEnemy enemy in enemies)
                enemy.Draw(spriteBatch);
        }

        private void RoomEndBehavior()
        {
            List<int> roomWithKey = new List<int> { 15, 17, 12, 3, 2, 10 };
            int roomWithBoomerang = 7;
            int roomWithMovableBlock = 5;
            Vector2 location = new Vector2(400, 300);
            if (roomWithKey.Contains(game.RoomIndex))
                game.Room.LoadLevel.RoomItems.AddItem(keySpawnLocation, ItemEnum.Key);
            else if (game.RoomIndex == roomWithBoomerang)
                game.Room.LoadLevel.RoomItems.AddItem(location, ItemEnum.Boomerang);
            else if (game.RoomIndex == roomWithMovableBlock)
                game.Room.LoadLevel.RoomBlocks.SwitchToMovableBlock();
            endBehaviorExecuted = true;
        }
    }
}
