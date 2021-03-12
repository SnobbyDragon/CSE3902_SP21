using System;
namespace sprint0
{
    public class EnemyProjectileCollisionHandler
    {
        public EnemyProjectileCollisionHandler()
        {
        }

        public void HandleCollision(IEnemy enemy, IProjectile projectile, Direction side)
        {
            if (projectile.IsAlive())
            {
                if (enemy is Dodongo dodongo && projectile is Bomb)
                {
                    // special case; dodongo eats bombs. TODO this is bad (I think?): move this and increase cohesion?
                    dodongo.EatBomb();
                    projectile.Perish();
                }
            }
        }
    }
}
