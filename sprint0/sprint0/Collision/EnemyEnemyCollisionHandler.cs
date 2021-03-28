using System;
using Microsoft.Xna.Framework;

//Last updated 3/28 by Hannah

namespace sprint0
{
    public class EnemyEnemyCollisionHandler
    {
        public EnemyEnemyCollisionHandler()
        {
        }

        public void HandleCollision(IEnemy enemy1, IEnemy enemy2, Direction side)
        {
            if (!(enemy1 is ManhandlaLimb && enemy2 is Manhandla) && !(enemy2 is ManhandlaLimb && enemy1 is Manhandla)
                 && !(enemy1 is Zol && enemy2 is Gel) && !(enemy2 is Zol && enemy1 is Gel) && !(enemy1 is Zol && enemy2 is Zol)
                 && !(enemy2 is PatraMinion && enemy1 is Patra) && !(enemy1 is PatraMinion && enemy2 is Patra)
                 && !(enemy1 is Gleeok && enemy2 is GleeokNeckpeice) && !(enemy2 is Gleeok && enemy1 is GleeokNeckpeice)
                 && !(enemy1 is Gleeok && enemy2 is GleeokHead) && !(enemy2 is Gleeok && enemy1 is GleeokHead)
                 && !(enemy1 is GleeokNeckpeice && enemy2 is GleeokHead) && !(enemy2 is GleeokNeckpeice && enemy1 is GleeokHead)
                 &&!(enemy2 is GleeokNeckpeice && enemy1 is GleeokNeckpeice) && !(enemy2 is GleeokHead && enemy1 is GleeokHead))
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
