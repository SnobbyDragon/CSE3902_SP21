﻿using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

// Author: Angela Li
//Updated: 03/26/21 by shah.1440
//Last updated 3/28 by Hannah
namespace sprint0
{
    public class GleeokHead : IEnemy
    {
        private Game1 game;
        public Rectangle Location { get; set; }
        public Texture2D Texture { get; set; }
        private Rectangle defaultSource;
        private readonly bool isAngry;
        private readonly List<Rectangle> angrySources;
        private int currFrame;
        private readonly int totalFrames, repeatedFrames;
        private Vector2 anchor;
        private readonly Random rand;
        private readonly int size = 16;
        private readonly int maxDistance = 100;
        private readonly int moveDelay;
        private int moveCounter;
        private Vector2 destination;
        private readonly int fireballRate = 100;
        private int fireballCounter = 0;
        private int health;
        public EnemyType Type { get => EnemyType.Gleeok; }
        public int Damage { get => 0; }
        private int damageTimer = 0;
        private readonly int damageTime = 10;

        public GleeokHead(Texture2D texture, Vector2 anchor, Game1 game)
        {
            health = 25;
            Texture = texture;
            this.game = game;
            currFrame = 0;
            totalFrames = 2;
            repeatedFrames = 4;
            moveDelay = 4;
            moveCounter = 0;
            defaultSource = new Rectangle(280, 11, 8, 16);
            isAngry = false;
            angrySources = SpritesheetHelper.GetFramesH(289, 11, size, size, 2);
            this.anchor = anchor;
            rand = new Random();

            Vector2 randLoc = RandomLocation();
            Location = new Rectangle((int)randLoc.X, (int)randLoc.Y, (int)(8 * Game1.Scale), (int)(size * Game1.Scale));
            destination = RandomLocation();
        }

        public void SetAnchor(Vector2 v) => anchor = v;
        public void Draw(SpriteBatch spriteBatch)
        {
            if (damageTimer % 2 == 0)
            {
                if (isAngry)
                    spriteBatch.Draw(Texture, Location, angrySources[currFrame / repeatedFrames], Color.White);
                else
                    spriteBatch.Draw(Texture, Location, defaultSource, Color.White);
            }
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
        public void Update()
        {
            if (damageTimer > 0) damageTimer--;
            if (isAngry)
                currFrame = (currFrame + 1) % (totalFrames * repeatedFrames);
            else
            {
                Vector2 dist = destination - Location.Location.ToVector2();
                if (dist.Length() < 2) destination = RandomLocation();
                else if (moveCounter == moveDelay)
                {
                    dist.Normalize();
                    Rectangle loc = Location;
                    loc.Offset(dist.ApproxDirection().ToVector2());
                    Location = loc;
                    moveCounter = 0;
                }
                moveCounter++;
            }

            if (CanShoot()) ShootFireball();
        }

        public void ChangeDirection() { }
        public int CheckHealth() => health;
        public void TakeDamage(int damage)
        {
            if (damageTimer == 0)
            {
                damageTimer = damageTime;
                health -= damage;
                game.Room.RoomSound.AddSoundEffect(SoundEnum.EnemyDamaged);
            }
        }

        public void Perish() { }
        private bool CanShoot()
        {
            fireballCounter++;
            fireballCounter %= fireballRate;
            return fireballCounter == 0;
        }

        private void ShootFireball()
        {
            game.Room.RoomSound.AddSoundEffect(SoundEnum.Gleeok);
            Vector2 dir = game.Room.Player.Pos - Location.Center.ToVector2();
            dir.Normalize();
            game.Room.LoadLevel.RoomProjectile.AddFireball(Location.Center.ToVector2(), dir, this);
        }

        private Vector2 RandomLocation()
        {
            Vector2 dir = new Vector2(rand.Next(-100, 100), rand.Next(0, 100));
            dir.Normalize();
            return anchor + rand.Next(0, maxDistance) * dir;
        }
        public EnemyEnum ParseEnemy(string enemy)
             => (EnemyEnum)Enum.Parse(typeof(EnemyEnum), enemy, true);
    }
}
