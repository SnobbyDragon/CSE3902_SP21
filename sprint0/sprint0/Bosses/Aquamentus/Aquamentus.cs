using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

// Author: Angela Li
/*
 * Last updated: 04/04/21 by shah.1440
 */
namespace sprint0
{
    public class Aquamentus : AbstractEnemy
    {
        private readonly int xOffset = 1, yOffset = 11;
        private readonly List<Rectangle> sources;

        private readonly int moveDelay = 5, minDistance = (int)(Game1.Width * Game1.Scale * 0.2), maxDistance = (int)(Game1.Width * Game1.Scale * 0.8);

        private readonly int fireballRate = 100;
        private int fireballCounter = 0;
        private readonly int damageTime = 10;


        public Aquamentus(Texture2D texture, Vector2 location, Game1 game) : base(texture, location, game)
        {
            health = 15;
            width = 24;
            height = 32;
            Location = new Rectangle((int)location.X, (int)location.Y, (int)(width * Game1.Scale), (int)(height * Game1.Scale));
            Texture = texture;

            currentFrame = 0;
            totalFrames = 4;
            repeatedFrames = 14;
            sources = SpritesheetHelper.GetFramesH(xOffset, yOffset, width, height, totalFrames);

            direction = Direction.East;
            moveCounter = 0;

            itemSpawner = new ItemSpawner(game.Room.LoadLevel.RoomItems);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {

            if (damageTimer % 2 == 0)
                spriteBatch.Draw(Texture, Location, sources[currentFrame / repeatedFrames], Color.White);
        }

        public override void Update()
        {

            CheckHealth();
            if (CanChangeDirection())
                ChangeDirection();
            Move();
            currentFrame = (currentFrame + 1) % (totalFrames * repeatedFrames);

            if (CanShoot())
                ShootFireballs();
            if (damageTimer > 0)
                damageTimer--;



        }

        private void Move()
        {
            if (moveCounter == moveDelay)
            {
                moveCounter = 0;
                Rectangle loc = Location;
                loc.Offset(direction.ToVector2());
                Location = loc;
            }
            else
            {
                moveCounter++;
            }
        }

        private bool CanChangeDirection()
        {
            int distanceToLink = Math.Abs(Location.Left - (int)Link.position.X);
            return distanceToLink > maxDistance || distanceToLink < minDistance;
        }

        public override void ChangeDirection()
        {
            direction = direction.OppositeDirection();
        }


        public override void TakeDamage(int damage)
        {
            if (damageTimer == 0)
            {
                health -= damage;
                game.Room.RoomSound.AddSoundEffect(SoundEnum.EnemyDamaged);
                damageTimer = damageTime;
            }
        }

        private bool CanShoot()
        {
            fireballCounter++;
            fireballCounter %= fireballRate;
            return fireballCounter == 0;
        }

        private void ShootFireballs()
        {
            game.Room.RoomSound.AddSoundEffect(ParseSound(GetType().Name));
            Vector2 dir = Link.position - Location.Center.ToVector2();
            dir.Normalize();
            game.Room.LoadLevel.RoomProjectile.AddFireball(Location.Center.ToVector2(), dir, this);
            game.Room.LoadLevel.RoomProjectile.AddFireball(Location.Center.ToVector2(), Vector2.Transform(dir, Matrix.CreateRotationZ((float)(Math.PI / 6))), this); // 30 degrees up
            game.Room.LoadLevel.RoomProjectile.AddFireball(Location.Center.ToVector2(), Vector2.Transform(dir, Matrix.CreateRotationZ((float)(-Math.PI / 6))), this); // 30 degrees down
        }
        private SoundEnum ParseSound(string sound)
             => (SoundEnum)Enum.Parse(typeof(SoundEnum), sound, true);
    }
}
