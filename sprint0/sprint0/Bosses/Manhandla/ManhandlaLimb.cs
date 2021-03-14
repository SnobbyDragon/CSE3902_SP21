﻿using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

// Author: Angela Li
namespace sprint0
{
    public class ManhandlaLimb : IEnemy
    {
        private Game1 game;
        public Rectangle Location { get; set; }
        public Texture2D Texture { get; set; }
        private readonly int size = 16;
        private int currFrame;
        private readonly int totalFrames, repeatedFrames;
        private Dictionary<String, Vector2> dirToLocationMap;
        private Dictionary<String, List<Rectangle>> dirToSourcesMap;
        private string dir;
        private int health;
        private IEnemy center; // center of manhandla
        private readonly int fireballRate = 100; //TODO currently arbitrary
        private int fireballCounter = 0;

        public ManhandlaLimb(Texture2D texture, IEnemy center, String dir, Game1 game)
        {
            health = 25;
            Texture = texture;
            this.game = game;
            this.center = center;
            this.dir = dir;
            currFrame = 0;
            totalFrames = 2;
            repeatedFrames = 4;
            dirToLocationMap = new Dictionary<string, Vector2>
            {
                { "up", new Vector2(0, -size) },
                { "down", new Vector2(0, size) },
                { "right", new Vector2(size, 0) },
                { "left", new Vector2(-size, 0) }
            };
            dirToSourcesMap = new Dictionary<string, List<Rectangle>>
            {
                { "up", new List<Rectangle>
                    {
                        new Rectangle(105, 89, size, size),
                        new Rectangle(158, 89, size, size)
                    }
                },
                { "down", new List<Rectangle>
                    {
                        new Rectangle(105, 123, size, size),
                        new Rectangle(158, 123, size, size)
                    }
                },
                { "left", new List<Rectangle>
                    {
                        new Rectangle(88, 106, size, size),
                        new Rectangle(141, 106, size, size)
                    }
                },
                { "right", new List<Rectangle>
                    {
                        new Rectangle(122, 106, size, size),
                        new Rectangle(175, 106, size, size)
                    }
                }
            };
            Location = new Rectangle(0, 0, (int)(size * Game1.Scale), (int)(size * Game1.Scale)); //TODO clean up
            Location = new Rectangle(center.Location.X + (int)(dirToLocationMap[dir].X * Game1.Scale), center.Location.Y + (int)(dirToLocationMap[dir].Y * Game1.Scale), (int)(size * Game1.Scale), (int)(size * Game1.Scale));
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Location, dirToSourcesMap[dir][currFrame / repeatedFrames], Color.White);
        }

        public void Update()
        {
            CheckHealth();
            // animates all the time for now
            currFrame = (currFrame + 1) % (totalFrames * repeatedFrames);
            Location = new Rectangle(center.Location.X + (int)(dirToLocationMap[dir].X * Game1.Scale), center.Location.Y + (int)(dirToLocationMap[dir].Y * Game1.Scale), (int)(size * Game1.Scale), (int)(size * Game1.Scale));

            // shoot fireball
            if (CanShoot())
            {
                ShootFireball();
            }
        }

        public void ChangeDirection()
        {
            // not necessary
        }

        public void TakeDamage(int damage)
        {
            health -= damage;
        }

        public int CheckHealth()
        {
            if (health < 0) Perish();
            return health;
        }

        public void Perish()
        {
            //no-op
        }

        private bool CanShoot()
        {
            fireballCounter++;
            fireballCounter %= fireballRate;
            return fireballCounter == 0;
        }

        private void ShootFireball()
        {
            Vector2 direction = Location.Center.ToVector2();
            if (dir.Equals("up"))
            {
                direction = new Vector2(0, -1);
            }
            else if (dir.Equals("down"))
            {
                direction = new Vector2(0, 1);
            }
            else if (dir.Equals("left"))
            {
                direction = new Vector2(-1, 0);
            }
            else if (dir.Equals("right"))
            {
                direction = new Vector2(1, 0);
            }

            direction.Normalize();
            game.AddFireball(Location.Center.ToVector2(), direction, this);
        }
    }
}
