using System;
namespace sprint0
{
    public interface IProjectile : ISprite
    {
        public IEntity Shooter { get; } // gets whoever shot this projectile
        public int Damage { get; } // gets damage value for this projectile
        public bool IsAlive(); // gets whether this projectile is alive or not
        public void Perish(); // kills this projectile

        public void RegisterHit(IEnemy enemy);
        public Boolean HasRecentlyHit(IEnemy enemy);
    }
}
