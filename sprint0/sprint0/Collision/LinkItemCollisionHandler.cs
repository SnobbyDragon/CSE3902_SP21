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
                CheckItem(item);
            }
        }

        private void CheckItem(IItem item)
        {
            if (item is Key key)
            {
                key.Increment();
                room.AddSoundEffect("get key");
            }
            else if (item is BombItem bomb)
            {
                bomb.Increment();
                room.AddSoundEffect("get key");
            }
            else if (item is Rupee rupee)
            {
                rupee.Increment();
                room.AddSoundEffect("get rupee");
            }
            else if (item is BlueRupee blueRupee)
            {
                blueRupee.ChangeNum(BlueRupee.Value);
                room.AddSoundEffect("get rupee");
            }
        }
    }
}
