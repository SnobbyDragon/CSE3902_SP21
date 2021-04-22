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
        private int currFrame, fireballRate, fireballCounter = 0, damageTimer = 0, health;
        private readonly int totalFrames, repeatedFrames, size = 16, damageTime = 10;
        private readonly Dictionary<Direction, List<Rectangle>> dirToSourcesMap;
        private readonly Direction dir;
        private readonly IEnemy center;
        public int Damage { get => 2; }
        public EnemyType Type { get => EnemyType.Manhandla; }
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
                { Direction.North, new List<Rectangle>
                    {
                        new Rectangle(105, 89, size, size),
                        new Rectangle(158, 89, size, size)
                    }
                },
                { Direction.South, new List<Rectangle>
                    {
                        new Rectangle(105, 123, size, size),
                        new Rectangle(158, 123, size, size)
                    }
                },
                { Direction.West, new List<Rectangle>
                    {
                        new Rectangle(88, 106, size, size),
                        new Rectangle(141, 106, size, size)
                    }
                },
                { Direction.East, new List<Rectangle>
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
            if (damageTimer % 2 == 0)
                spriteBatch.Draw(Texture, Location, dirToSourcesMap[dir][currFrame / repeatedFrames], Color.White);
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
            CheckHealth();
            if (!game.Room.FreezeEnemies)
            {
                currFrame = (currFrame + 1) % (totalFrames * repeatedFrames);
                Location = new Rectangle(
                    center.Location.X + (int)(size * dir.ToVector2().X * Game1.Scale),
                    center.Location.Y + (int)(size * dir.ToVector2().Y * Game1.Scale),
                    (int)(size * Game1.Scale),
                    (int)(size * Game1.Scale));
                if (CanShoot()) ShootFireball();
            }
        }

        public void ChangeDirection() { }
        public void TakeDamage(int damage)
        {
            if (damageTimer == 0)
            {
                damageTimer = damageTime;
                health -= damage;
            }
        }

        public int CheckHealth()
        {
            if (health < 0) { Perish(); }
            return health;
        }

        public void Perish() => game.Room.LoadLevel.RoomEnemies.RemoveEnemy(this);
        private bool CanShoot()
        {
            fireballCounter++;
            fireballCounter %= fireballRate;
            return fireballCounter == 0 && !game.Room.FreezeEnemies;
        }

        public void IncreaseFireballRate()
        {
            double decreaseRate = .5;
            fireballRate = (int)(fireballRate * decreaseRate);
        }

        private void ShootFireball()
            => game.Room.LoadLevel.RoomProjectile.AddFireball(Location.Center.ToVector2(), dir.ToVector2(), this);
        public EnemyEnum ParseEnemy(string enemy)
             => (EnemyEnum)Enum.Parse(typeof(EnemyEnum), enemy, true);
    }
}
