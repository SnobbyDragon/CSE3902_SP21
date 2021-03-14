using System;
using Microsoft.Xna.Framework;
namespace sprint0
{
    public class LinkItemCollisionHandler
    {
        private readonly int linkSize = (int)(16 * Game1.Scale);
        public LinkItemCollisionHandler()
        {
        }

        public void HandleCollision(IPlayer link, IItem item, Direction side)
        {
            if (item.PickedUpDuration < 0) // has not been picked up yet
            {
                if (item.PickedUpDuration == -1) // has special animation on pick up
                {
                    link.PickUpItem();
                    int itemX = (int)link.Pos.X + linkSize / 2 - item.Location.Width / 2;
                    int itemY = (int)link.Pos.Y - item.Location.Height;
                    item.Location = new Rectangle(itemX, itemY, item.Location.Width, item.Location.Height);
                    item.PickedUpDuration = 0;
                }
                else // no special animation on pick up
                {
                    item.PickedUpDuration = 40; // TODO magic number
                }
            }
        }
    }
}
