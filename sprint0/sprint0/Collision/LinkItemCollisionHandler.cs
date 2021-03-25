using System;
using Microsoft.Xna.Framework;

namespace sprint0
{
    public class LinkItemCollisionHandler
    {
        private readonly Room room;
        private readonly int linkSize = (int)(16 * Game1.Scale);
        private readonly int pickUpAnimationTime = 40;

        public LinkItemCollisionHandler(Room room)
        {
            this.room = room;
        }

        public void HandleCollision(IPlayer link, IItem item, Direction side)
        {
            if (item.PickedUpDuration < 0)
            {
                CheckItemIncrement(item, link);
                CheckItemAB(item, link);
                room.AddSoundEffect("get item");
                if (item.PickedUpDuration == -1)
                {
                    link.PickUpItem();
                    int itemX = (int)link.Pos.X + linkSize / 2 - item.Location.Width / 2;
                    int itemY = (int)link.Pos.Y - item.Location.Height;
                    item.Location = new Rectangle(itemX, itemY, item.Location.Width, item.Location.Height);
                    item.PickedUpDuration = 0;
                    room.AddSoundEffect("new item");
                }
                else
                {
                    item.PickedUpDuration = pickUpAnimationTime;
                }
            }
        }

        private void CheckItemIncrement(IItem item, IPlayer link)
        {

            if (item is Key || item is BombItem) room.AddSoundEffect("get key");
            if (item is Rupee || item is BlueRupee) room.AddSoundEffect("get rupee");
            link.IncrementItem(item.PlayerItems);
        }

        private void CheckItemAB(IItem item, IPlayer link)
        {
            if (IsSword(item.PlayerItems))
                link.SetHUDItem(PlayerItems.AItem, item.PlayerItems);
            //if (link.GetItem(PlayerItems.BItem) == PlayerItems.None && !IsSword(item.PlayerItems)) link.SetHUDItem(PlayerItems.BItem, item.PlayerItems);
            /*keep the above comment. 90% chance that this will be used once the inventory is implemented.*/
            if (!IsSword(item.PlayerItems))
                link.SetHUDItem(PlayerItems.BItem, item.PlayerItems);
        }
        private bool IsSword(PlayerItems item)
        {
            return item == PlayerItems.Sword || item == PlayerItems.WhiteSword || item == PlayerItems.MagicalSword;
        }
    }
}
