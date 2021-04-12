using System;
using Microsoft.Xna.Framework;

//Last updated 04/01/21 by shah.1440

namespace sprint0
{
    public class EnemyEnemyCollisionHandler
    {
        public EnemyEnemyCollisionHandler() { }
        public void HandleCollision(IEnemy enemy1, IEnemy enemy2, Direction side)
        {
            if ((enemy1.Type == EnemyType.None && enemy2.Type == EnemyType.None) || enemy1.Type != enemy2.Type)
            {
                switch (side)
                {
                    case Direction.North:
                        enemy1.Location = new Rectangle(enemy1.Location.X, enemy2.Location.Bottom, enemy1.Location.Width, enemy1.Location.Height);
                        break;
                    case Direction.South:
                        enemy1.Location = new Rectangle(enemy1.Location.X, enemy2.Location.Top - enemy1.Location.Height, enemy1.Location.Width, enemy1.Location.Height);
                        break;
                    case Direction.East:
                        enemy1.Location = new Rectangle(enemy2.Location.Left - enemy1.Location.Width, enemy1.Location.Y, enemy1.Location.Width, enemy1.Location.Height);
                        break;
                    case Direction.West:
                        enemy1.Location = new Rectangle(enemy2.Location.Right, enemy1.Location.Y, enemy1.Location.Width, enemy1.Location.Height);
                        break;
                }
                enemy1.ChangeDirection();
                enemy2.ChangeDirection();
            }
        }
    }
}
