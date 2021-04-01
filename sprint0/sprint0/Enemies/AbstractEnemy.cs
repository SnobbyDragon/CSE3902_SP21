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
        protected readonly Random rand;
        protected readonly Game1 game;
        protected int damageTimer = 0;
        private readonly ItemSpawner itemSpawner;
        protected int xOffsetSpawn = 138, yOffsetSpawn = 185, sizeSpawn = 16, totalFramesSpawn = 3, repeatedFramesSpawn = 6;
        protected int frameSpawn = 0;
        protected List<Rectangle> sourcesSpawn;

        public AbstractEnemy(Texture2D texture, Vector2 location, Game1 game)
        {
            rand = new Random();
            this.game = game;
            health = 50;
            Location = new Rectangle((int)location.X, (int)location.Y, (int)(width * Game1.Scale), (int)(height * Game1.Scale));
            Texture = texture;
            itemSpawner = new ItemSpawner(game.Room.LoadLevel.RoomItems);
            sourcesSpawn = SpritesheetHelper.GetFramesH(xOffsetSpawn, yOffsetSpawn, sizeSpawn, sizeSpawn, totalFramesSpawn);
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
            if (frameSpawn < totalFramesSpawn * repeatedFramesSpawn)
            {
                frameSpawn++;
            }
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

        public void CheckHealth()
        {
            if (health < 0) Perish();
        }

        public void TakeDamage(int damage)
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
            itemSpawner.SpawnItem(this.GetType().Name,this.Location.Location.ToVector2());
            game.Room.LoadLevel.RoomEnemies.RemoveEnemy(this);
            game.Room.LoadLevel.RoomMisc.AddMisc(new DeathCloud(game.Content.Load<Texture2D>("Images/Link"), Location.Center.ToVector2()));
            game.Room.RoomSound.AddSoundEffect("enemy death");
        }
    }
}
