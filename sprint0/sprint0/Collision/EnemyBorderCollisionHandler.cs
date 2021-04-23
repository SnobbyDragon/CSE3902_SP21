using System;
using Microsoft.Xna.Framework;

namespace sprint0
{
    public class EnemyBorderCollisionHandler
    {
        public EnemyBorderCollisionHandler() { }
        public void HandleCollision(IEnemy enemy, ISprite border, Direction side)
        {
            if (border is AbstractBorderFilling)
            {
                if (!(enemy is ManhandlaLimb) && !(enemy is PatraMinion) && !(enemy is Trapparatus))
                {
                    switch (side)
                    {
                        case Direction.North:
                            enemy.Location = new Rectangle(enemy.Location.X, border.Location.Bottom, enemy.Location.Width, enemy.Location.Height);
                            break;
                        case Direction.South:
                            enemy.Location = new Rectangle(enemy.Location.X, border.Location.Top - enemy.Location.Height, enemy.Location.Width, enemy.Location.Height);
                            break;
                        case Direction.East:
                            enemy.Location = new Rectangle(border.Location.Left - enemy.Location.Width, enemy.Location.Y, enemy.Location.Width, enemy.Location.Height);
                            break;
                        case Direction.West:
                            enemy.Location = new Rectangle(border.Location.Right, enemy.Location.Y, enemy.Location.Width, enemy.Location.Height);
                            break;
                    }
                    enemy.ChangeDirection();
                }
            }
        }
    }
}
