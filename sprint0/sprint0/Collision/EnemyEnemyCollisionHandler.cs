using System;
using Microsoft.Xna.Framework;

//Last updated 3/30 by shah.1440

namespace sprint0
{
    public class EnemyEnemyCollisionHandler
    {
        public EnemyEnemyCollisionHandler()
        {
        }

        public void HandleCollision(IEnemy enemy1, IEnemy enemy2, Direction side)
        {
            if (enemy1.Type == EnemyType.None || enemy2.Type == EnemyType.None || enemy1.Type != enemy2.Type)
            {

                switch (side)
                {
                    case Direction.n:
                        enemy1.Location = new Rectangle(enemy1.Location.X, enemy2.Location.Bottom, enemy1.Location.Width, enemy1.Location.Height);
                        break;
                    case Direction.s:
                        enemy1.Location = new Rectangle(enemy1.Location.X, enemy2.Location.Top - enemy1.Location.Height, enemy1.Location.Width, enemy1.Location.Height);
                        break;
                    case Direction.e:
                        enemy1.Location = new Rectangle(enemy2.Location.Left - enemy1.Location.Width, enemy1.Location.Y, enemy1.Location.Width, enemy1.Location.Height);
                        break;
                    case Direction.w:
                        enemy1.Location = new Rectangle(enemy2.Location.Right, enemy1.Location.Y, enemy1.Location.Width, enemy1.Location.Height);
                        break;
                }
                enemy1.ChangeDirection();
                enemy2.ChangeDirection();
            }
        }
    }
}
