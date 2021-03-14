using System;
namespace sprint0
{
    public interface IProjectile : IWeapon
    {
        public IEntity Shooter { get; } // gets whoever shot this projectile

        public void RegisterHit();
    }
}
