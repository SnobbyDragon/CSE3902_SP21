using System;
namespace sprint0
{
    public class LinkBlockCollisionHandler
    {
        public LinkBlockCollisionHandler()
        {
        }

        public void HandleCollision(IPlayer link, ISprite block, Direction side)
        {
            link.Stop();
        }
    }
}
