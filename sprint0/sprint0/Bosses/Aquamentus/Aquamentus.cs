using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

// Author: Angela Li
/*
 * Last updated: 3/26/21 by shah.1440
 */
namespace sprint0
{
    public class Aquamentus : IEnemy
    {
        private readonly Game1 game;
        public Rectangle Location { get; set; }
        public Texture2D Texture { get; set; }

        private readonly int xOffset = 1, yOffset = 11, width = 24, height = 32;
        private readonly List<Rectangle> sources;

        private int currFrame;
        private readonly int totalFrames, repeatedFrames;

        private Direction direction;
        private int moveCount;
        private readonly int moveDelay = 5, minDistance = (int)(Game1.Width * Game1.Scale * 0.2), maxDistance = (int)(Game1.Width * Game1.Scale * 0.8);
        private readonly bool isDead;

        private readonly int fireballRate = 100;
        private int fireballCounter = 0;
        private int health;
        public int Damage { get; }
        private ItemSpawner itemSpawner;


        public Aquamentus(Texture2D texture, Vector2 location, Game1 game)
        {
            health = 15;
            this.game = game;
            Location = new Rectangle((int)location.X, (int)location.Y, (int)(width * Game1.Scale), (int)(height * Game1.Scale));
            Texture = texture;

            currFrame = 0;
            totalFrames = 4;
            repeatedFrames = 14;
            sources = SpritesheetHelper.GetFramesH(xOffset, yOffset, width, height, totalFrames);

            direction = Direction.e;
            moveCount = 0;

            isDead = false;
            itemSpawner = new ItemSpawner(game.Room.LoadLevel.RoomItems);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (!isDead)
                spriteBatch.Draw(Texture, Location, sources[currFrame / repeatedFrames], Color.White);
        }

        public void Update()
        {
            CheckHealth();
            if (!isDead)
            {
                if (CanChangeDirection())
                    ChangeDirection();
                Move();
                currFrame = (currFrame + 1) % (totalFrames * repeatedFrames);
                if (CanShoot())
                    ShootFireballs();
            }
        }

        private void Move()
        {
            if (moveCount == moveDelay)
            {
                moveCount = 0;
                Rectangle loc = Location;
                loc.Offset(direction.ToVector2());
                Location = loc;
            }
            else
            {
                moveCount++;
            }
        }

        private bool CanChangeDirection()
        {
            int distanceToLink = Math.Abs(Location.Left - (int)Link.position.X);
            return distanceToLink > maxDistance || distanceToLink < minDistance;
        }

        public void ChangeDirection()
        {
            direction = direction.OppositeDirection();
        }

        private void CheckHealth()
        {
            if (health < 0) Perish();
        }

        public void TakeDamage(int damage)
        {
            health -= damage;
            game.Room.RoomSound.AddSoundEffect("enemy damaged");
        }

        public void Perish()
        {
            itemSpawner.SpawnItem(this.GetType().Name, this.Location.Location.ToVector2());
            game.Room.LoadLevel.RoomEnemies.RemoveEnemy(this);
            game.Room.RoomSound.AddSoundEffect("enemy death");
        }

        private bool CanShoot()
        {
            fireballCounter++;
            fireballCounter %= fireballRate;
            return fireballCounter == 0;
        }

        private void ShootFireballs()
        {
            game.Room.RoomSound.AddSoundEffect(GetType().Name.ToLower());
            Vector2 dir = Link.position - Location.Center.ToVector2();
            dir.Normalize();
            game.Room.LoadLevel.RoomProjectile.AddFireball(Location.Center.ToVector2(), dir, this);
            game.Room.LoadLevel.RoomProjectile.AddFireball(Location.Center.ToVector2(), Vector2.Transform(dir, Matrix.CreateRotationZ((float)(Math.PI / 6))), this); // 30 degrees up
            game.Room.LoadLevel.RoomProjectile.AddFireball(Location.Center.ToVector2(), Vector2.Transform(dir, Matrix.CreateRotationZ((float)(-Math.PI / 6))), this); // 30 degrees down
        }
    }
}
