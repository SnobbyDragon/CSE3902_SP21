﻿using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

// Author: Angela Li
namespace sprint0
{
    public class Patra : IEnemy
    {
        public Rectangle Location { get; set; }
        public Texture2D Texture { get; set; }
        private Rectangle source;
        private readonly List<SpriteEffects> effects;
        private int currFrame, moveCounter, health, damageTimer = 0;
        private readonly int totalFrames, repeatedFrames, totalMinions = 8, moveDelay, width = 16, height = 11, damageTime = 10;
        // moveDelay: delay to make slower bc floats mess up drawings; must be < totalFrames*repeatedFrames
        private readonly List<IEnemy> minions;
        private Vector2 destination; //TODO depends on link. i think it keeps optimal distance so minions can hit link
        private readonly Random rand;
        private readonly Game1 game;
        public int Damage { get => 4; }
        private bool canTakeDamage;
        private readonly ItemSpawner itemSpawner;
        public EnemyType Type { get => EnemyType.Patra; }
        private bool minionsExist;

        public Patra(Texture2D texture, Vector2 location, Game1 game)
        {
            this.game = game;
            health = 25;
            Location = new Rectangle((int)location.X, (int)location.Y, (int)(width * Game1.Scale), (int)(height * Game1.Scale));
            Texture = texture;
            source = new Rectangle(1, 157, width, height);
            currFrame = 0;
            totalFrames = 2;
            repeatedFrames = 2;
            minionsExist = false;
            // flips to animate flying
            effects = new List<SpriteEffects>
            {
                SpriteEffects.None,
                SpriteEffects.FlipHorizontally
            };

            // has 8 orange minions
            minions = new List<IEnemy>();
            game.Room.LoadLevel.RoomEnemies.RegisterEnemies(minions);

            rand = new Random();
            GenerateDest();

            moveCounter = 0;
            moveDelay = 5; // slow

            canTakeDamage = false;
            itemSpawner = new ItemSpawner(game.Room.LoadLevel.RoomItems);
        }
        public void UpdateDifficulty(GameStateMachine.Mode mode)
        {
            if (game.stateMachine.GetMode() == GameStateMachine.Mode.easy && mode == GameStateMachine.Mode.hard)
            {
                health *= 2;
            }
            if (game.stateMachine.GetMode() == GameStateMachine.Mode.hard && mode == GameStateMachine.Mode.easy)
            {
                health /= 2;
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            if (damageTimer % 2 == 0)
                spriteBatch.Draw(Texture, Location, source, Color.White, 0, new Vector2(0, 0), effects[currFrame / repeatedFrames], 0);
        }

        public void Update()
        {
            CheckHealth();
            if (minions.Count == 0 && !minionsExist)
            {
                for (int i = 0; i < totalMinions; i++)
                    minions.Add(new PatraMinion(Texture, this, 360 / totalMinions * i, game));
                game.Room.LoadLevel.RoomEnemies.RegisterEnemies(minions);
                minionsExist = true;
            }
            if (!game.Room.FreezeEnemies)
            {
                Vector2 dist = destination - Location.Location.ToVector2();
                if (dist.Length() < 5) GenerateDest();
                else if (moveCounter == moveDelay)
                {
                    dist.Normalize();
                    Rectangle loc = Location;
                    loc.Offset(dist.ApproxDirection().ToVector2());
                    Location = loc;
                    moveCounter = 0;
                }
                moveCounter++;
                currFrame = (currFrame + 1) % (totalFrames * repeatedFrames);
            }
            if (damageTimer > 0) damageTimer--;
        }

        public void ChangeDirection() => GenerateDest();
        private void CheckHealth()
        {
            //int minionCount = 0;
            PatraMinion toRemove = null;
            foreach (PatraMinion minion in minions)
            {
                // minionCount++;
                if (minion.CheckHealth() < 0)
                    toRemove = minion;
            }
            if (toRemove != null) RemoveMinion(toRemove);
            if (minions.Count == 0)
            {
                canTakeDamage = true;
                if (health < 0) Perish();
            }
        }

        private void RemoveMinion(PatraMinion minion1)
        {
            minions.Remove(minion1);
            game.Room.RoomSound.AddSoundEffect(ParseSound(GetType().Name));
        }
        public void TakeDamage(int damage)
        {
            if (canTakeDamage && damageTimer == 0)
            {
                damageTimer = damageTime;
                health -= damage;
                game.Room.RoomSound.AddSoundEffect(SoundEnum.EnemyDamaged);
            }
        }

        public void Perish()
        {
            itemSpawner.SpawnItem(ParseEnemy(this.GetType().Name), this.Location.Location.ToVector2());
            game.Room.LoadLevel.RoomEnemies.RemoveEnemy(this);
            game.Room.LoadLevel.RoomEffect.AddEffect(Location.Location.ToVector2(), EffectEnum.Death);
            game.Room.RoomSound.AddSoundEffect(SoundEnum.EnemyDeath);
        }

        // generates a new destination
        private void GenerateDest()
        {
            destination = new Vector2(
                rand.Next((int)(Game1.BorderThickness * Game1.Scale), (int)((Game1.Width - Game1.BorderThickness) * Game1.Scale)),
                rand.Next((int)((Game1.HUDHeight + Game1.BorderThickness) * Game1.Scale), (int)((Game1.HUDHeight + Game1.MapHeight - Game1.BorderThickness) * Game1.Scale)));
        }
        public EnemyEnum ParseEnemy(string enemy)
             => (EnemyEnum)Enum.Parse(typeof(EnemyEnum), enemy, true);
        private SoundEnum ParseSound(string sound)
             => (SoundEnum)Enum.Parse(typeof(SoundEnum), sound, true);
    }
}
