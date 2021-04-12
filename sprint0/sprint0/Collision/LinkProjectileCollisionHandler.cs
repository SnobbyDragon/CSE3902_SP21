namespace sprint0
{
    public class LinkProjectileCollisionHandler
    {
        public LinkProjectileCollisionHandler() { }
        public void HandleCollision(IPlayer link, IProjectile projectile, Direction side)
        {
            if (projectile.Shooter is IPlayer && projectile is Boomerang boomerang && boomerang.CanBeCaught)
            {
                boomerang.Perish();
                link.ReceiveItem(1, PlayerItems.Boomerang);
            }
            else if (!(projectile.Shooter is IPlayer))
            {
                projectile.RegisterHit();
                if (ProjectileHit(link, projectile, side))
                    link.TakeDamage(side, projectile.Damage);
            }
        }
        private bool ProjectileHit(IPlayer link, IProjectile projectile, Direction side)
            => projectile.Shooter != null &&
                !((link.State is UpIdleState || link.State is DownIdleState || link.State is LeftIdleState || link.State is RightIdleState
                || link.State is UpWalkingState || link.State is DownWalkingState || link.State is LeftWalkingState || link.State is RightWalkingState)
                && link.Direction == side);
    }
}
