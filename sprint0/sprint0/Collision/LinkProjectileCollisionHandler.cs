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
            else if (!(projectile.Shooter is IPlayer) && !link.IsJumping())
            {
                projectile.RegisterHit();
                if (ProjectileHit(link, projectile, side))
                    link.TakeDamage(side, projectile.Damage);
            }
        }

        private bool ProjectileHit(IPlayer link, IProjectile projectile, Direction side)
            => projectile.Shooter != null && !((link.IsIdle() || link.IsWalking()) && link.Direction == side);
    }
}
