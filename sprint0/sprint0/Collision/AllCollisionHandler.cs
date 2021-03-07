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

        /*
         * Checks if link collides with any enemies; handles collisions
         */
        public void HandleLinkEnemyCollisions(IPlayer link, List<IEnemy> enemies)
        {
            Rectangle linkHitbox = new Rectangle((int)IPlayer.Position.X, (int)IPlayer.Position.Y, 16, 16); //TODO change with size of link
            foreach (IEnemy enemy in enemies)
            {
                Collision side = collisionDetector.DetectCollision(linkHitbox, enemy);
                if (side != Collision.None)
                {
                    new LinkEnemyCollisionHandler().HandleCollision(link, enemy, sideToDir[side]);
                }
            }
        }

        /*
         * Checks if link collides with any projectiles; handles collisions
         */
        public void HandleLinkProjectileCollisions(IPlayer link, List<IProjectile> projectiles)
        {
            Rectangle linkHitbox = new Rectangle((int)link.Pos.X, (int)link.Pos.Y, 16, 16); //TODO change with size of link
            foreach (IProjectile projectile in projectiles)
            {
                Collision side = collisionDetector.DetectCollision(linkHitbox, projectile);
                if (side != Collision.None)
                {
                    new LinkProjectileCollisionHandler().HandleCollision(link, projectile, sideToDir[side]);
                }
            }
        }
    }
}
