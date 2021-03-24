using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

// Author: Angela Li
namespace sprint0
{
    public class ManhandlaLimb : IEnemy
    {
        private readonly Game1 game;
        public Rectangle Location { get; set; }
        public Texture2D Texture { get; set; }
        private readonly int size = 16;
        private int currFrame;
        private readonly int totalFrames, repeatedFrames;
        private readonly Dictionary<Direction, List<Rectangle>> dirToSourcesMap;
        private readonly Direction dir;
        private int health;
        private readonly IEnemy center;
        private int fireballRate;
        private int fireballCounter = 0;
        public int Damage { get => 2; }

        public ManhandlaLimb(Texture2D texture, IEnemy center, Direction dir, Game1 game)
        {
            health = 5;
            Texture = texture;
            this.game = game;
            this.center = center;
            this.dir = dir;
            currFrame = 0;
            totalFrames = 2;
            repeatedFrames = 4;
            fireballRate = 100;
            dirToSourcesMap = new Dictionary<Direction, List<Rectangle>>
            {
                { Direction.n, new List<Rectangle>
                    {
                        new Rectangle(105, 89, size, size),
                        new Rectangle(158, 89, size, size)
                    }
                },
                { Direction.s, new List<Rectangle>
                    {
                        new Rectangle(105, 123, size, size),
                        new Rectangle(158, 123, size, size)
                    }
                },
                { Direction.w, new List<Rectangle>
                    {
                        new Rectangle(88, 106, size, size),
                        new Rectangle(141, 106, size, size)
                    }
                },
                { Direction.e, new List<Rectangle>
                    {
                        new Rectangle(122, 106, size, size),
                        new Rectangle(175, 106, size, size)
                    }
                }
            };
            Location = new Rectangle(
                center.Location.X + (int)(size * dir.ToVector2().X * Game1.Scale),
                center.Location.Y + (int)(size * dir.ToVector2().Y * Game1.Scale),
                (int)(size * Game1.Scale),
                (int)(size * Game1.Scale));
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Location, dirToSourcesMap[dir][currFrame / repeatedFrames], Color.White);
        }

        public void Update()
        {
            CheckHealth();
            currFrame = (currFrame + 1) % (totalFrames * repeatedFrames);
            Location = new Rectangle(
                center.Location.X + (int)(size * dir.ToVector2().X * Game1.Scale),
                center.Location.Y + (int)(size * dir.ToVector2().Y * Game1.Scale),
                (int)(size * Game1.Scale),
                (int)(size * Game1.Scale));
            if (CanShoot())
            {
                ShootFireball();
            }
        }

        public void ChangeDirection()
        {
        }

        public void TakeDamage(int damage)
        {
            health -= damage;

        }

        public int CheckHealth()
        {
            if (health < 0) { Perish(); }
            return health;
        }

        public void Perish()
        {
            game.Room.RemoveEnemy(this);
        }

        private bool CanShoot()
        {
            fireballCounter++;
            fireballCounter %= fireballRate;
            return fireballCounter == 0;
        }

        public void IncreaseFireballRate()
        {
            double decreaseRate =.5;
            fireballRate=(int)(fireballRate*decreaseRate);

        }

        private void ShootFireball()
        {
            game.Room.AddFireball(Location.Center.ToVector2(), dir.ToVector2(), this);
        }
    }
}
