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
                bool openedByBlock = false;
                shutDoor.OpenDoor(openedByBlock);
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
