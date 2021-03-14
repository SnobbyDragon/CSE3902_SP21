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
            if (projectile.IsAlive() && projectile.Shooter != enemy)
            {
                if (enemy is Dodongo dodongo && projectile is Bomb)
                {
                    // special case; dodongo eats bombs. TODO this is bad (I think?): move this and increase cohesion?
                    dodongo.EatBomb();
                }
                else
                {
                    if (projectile is Boomerang || projectile is SwordBeam)
                    {
                        if (!projectile.HasRecentlyHit(enemy))
                        {
                            enemy.TakeDamage(projectile.Damage);
                        }
                        projectile.RegisterHit(enemy);
                    }
                    else
                    {
                        enemy.TakeDamage(projectile.Damage);
                        projectile.Perish();
                    }
                 }
                
            }
        }
    }
}
