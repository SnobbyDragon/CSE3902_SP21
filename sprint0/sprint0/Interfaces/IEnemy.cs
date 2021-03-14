using System;
namespace sprint0
{
    public interface IEnemy : ISprite
    {
        public void ChangeDirection(); // change direction / destination due to block/enemy collision
        public void TakeDamage(int damage); // take damage due to projectile / link sword

        public void Perish(); // kills this enemy
    }
}
