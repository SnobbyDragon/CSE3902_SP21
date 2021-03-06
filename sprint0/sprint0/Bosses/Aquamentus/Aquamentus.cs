﻿using System;
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
        private readonly List<Rectangle> sources;
        private readonly int moveDelay = 5, minDistance = (int)(Game1.Width * Game1.Scale * 0.2),
            maxDistance = (int)(Game1.Width * Game1.Scale * 0.8), damageTime = 10, xOffset = 1, yOffset = 11;
        private readonly AquamentusFireballBehaviour fireballBehaviour;

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
            fireballBehaviour = new AquamentusFireballBehaviour(game, this);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (damageTimer % 2 == 0) spriteBatch.Draw(Texture, Location, sources[currentFrame / repeatedFrames], Color.White);
        }

        public override void Update()
        {
            CheckHealth();
            if (!game.Room.FreezeEnemies)
            {
                if (CanChangeDirection()) ChangeDirection();
                Move();
                currentFrame = (currentFrame + 1) % (totalFrames * repeatedFrames);
                fireballBehaviour.Update();
            }
            if (damageTimer > 0) damageTimer--;
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
                moveCounter++;
        }

        private bool CanChangeDirection()
        {
            int distanceToLink = Math.Abs(Location.Left - (int)Link.position.X);
            return distanceToLink > maxDistance || distanceToLink < minDistance;
        }

        public override void ChangeDirection() => direction = direction.OppositeDirection();
        public override void TakeDamage(int damage)
        {
            if (damageTimer == 0)
            {
                health -= damage;
                game.Room.RoomSound.AddSoundEffect(SoundEnum.EnemyDamaged);
                damageTimer = damageTime;
            }
        }
    }
}
