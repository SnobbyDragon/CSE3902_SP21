using System;
using Microsoft.Xna.Framework;

namespace sprint0
{
    public class EnemyEnemyCollisionHandler
    {
        public EnemyEnemyCollisionHandler()
        {
        }

        public void HandleCollision(IEnemy enemy1, IEnemy enemy2, Direction side)
        {
           if ((enemy1 is ManhandlaLimb && enemy2 is Manhandla)|| (enemy2 is ManhandlaLimb  && enemy1 is Manhandla)
               ) { }
            else
            {

                switch (side)
                {
                    case Direction.n: // if collide above, then move down
                        enemy1.Location = new Rectangle(enemy1.Location.X, enemy2.Location.Bottom, enemy1.Location.Width, enemy1.Location.Height);
                        break;
                    case Direction.s: // if collide below, then move up
                        enemy1.Location = new Rectangle(enemy1.Location.X, enemy2.Location.Top - enemy1.Location.Height, enemy1.Location.Width, enemy1.Location.Height);
                        break;
                    case Direction.e: // if collide right, then move left
                        enemy1.Location = new Rectangle(enemy2.Location.Left - enemy1.Location.Width, enemy1.Location.Y, enemy1.Location.Width, enemy1.Location.Height);
                        break;
                    case Direction.w: // if collide left, then move right
                        enemy1.Location = new Rectangle(enemy2.Location.Right, enemy1.Location.Y, enemy1.Location.Width, enemy1.Location.Height);
                        break;
                }
                enemy1.ChangeDirection();
                enemy2.ChangeDirection();
            }
        }
    }
}
