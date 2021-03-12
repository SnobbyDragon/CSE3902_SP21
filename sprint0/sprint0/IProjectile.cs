using System;
namespace sprint0
{
    public interface IProjectile : ISprite
    {
        public IEntity Shooter { get; } // gets whoever shot this projectile
        public bool IsAlive(); // gets whether this projectile is alive or not
        public void Perish(); // kills this projectile
    }
}
