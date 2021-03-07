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
            if (!block.IsWalkable()) // cannot walk on it TODO can some enemies walk on surfaces link can't?
            {
                switch (side)
                {
                    case Direction.n: // if collide above, then move down
                        enemy.Location = new Rectangle(enemy.Location.X, block.Location.Bottom, enemy.Location.Width, enemy.Location.Height);
                        break;
                    case Direction.s: // if collide below, then move up
                        enemy.Location = new Rectangle(enemy.Location.X, block.Location.Top - enemy.Location.Height, enemy.Location.Width, enemy.Location.Height);
                        break;
                    case Direction.e: // if collide right, then move left
                        enemy.Location = new Rectangle(block.Location.Left - enemy.Location.Width, enemy.Location.Y, enemy.Location.Width, enemy.Location.Height);
                        break;
                    case Direction.w: // if collide left, then move right
                        enemy.Location = new Rectangle(block.Location.Right, enemy.Location.Y, enemy.Location.Width, enemy.Location.Height);
                        break;
                }
                enemy.ChangeDirection();
            }
        }
    }
}
