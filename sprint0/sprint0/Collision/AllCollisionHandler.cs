using System;
namespace sprint0
{
    public class AllCollisionHandler
    {
        /*
         * Encapsulates all collision events.
         */

        private LinkBlockCollisionHandler linkBlockCollisionHandler;
        private LinkEnemyCollisionHandler linkEnemyCollisionHandler;
        private LinkProjectileCollisionHandler linkProjectileCollisionHandler;
        private EnemyBlockCollisionHandler enemyBlockCollisionHandler;
        private EnemyProjectileCollisionHandler enemyProjectileCollisionHandler;

        public AllCollisionHandler()
        {
        }
    }
}
