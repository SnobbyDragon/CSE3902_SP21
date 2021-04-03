using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace sprint0
{
    public abstract class AbstractEnemy : IEnemy
    {
        public Rectangle Location { get; set; }
        public Texture2D Texture { get; set; }
        protected int damage = 0;
        public int Damage { get => damage; }
        protected int currentFrame;
        protected int totalFrames;
        protected int repeatedFrames;
        protected Direction direction;
        protected int width, height;
        protected int health;
        protected int moveCounter, dirChangeDelay;
        protected Random rand;
        protected readonly Game1 game;
        protected int damageTimer = 0;
        protected ItemSpawner itemSpawner;
        public EnemyType Type { get => EnemyType.None; }


        public AbstractEnemy(Texture2D texture, Vector2 location, Game1 game)
        {            
            rand = new Random();
            this.game = game;
            health = 50;
            Location = new Rectangle((int)location.X, (int)location.Y, (int)(width * Game1.Scale), (int)(height * Game1.Scale));
            Texture = texture;
            itemSpawner = new ItemSpawner(game.Room.LoadLevel.RoomItems);
            
        }

        public abstract void Draw(SpriteBatch spriteBatch);


        public virtual void Update()
        {

                moveCounter++;
                if (moveCounter == dirChangeDelay)
                {
                    ArbitraryDirection(30, 50);
                }
                if (damageTimer > 0) damageTimer--;
                CheckHealth();
                currentFrame = (currentFrame + 1) % (totalFrames * repeatedFrames);
                
                Rectangle loc = Location;
                loc.Offset(direction.ToVector2());
                Location = loc;
                
        }

        protected void ArbitraryDirection(int low, int high)
        {
            moveCounter = 0;
            direction = (Direction)rand.Next(0, 4);
            dirChangeDelay = rand.Next(low, high);
        }

        public virtual void ChangeDirection()
        {
            ArbitraryDirection(30, 50);
        }

        public virtual void CheckHealth()
        {
            if (health < 0) Perish();
        }

        public virtual void TakeDamage(int damage)
        {
            if (damageTimer == 0)
            {
                health -= damage;
                game.Room.RoomSound.AddSoundEffect("enemy damaged");
                damageTimer = 15;
            }
        }

        public void Perish()
        {
            itemSpawner.SpawnItem(this.GetType().Name, this.Location.Location.ToVector2());
            game.Room.LoadLevel.RoomEnemies.RemoveEnemy(this);
            game.Room.LoadLevel.RoomEffect.AddEffect(Location.Location.ToVector2(), "death");
            game.Room.RoomSound.AddSoundEffect("enemy death");
        }
    }
}
