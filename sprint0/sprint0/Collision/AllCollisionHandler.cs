using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace sprint0
{
    public class AllCollisionHandler
    {
        private readonly Dictionary<Collision, Direction> sideToDir;
        private readonly CollisionDetector collisionDetector;

        public AllCollisionHandler()
        {
            sideToDir = new Dictionary<Collision, Direction>
            {
                { Collision.Left, Direction.w },
                { Collision.Right, Direction.e },
                { Collision.Top, Direction.n },
                { Collision.Bottom, Direction.s },
            };
            collisionDetector = new CollisionDetector();
        }

        public void HandleAllCollisions(IPlayer link, List<IEnemy> enemies, List<IProjectile> projectiles, List<IBlock> blocks)
        {
            HandleLinkProjectileCollisions(link, projectiles);
            HandleLinkBlockCollisions(link, blocks);
            HandleLinkEnemyCollisions(link, enemies);
            HandleEnemyBlockCollisions(enemies, blocks);
            HandleEnemyEnemyCollisions(enemies);
        }

        /*
         * Checks if link collides with any enemies; handles collisions
         */
        private void HandleLinkEnemyCollisions(IPlayer link, List<IEnemy> enemies)
        {
            LinkEnemyCollisionHandler collisionHandler = new LinkEnemyCollisionHandler();
            Rectangle linkHitbox = new Rectangle((int)link.Pos.X, (int)link.Pos.Y, 16, 16); //TODO change with size of link
            foreach (IEnemy enemy in enemies)
            {
                Collision side = collisionDetector.DetectCollision(linkHitbox, enemy);
                if (side != Collision.None)
                {
                    collisionHandler.HandleCollision(link, enemy, sideToDir[side]);
                }
            }
        }

        /*
         * Checks if link collides with any projectiles; handles collisions
         */
        private void HandleLinkProjectileCollisions(IPlayer link, List<IProjectile> projectiles)
        {
            LinkProjectileCollisionHandler collisionHandler = new LinkProjectileCollisionHandler();
            Rectangle linkHitbox = new Rectangle((int)link.Pos.X, (int)link.Pos.Y, 16, 16); //TODO change with size of link
            foreach (IProjectile projectile in projectiles)
            {
                Collision side = collisionDetector.DetectCollision(linkHitbox, projectile);
                if (side != Collision.None)
                {
                    collisionHandler.HandleCollision(link, projectile, sideToDir[side]);
                }
            }
        }

        /*
         * Checks if link collides with any blocks; handles collisions
         */
        private void HandleLinkBlockCollisions(IPlayer link, List<IBlock> blocks)
        {
            LinkBlockCollisionHandler collisionHandler = new LinkBlockCollisionHandler();
            Rectangle linkHitbox = new Rectangle((int)link.Pos.X, (int)link.Pos.Y, 16, 16); //TODO change with size of link
            foreach (IBlock block in blocks)
            {
                Collision side = collisionDetector.DetectCollision(linkHitbox, block);
                if (side != Collision.None)
                {
                    collisionHandler.HandleCollision(link, block, sideToDir[side]);
                }
            }
        }

        /*
         * Checks if enemies collide with any blocks; handles collisions
         */
        private void HandleEnemyBlockCollisions(List<IEnemy> enemies, List<IBlock> blocks)
        {
            EnemyBlockCollisionHandler collisionHandler = new EnemyBlockCollisionHandler();
            foreach (IEnemy enemy in enemies)
            {
                foreach (IBlock block in blocks)
                {
                    Collision side = collisionDetector.DetectCollision(enemy, block);
                    if (side != Collision.None)
                    {
                        collisionHandler.HandleCollision(enemy, block, sideToDir[side]);
                    }
                }
            }
        }

        /*
         * Checks if enemies collide with any other enemies; handles collisions
         */
        private void HandleEnemyEnemyCollisions(List<IEnemy> enemies)
        {
            EnemyEnemyCollisionHandler collisionHandler = new EnemyEnemyCollisionHandler();
            for (int i = 0; i < enemies.Count; i++)
            {
                for (int j = i + 1; j < enemies.Count; j++)
                {
                    Collision side = collisionDetector.DetectCollision(enemies[i], enemies[j]);
                    if (side != Collision.None)
                    {
                        collisionHandler.HandleCollision(enemies[i], enemies[j], sideToDir[side]);
                    }
                }
            }
        }
    }
}
