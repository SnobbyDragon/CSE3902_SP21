﻿using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

//Author: Hannah Johnson

/*
 * Last updated: 3/13/21 by urick.9
 */

//This code is not that pretty-if find extra time refactor

namespace sprint0
{
    public class Bomb : IProjectile
    {
        public IEntity Shooter { get; }
        public Rectangle Location { get; set; }
        public Texture2D Texture { get; set; }

        private Rectangle source;
        private readonly List<Rectangle> explosionSources;
        private Rectangle currentSource;
        private readonly int xPos = 138, yPos = 184, width = 17, height = 18;

        //Age is the current number of updates
        private int age;

        //Lifespan is the number of updates before it dies. For now, it just stops rendering
        private readonly int lifespan;

        private readonly int xadd, yadd;

        private readonly int repeatedFrames;
        private readonly int totalFrames;
        private int currentFrame;
        private bool dead;
        public Bomb(Texture2D texture, Vector2 location, Direction dir, int lifespan, IEntity shooter)
        {
            dead = false;
            Shooter = shooter;
            int sourceAdjustX = 0;
            int sourceAdjustY = 0;

            /*
             * Adjust the source location based on the direction 
             */
            switch (dir)
            {
                case Direction.n:
                    sourceAdjustX -= 4;
                    break;
                case Direction.s:
                    sourceAdjustX -= 4;
                    break;
            }

            switch (dir)
            {
                //based on the direction link is facing the bomb is thrown 4 ways
                case Direction.n:
                    yadd = -4;
                    break;
                case Direction.s:
                    yadd = 4;
                    break;
                case Direction.e:
                    xadd = 4;
                    break;
                case Direction.w:
                    xadd = -4;
                    break;
            }
            Texture = texture;
            repeatedFrames = 5;
            this.lifespan = lifespan;
            source = new Rectangle(127, 184, 10, 17);

            //add frames to explosion sources
            totalFrames = 3; currentFrame = 0;
            explosionSources = new List<Rectangle>();
            for (int frame = 0; frame < totalFrames; frame++)
            {
                explosionSources.Add(new Rectangle(xPos, yPos, width, height));
                xPos += width + 1;
            }
            Vector2 loc = location + new Vector2(sourceAdjustX, sourceAdjustY);
            Location = new Rectangle((int)loc.X, (int)loc.Y, (int)(10 * Game1.Scale), (int)(height * Game1.Scale));
        }

        public void Move()
        {
            Location = new Rectangle(Location.X + xadd, Location.Y + yadd, Location.Width, Location.Height);
        }

        public bool IsAlive()
        {
            if (age < lifespan + 3 * repeatedFrames || lifespan <= 0) // if lifespan <= 0, always alive
            {
                age++;
                return true;
            }
            return false;
        }

        public void Perish()
        {
            //The check here is so that the bomb won't parish twice and be reset in its animation
            if (!dead) {
                age = lifespan;
                dead = true;
              }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (IsAlive())
            {
                spriteBatch.Draw(Texture, Location, currentSource, Color.White);
            }
        }
        public void RegisterHit(IEnemy enemy)
        {
            //no-op required
        }

        public void Update()
        {
            currentSource = source;
            //the bomb is being thrown
            if (age < lifespan)
            {
                Move();
            }
            else if (age < lifespan + 3 * repeatedFrames && age >= lifespan && lifespan > 0)
            {   //age == lifespan so the bomb reached destination
                //animates bomb to explode
                Location = new Rectangle(Location.X, Location.Y, (int)(width * Game1.Scale), (int)(height * Game1.Scale)); // explosion size diff from pre-explosion
                currentSource = explosionSources[currentFrame / repeatedFrames];
                currentFrame = (currentFrame + 1) % (totalFrames * repeatedFrames);
            }
        }

        public bool HasRecentlyHit(IEnemy enemy)
        {
            return false;
            //no-op is required
        }
    }
}

