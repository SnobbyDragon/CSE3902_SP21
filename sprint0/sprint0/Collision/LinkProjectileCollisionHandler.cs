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
            if (projectile.Shooter != null && !(projectile.Shooter is IPlayer))
                link.TakeDamage(side, projectile.Damage);
            else if (projectile.Shooter is IPlayer && projectile is Boomerang boomerang && boomerang.CanBeCaught)
            {
                boomerang.Perish();
                link.ReceiveItem(1, PlayerItems.Boomerang);
            }
        }
    }
}
