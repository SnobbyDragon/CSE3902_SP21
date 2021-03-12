using System;
namespace sprint0
{
    public class LinkProjectileCollisionHandler
    {
        public LinkProjectileCollisionHandler()
        {

        }

        public void HandleCollision(IPlayer link, IProjectile projectile, Direction side)
        {
            if (projectile.Shooter != null && !projectile.Shooter.Equals(link)) // can only hit link if he didn't throw it
                link.TakeDamage(side);
        }
    }
}
