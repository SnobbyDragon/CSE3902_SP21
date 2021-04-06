using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

// Author: Angela Li
namespace sprint0
{
    public class Manhandla : IEnemy
    {
        private readonly Game1 game;
        public Rectangle Location { get; set; }
        public Texture2D Texture { get; set; }
        private readonly int size = 16;
        private Rectangle source;
        private readonly List<IEnemy> limbs;
        private double speed;
        private Vector2 destination;
        private readonly Random rand;
        public int Damage { get => 2; }
        private ItemSpawner itemSpawner;
        public EnemyType Type { get => EnemyType.Manhandla; }
        private bool limbsExist;

        public Manhandla(Texture2D texture, Vector2 location, Game1 game)
        {
            Location = new Rectangle((int)location.X, (int)location.Y, (int)(size * Game1.Scale), (int)(size * Game1.Scale));
            Texture = texture;
            this.game = game;
            source = new Rectangle(69, 89, size, size); //center
            speed = 1;
            limbsExist = false;
            limbs = new List<IEnemy>();
            
            rand = new Random();
            GenerateDest();
            itemSpawner = new ItemSpawner(game.Room.LoadLevel.RoomItems);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Location, source, Color.White);
        }

        public void Update()
        {

            CheckHealth();
            if (limbs.Count == 0 && !limbsExist)
            {
                limbs.Add(new ManhandlaLimb(Texture, this, Direction.n, game));
                limbs.Add(new ManhandlaLimb(Texture, this, Direction.s, game));
                limbs.Add(new ManhandlaLimb(Texture, this, Direction.e, game));
                limbs.Add(new ManhandlaLimb(Texture, this, Direction.w, game));
                game.Room.LoadLevel.RoomEnemies.RegisterEnemies(limbs);
                limbsExist = true;
            }
            Vector2 dist = destination - Location.Location.ToVector2();
            if (dist.Length() < 5)
            {
                GenerateDest();
            }
            else
            {
                dist.Normalize();
                Rectangle loc = Location;
                loc.Offset((int)(speed * dist.ApproxDirection().ToVector2().X), (int)(speed * dist.ApproxDirection().ToVector2().Y));
                Location = loc;
            }


        }

        public void ChangeDirection()
        {
            GenerateDest();
        }

        private void CheckHealth()
        {
            int limbCount = 0;
            ManhandlaLimb toRemove = null;
            if (limbs != null)
            {
                foreach (ManhandlaLimb limb in limbs)
            {
                limbCount++;
                if (limb.CheckHealth() < 0)
                {
                    toRemove = limb;
                }
            }
            if (toRemove != null) RemoveLimb(toRemove);          
            }
            if (limbCount == 0 && limbsExist) Perish();
        }

        private void RemoveLimb(ManhandlaLimb limb1)
        {
            limbs.Remove(limb1);
            foreach (ManhandlaLimb limb in limbs)
            {
                limb.IncreaseFireballRate();
            }
            double speedIncreaseRate = 1.5;
            speed *= speedIncreaseRate;
        }

        public void TakeDamage(int damage)
        {
        }

        public void Perish()
        {
            itemSpawner.SpawnItem(ParseEnemy(GetType().Name), Location.Location.ToVector2());
            game.Room.LoadLevel.RoomEnemies.RemoveEnemy(this);
            game.Room.LoadLevel.RoomEffect.AddEffect(Location.Location.ToVector2(), EffectEnum.Death);
            game.Room.RoomSound.AddSoundEffect(SoundEnum.EnemyDeath);
        }

        private void GenerateDest()
        {
            game.Room.RoomSound.AddSoundEffect(ParseSound(GetType().Name));
            destination = new Vector2(
                rand.Next((int)(Game1.BorderThickness * Game1.Scale), (int)((Game1.Width - Game1.BorderThickness) * Game1.Scale)),
                rand.Next((int)((Game1.HUDHeight + Game1.BorderThickness) * Game1.Scale), (int)((Game1.HUDHeight + Game1.MapHeight - Game1.BorderThickness) * Game1.Scale))
                );
        }
        public EnemyEnum ParseEnemy(string enemy)
             => (EnemyEnum)Enum.Parse(typeof(EnemyEnum), enemy, true);
        private SoundEnum ParseSound(string sound)
             => (SoundEnum)Enum.Parse(typeof(SoundEnum), sound, true);
    }
}
