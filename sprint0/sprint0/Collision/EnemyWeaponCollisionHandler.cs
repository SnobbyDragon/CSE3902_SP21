﻿using System;
namespace sprint0
{
    public class EnemyWeaponCollisionHandler
    {
        public EnemyWeaponCollisionHandler() { }

        public void HandleCollision(IEnemy enemy, IWeapon weapon, Direction side)
        {
            if (!(enemy is Trapparatus))
            {
                if (weapon is IProjectile projectile)
                {
                    if (projectile.IsAlive() && !(projectile.Shooter is IEnemy))
                    {
                        if ((projectile is Boomerang boomerang && !boomerang.HitAlready()) || !(projectile is Boomerang))
                        {
                            projectile.RegisterHit();
                            enemy.TakeDamage(weapon.Damage);
                        }
                    }
                    if (projectile is Boomerang boomerang2 && boomerang2.CanBeCaught && boomerang2.Shooter == enemy) boomerang2.Perish();
                }
                else if (weapon is Bomb bomb)
                {
                    if (enemy is Dodongo dodongo) { dodongo.EatBomb(); bomb.Eaten = true; }
                    else if (bomb.Exploding) enemy.TakeDamage(bomb.Damage);
                }
                else if (weapon is Sword sword && !sword.HitAlready())
                {
                    sword.RegisterHit();
                    enemy.TakeDamage(weapon.Damage);
                }
                else
                    enemy.TakeDamage(weapon.Damage);
            }
        }
    }
}
