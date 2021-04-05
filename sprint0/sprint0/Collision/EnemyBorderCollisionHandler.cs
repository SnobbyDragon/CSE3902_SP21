﻿using System;
using Microsoft.Xna.Framework;

namespace sprint0
{
    public class EnemyBorderCollisionHandler
    {
        public EnemyBorderCollisionHandler()
        {
        }

        public void HandleCollision(IEnemy enemy, ISprite border, Direction side)
        {
            if (border is AbstractBorderFilling)
            {
                if (!(enemy is ManhandlaLimb) && !(enemy is PatraMinion))
                {
                    switch (side)
                    {
                        case Direction.n:
                            enemy.Location = new Rectangle(enemy.Location.X, border.Location.Bottom, enemy.Location.Width, enemy.Location.Height);
                            break;
                        case Direction.s:
                            enemy.Location = new Rectangle(enemy.Location.X, border.Location.Top - enemy.Location.Height, enemy.Location.Width, enemy.Location.Height);
                            break;
                        case Direction.e:
                            enemy.Location = new Rectangle(border.Location.Left - enemy.Location.Width, enemy.Location.Y, enemy.Location.Width, enemy.Location.Height);
                            break;
                        case Direction.w:
                            enemy.Location = new Rectangle(border.Location.Right, enemy.Location.Y, enemy.Location.Width, enemy.Location.Height);
                            break;
                    }
                    enemy.ChangeDirection();
                }
            }
        }
    }
}