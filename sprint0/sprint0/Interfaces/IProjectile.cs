using System;
namespace sprint0
{
    public interface IProjectile : IWeapon
    {
        public IEntity Shooter { get; }
        public void RegisterHit();
    }
}
