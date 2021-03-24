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
                CheckItem(item, link);
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

        private void CheckItem(IItem item, IPlayer link)
        {
            if (item is Key)
            {
                ((Link)link).InventoryItem = PlayerItems.Key;
                room.AddSoundEffect("get key");
            }
            else if (item is BombItem)
            {
                ((Link)link).InventoryItem = PlayerItems.Bomb;
                room.AddSoundEffect("get key");
            }
            else if (item is Rupee)
            {
                ((Link)link).InventoryItem = PlayerItems.Rupee;
                room.AddSoundEffect("get rupee");
            }
            else if (item is BlueRupee)
            {
                ((Link)link).InventoryItem = PlayerItems.BlueRupee;
                room.AddSoundEffect("get rupee");
            }
            else ((Link)link).InventoryItem = PlayerItems.None;
            ((Link)link).IncrementItem();
        }
    }
}
