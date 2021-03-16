﻿using System;
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
                if (enemy is ManhandlaLimb) { }
                else
                {
                    switch (side)
                    {
                        case Direction.n:
                            enemy.Location = new Rectangle(enemy.Location.X, block.Location.Bottom, enemy.Location.Width, enemy.Location.Height);
                            break;
                        case Direction.s:
                            enemy.Location = new Rectangle(enemy.Location.X, block.Location.Top - enemy.Location.Height, enemy.Location.Width, enemy.Location.Height);
                            break;
                        case Direction.e:
                            enemy.Location = new Rectangle(block.Location.Left - enemy.Location.Width, enemy.Location.Y, enemy.Location.Width, enemy.Location.Height);
                            break;
                        case Direction.w:
                            enemy.Location = new Rectangle(block.Location.Right, enemy.Location.Y, enemy.Location.Width, enemy.Location.Height);
                            break;
                    }
                    enemy.ChangeDirection();
                }
            }
        }
    }
}
