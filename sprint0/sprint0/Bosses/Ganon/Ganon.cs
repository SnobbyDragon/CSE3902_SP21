using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

// Author: Angela Li
/*
 * Last updated: 3/27/21 by li.10011
 */
namespace sprint0
{
    public class Ganon : IEnemy
    {
        private readonly Game1 game;
        public Rectangle Location { get; set; }
        public Texture2D Texture { get; set; }
        private readonly int xOffset = 40, yOffset = 154, width, height;
        private readonly List<Rectangle> sources;
        private int currFrame, counter, deathCounter;
        private readonly int totalFrames, invisibleTime = 200, visibleTime = 100, teleportTime = 50;
        private bool isVisible, isDead;
        private readonly Random rand;
        private readonly int fireballRate = 100;
        private int fireballCounter = 0;
        private int health;
        public int Damage { get => 8; }
        public EnemyType Type { get => EnemyType.None; }
        private readonly ItemSpawner itemSpawner;
        private int damageTimer = 0;
        private readonly int damageTime = 10;
        public Ganon(Texture2D texture, Vector2 location, Game1 game)
        {
            health = 25;
            width = height = 32;
            Location = new Rectangle((int)location.X, (int)location.Y, (int)(width * Game1.Scale), (int)(height * Game1.Scale));
            Texture = texture;
            this.game = game;
            currFrame = 0;
            totalFrames = 6;
            sources = SpritesheetHelper.GetFramesH(xOffset, yOffset, width, height, totalFrames);
            rand = new Random();
            isVisible = true;
            isDead = false;
            counter = 0;
            deathCounter = 0;
            itemSpawner = new ItemSpawner(game.Room.LoadLevel.RoomItems);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (isVisible && !isDead && damageTimer % 2 == 0)
                spriteBatch.Draw(Texture, Location, sources[currFrame], Color.White);
        }

        public void Update()
        {
            if (damageTimer > 0) damageTimer--;
            if (isDead)
            {
                if (deathCounter == 0)
                {
                    new GanonFireballExplosion(Texture, this, game);
                    game.Room.LoadLevel.RoomItems.AddItem(Location.Center.ToVector2(), ItemEnum.GanonTriforceAshes);
                    game.Room.LoadLevel.RoomEffect.AddEffect(new GanonDeathCloud(Texture, Location.Center.ToVector2()));
                }
                deathCounter++;
                if (deathCounter == 70) Perish();
            }
            else if (isVisible)
            {
                CheckHealth();
                if (counter == visibleTime)
                {
                    isVisible = false;
                    counter = 0;
                }
            }
            else
            {
                if (counter == invisibleTime)
                {
                    isVisible = true;
                    counter = 0;
                    currFrame = (currFrame + 1) % (totalFrames - 1);
                    CheckHealth();
                }
                else if (counter == teleportTime)
                {
                    Teleport();
                    CheckHealth();
                }
            }
            counter++;
            if (CanShoot()) ShootFireball();
        }

        public void ChangeDirection() { }

        private void CheckHealth()
        {
            if (health < 0) isDead = true;
            if (health < 20) currFrame = 5;
        }
        public void TakeDamage(int damage)
        {
            if (damageTimer == 0)
            {
                damageTimer = damageTime;
                health -= damage;
                isVisible = true;
                game.Room.RoomSound.AddSoundEffect(SoundEnum.EnemyDamaged);
            }
        }

        public void Perish()
        {
            itemSpawner.SpawnItem(ParseEnemy(GetType().Name), Location.Location.ToVector2());
            game.Room.LoadLevel.RoomEnemies.RemoveEnemy(this);
            game.Room.RoomSound.AddSoundEffect(SoundEnum.EnemyDeath);
        }

        private bool CanShoot()
        {
            fireballCounter++;
            fireballCounter %= fireballRate;
            return fireballCounter == 0;
        }

        private void ShootFireball()
        {
            game.Room.RoomSound.AddSoundEffect(ParseSound(GetType().Name));
            Vector2 dir = game.Room.Player.Pos - Location.Center.ToVector2();
            dir.Normalize();
            game.Room.LoadLevel.RoomProjectile.AddFireball(Location.Location.ToVector2(), dir, this);
        }

        public void Teleport()
        {
            Vector2 loc = new Vector2(
                rand.Next((int)(Game1.BorderThickness * Game1.Scale), (int)((Game1.Width - Game1.BorderThickness - width) * Game1.Scale)),
                rand.Next((int)((Game1.HUDHeight + Game1.BorderThickness) * Game1.Scale), (int)((Game1.HUDHeight + Game1.MapHeight - Game1.BorderThickness - height) * Game1.Scale)));
            Location = new Rectangle((int)loc.X, (int)loc.Y, Location.Width, Location.Height);
        }
        public EnemyEnum ParseEnemy(string enemy)
             => (EnemyEnum)Enum.Parse(typeof(EnemyEnum), enemy, true);
        private SoundEnum ParseSound(string sound)
             => (SoundEnum)Enum.Parse(typeof(SoundEnum), sound, true);
    }
}
