using System;
using System.Collections.Generic;

namespace sprint0
{
    public static class BlockBlockCollisionDetector
    {
        public static bool DetectCollisions(IBlock pushedBlock, List<IBlock> blocks)
        {
            bool canPush = true;
            BlockBlockCollisionHandler collisionHandler = new BlockBlockCollisionHandler(blocks);
            foreach (IBlock block in blocks)
            {
                if (!block.Equals(pushedBlock))
                {
                    Collision side = CollisionDetector.DetectCollision(pushedBlock, block);
                    if (side != Collision.None)
                    {
                        canPush &= collisionHandler.HandleCollision(pushedBlock, block, side.ToDirection());
                    }
                }
            }
            return canPush;
        }
    }
}
