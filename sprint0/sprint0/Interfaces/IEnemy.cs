using System;
namespace sprint0
{
    public interface IEnemy : ISprite
    {
        public void ChangeDirection();
        public void TakeDamage(int damage);

        public void Perish();
    }
}
