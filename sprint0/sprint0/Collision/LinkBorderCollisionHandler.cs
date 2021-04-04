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
                //TODO check if link has a key or the master key, if so, open door (decrement key if he doesn't have master key)
                lockedDoor.OpenDoor();
            }
        }
    }
}
