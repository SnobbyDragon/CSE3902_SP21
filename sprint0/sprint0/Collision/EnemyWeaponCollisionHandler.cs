using System;
namespace sprint0
{
    public class EnemyWeaponCollisionHandler
    {
        public EnemyWeaponCollisionHandler()
        {
        }

        public void HandleCollision(IEnemy enemy, IWeapon weapon, Direction side)
        {
            if (weapon is IProjectile projectile)
            {
                if (projectile.IsAlive() && !(projectile.Shooter is IEnemy))
                {
                    projectile.RegisterHit();
                    enemy.TakeDamage(weapon.Damage);
                }
            }
            else if (weapon is Bomb bomb)
            {
                // special case; dodongo eats bombs. TODO this is bad (I think?): move this and increase cohesion?
                if (enemy is Dodongo dodongo) { dodongo.EatBomb(); bomb.Eaten = true; }
                else if (bomb.Exploding) enemy.TakeDamage(bomb.Damage);
            }
            else enemy.TakeDamage(weapon.Damage);
        }
    }
}
