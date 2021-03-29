using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace sprint0
{
    public class RoomEnemies
    {
        private readonly EnemiesSpriteFactory enemyFactory;
        public List<IEnemy> Enemies { get => enemies; set => enemies = value; }
        public List<IEnemy> EnemiesToDie { get => enemiesToDie; set => enemiesToDie = value; }
        public List<IEnemy> EnemiesToSpawn { get => enemiesToSpawn; set => enemiesToSpawn = value; }
        private List<IEnemy> enemies, enemiesToSpawn, enemiesToDie;

        public RoomEnemies(Game1 game)
        {
            enemyFactory = new EnemiesSpriteFactory(game);
            enemiesToSpawn = new List<IEnemy>();
            enemies = new List<IEnemy>();
            enemiesToDie = new List<IEnemy>();
        }

        public void AddEnemy(Vector2 location, string enemy)
            => enemiesToSpawn.Add(enemyFactory.MakeSprite(enemy, location));

        public void RegisterEnemies(IEnumerable<IEnemy> unregEnemies)
            => enemiesToSpawn.AddRange(unregEnemies);

        public void RemoveEnemy(IEnemy enemy) => enemiesToDie.Add(enemy);

        public void RemoveDead()
        {
            foreach (IEnemy enemy in enemiesToDie)
                enemies.Remove(enemy);
        }

        public void Update()
        {
            foreach (IEnemy enemy in enemies)
                enemy.Update();
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
    }
}
