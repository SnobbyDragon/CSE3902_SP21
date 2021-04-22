namespace sprint0
{
    public class LinkBorderCollisionHandler
    {
        public LinkBorderCollisionHandler() { }

        public void HandleCollision(IPlayer link, ISprite border, Direction side, Game1 game)
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
                    foreach (ISprite sprite in game.Rooms[game.levelMachine.GetAdjacentRoom(game.RoomIndex, side)].LoadLevel.RoomSprite.RoomSprites)
                        if (sprite is LockedDoor door && door.Side == DirectionMethods.OppositeDirection(side))
                            door.OpenDoor();
                }
            }
        }
    }
}
