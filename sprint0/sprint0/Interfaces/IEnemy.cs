using System;
namespace sprint0
{
    public enum EnemyType
    {
        None, Manhandla, Patra, Gleeok, Gel
    }
    public interface IEnemy : ISprite
    {
        public EnemyType Type { get; }
        int Damage { get; }
        public void ChangeDirection();
        public void TakeDamage(int damage);
        public void Perish();
        public EnemyEnum ParseEnemy(string enemy);
    }
}
