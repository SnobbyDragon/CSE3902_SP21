using System;
namespace sprint0
{
    public class LinkEnemyCollisionHandler
    {
        public LinkEnemyCollisionHandler()
        {

        }

        public void HandleCollision(IPlayer link, ISprite enemy, Direction side)
        {
            link.TakeDamage(side);
        }
    }
}
