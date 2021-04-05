using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

// Author: Angela Li
//Last updated 3/28 by Hannah
namespace sprint0
{
    public class Gleeok : IEnemy
    {
        private Game1 game;
        public Rectangle Location { get; set; }
        public Texture2D Texture { get; set; }
        private readonly int xOffset = 196, yOffset = 11, width = 24, height = 32;
        private readonly List<Rectangle> sources;
        private int currFrame;
        private readonly int totalFrames, repeatedFrames;
        private List<IEnemy> necks;
        private int health;
        public EnemyType Type { get => EnemyType.Gleeok; }
        public int Damage { get => 0; }
        private ItemSpawner itemSpawner;

        public Gleeok(Texture2D texture, Vector2 location, Game1 game)
        {
            health = 25;
            Location = new Rectangle((int)location.X, (int)location.Y, (int)(width * Game1.Scale), (int)(height * Game1.Scale));
            Texture = texture;
            this.game = game;
            currFrame = 0;
            totalFrames = 3;
            repeatedFrames = 12;
            sources = SpritesheetHelper.GetFramesH(xOffset, yOffset, width, height, totalFrames);
            sources.Add(new Rectangle(xOffset + width + 1, yOffset, width, height));

            necks = new List<IEnemy>() {
                new GleeokNeck(Texture, game,Location),
                new GleeokNeck(Texture, game,Location),
            };
            itemSpawner = new ItemSpawner(game.Room.LoadLevel.RoomItems);
        }



        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Location, sources[currFrame / repeatedFrames], Color.White);
            foreach (IEnemy sprite in necks)
                sprite.Draw(spriteBatch);

        }

        public void Update()
        {
            CheckHealth();
            currFrame = (currFrame + 1) % (totalFrames * repeatedFrames);
            foreach (IEnemy sprite in necks)
                sprite.Update();

        }

        public void ChangeDirection()
        {
        }

        private void CheckHealth()
        {
            int countDeadNecks = 0;
            foreach (GleeokNeck neck in necks)
            {
                if (neck.IsDead()) countDeadNecks++;
            }
            if ((health < 0 && countDeadNecks == necks.Count) || countDeadNecks == necks.Count) Perish();
        }

        public void TakeDamage(int damage)
        {
            health -= damage;
            game.Room.RoomSound.AddSoundEffect(SoundEnum.EnemyDamaged);
        }

        public void Perish()
        {
            itemSpawner.SpawnItem(ParseEnemy(GetType().Name), Location.Location.ToVector2());
            game.Room.LoadLevel.RoomEnemies.RemoveEnemy(this);
            game.Room.LoadLevel.RoomEffect.AddEffect(Location.Location.ToVector2(), EffectEnum.Death);
            game.Room.RoomSound.AddSoundEffect(SoundEnum.EnemyDeath);
        }
        public EnemyEnum ParseEnemy(string enemy)
             => (EnemyEnum)Enum.Parse(typeof(EnemyEnum), enemy, true);
    }
}
