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
                link.TakeDamage(side, projectile.Damage);
            else if (projectile.Shooter == link && projectile is Boomerang boomerang && boomerang.CanBeCaught)
            {
                boomerang.Perish();
                link.ReceiveItem(1, PlayerItems.Boomerang);
            }
        }
    }
}
