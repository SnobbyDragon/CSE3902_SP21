using System;
using Microsoft.Xna.Framework;

namespace sprint0
{
    public class LinkItemCollisionHandler
    {
        private readonly int linkSize = (int)(16 * Game1.Scale);
        private readonly int pickUpAnimationTime = 40;

        public LinkItemCollisionHandler()
        {
        }

        public void HandleCollision(IPlayer link, IItem item, Direction side)
        {
            if (item.PickedUpDuration < 0)
            {
                if (item.PickedUpDuration == -1)
                {
                    link.PickUpItem();
                    int itemX = (int)link.Pos.X + linkSize / 2 - item.Location.Width / 2;
                    int itemY = (int)link.Pos.Y - item.Location.Height;
                    item.Location = new Rectangle(itemX, itemY, item.Location.Width, item.Location.Height);
                    item.PickedUpDuration = 0;
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
            if (item is Key key) key.Increment();
            else if (item is BombItem bomb) bomb.Increment();
            else if (item is Rupee rupee) rupee.Increment();
        }
    }
}
