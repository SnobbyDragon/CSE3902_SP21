﻿using System;
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
                    if (projectile is Boomerang boomerang) {
                        if (!boomerang.hit)
                        {
                            projectile.RegisterHit();
                            enemy.TakeDamage(weapon.Damage);
                        }
                    }
                    else
                    {
                        projectile.RegisterHit();
                        enemy.TakeDamage(weapon.Damage);
                    }
                    
                }
            }
            else if (weapon is Bomb bomb)
            {
                if (enemy is Dodongo dodongo) { dodongo.EatBomb(); bomb.Eaten = true; }
                else if (bomb.Exploding) enemy.TakeDamage(bomb.Damage);
            }
            else enemy.TakeDamage(weapon.Damage);
        }
    }
}
