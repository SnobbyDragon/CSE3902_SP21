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
                else {
                    if (projectile is Bomb) {
                        enemy.TakeDamage(10);
                        projectile.Perish();
                    }
                    

                    if (projectile is Arrow)
                    {
                        enemy.TakeDamage(5);
                        projectile.Perish();
                    }
                   

                    if (projectile is Boomerang)
                    {
                       
                        if (!projectile.HasRecentlyHit(enemy))
                        {
                            enemy.TakeDamage(2);
                        }
                        projectile.RegisterHit(enemy);

                    }



                }
                
            }
        }
    }
}
