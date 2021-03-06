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
            link.TakeDamage(side);
        }
    }
}
