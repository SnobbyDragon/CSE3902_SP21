using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace sprint0
{
    public class Enemy : IEnemy
    {
        public Rectangle Location { get; set; }
        public Texture2D Texture { get; set; }
        protected int damage = 0;
        public int Damage { get => damage; }
        protected int currentFrame;
        protected string color;
        protected int totalFrames;
        protected int repeatedFrames;
        protected Dictionary<string, List<Rectangle>> colorMap;
        private readonly SpriteEffects s = SpriteEffects.FlipHorizontally;
        protected Direction direction;
        protected int width, height;
        protected int health;
        protected int moveCounter, dirChangeDelay;
        protected readonly Random rand;
        protected readonly Game1 game;
        protected int damageTimer = 0;

        public Enemy(Texture2D texture, Vector2 location, Game1 game)
        {
            rand = new Random();
            this.game = game;
            health = 50;
            Location = new Rectangle((int)location.X, (int)location.Y, (int)(width * Game1.Scale), (int)(height * Game1.Scale));
            Texture = texture;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (damageTimer % 2 == 0)
                switch (direction)
                {
                    case Direction.w:
                        spriteBatch.Draw(Texture, Location, colorMap[color][currentFrame / repeatedFrames % 2 + 2], Color.White, 0, new Vector2(0, 0), s, 0);
                        break;
                    case Direction.e:
                        spriteBatch.Draw(Texture, Location, colorMap[color][currentFrame / repeatedFrames % 2 + 2], Color.White);
                        break;
                    case Direction.s:
                        spriteBatch.Draw(Texture, Location, colorMap[color][0], Color.White);
                        break;
                    case Direction.n:
                        spriteBatch.Draw(Texture, Location, colorMap[color][1], Color.White);
                        break;
                }
        }

        public void Update()
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

        public void ChangeDirection()
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
                game.Room.LoadLevel.RoomSound.AddSoundEffect("enemy damaged");
                damageTimer = 15;
            }
        }

        public void Perish()
        {
            game.Room.LoadLevel.RoomEnemies.RemoveEnemy(this);
            game.Room.LoadLevel.RoomSound.AddSoundEffect("enemy death");
        }
    }
}
