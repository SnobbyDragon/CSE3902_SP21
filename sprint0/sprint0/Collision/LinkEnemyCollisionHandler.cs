using System;
namespace sprint0
{
    public class LinkEnemyCollisionHandler
    {
        public LinkEnemyCollisionHandler()
        {

        }

        public void HandleCollision(IPlayer link, IEnemy enemy, Direction side)
        {
            link.TakeDamage(side, enemy.Damage);
        }
    }
}
