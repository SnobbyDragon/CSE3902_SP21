using System;
using Microsoft.Xna.Framework;

namespace sprint0
{
    public class EnemyBlockCollisionHandler
    {
        public EnemyBlockCollisionHandler()
        {
        }

        public void HandleCollision(IEnemy enemy, IBlock block, Direction side)
        {
            if (!block.IsWalkable())
            {
                if (!(enemy is ManhandlaLimb) && !(enemy is PatraMinion)) 
                {
                    switch (side)
                    {
                        case Direction.North:
                            enemy.Location = new Rectangle(enemy.Location.X, block.Location.Bottom, enemy.Location.Width, enemy.Location.Height);
                            break;
                        case Direction.South:
                            enemy.Location = new Rectangle(enemy.Location.X, block.Location.Top - enemy.Location.Height, enemy.Location.Width, enemy.Location.Height);
                            break;
                        case Direction.East:
                            enemy.Location = new Rectangle(block.Location.Left - enemy.Location.Width, enemy.Location.Y, enemy.Location.Width, enemy.Location.Height);
                            break;
                        case Direction.West:
                            enemy.Location = new Rectangle(block.Location.Right, enemy.Location.Y, enemy.Location.Width, enemy.Location.Height);
                            break;
                    }
                    enemy.ChangeDirection();
                }
            }
        }
    }
}
