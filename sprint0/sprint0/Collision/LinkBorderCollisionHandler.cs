using System;
namespace sprint0
{
    public class LinkBorderCollisionHandler
    {
        public LinkBorderCollisionHandler()
        {
        }

        public void HandleCollision(IPlayer link, ISprite border, Direction side)
        {
            if (border is ShutDoor shutDoor)
            {
                shutDoor.OpenDoor();
            }
            else if (border is LockedDoor lockedDoor)
            {
                if (link.HasKey() || link.HasItem(PlayerItems.MagicalKey))
                {
                    lockedDoor.OpenDoor();
                    link.DecrementKey();
                }
            }
        }
    }
}
