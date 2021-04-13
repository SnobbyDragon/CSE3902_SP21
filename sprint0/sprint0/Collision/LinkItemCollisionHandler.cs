using System;
using Microsoft.Xna.Framework;

namespace sprint0
{
    public class LinkItemCollisionHandler
    {
        private readonly Room room;
        private readonly int linkSize = (int)(16 * Game1.Scale);
        private readonly int pickUpAnimationTime = 40;

        public LinkItemCollisionHandler(Room room) => this.room = room;

        public void HandleCollision(IPlayer link, IItem item, Direction side)
        {
            if (item.PickedUpDuration < 0)
            {
                CheckItemIncrement(item, link);
                CheckItemAB(item, link);
                room.RoomSound.AddSoundEffect(SoundEnum.GetItem);
                if (item.PickedUpDuration == -1)
                {
                    link.PickUpItem();
                    if (item is GanonTriforceAshes)
                        room.LoadLevel.RoomEffect.AddEffect(item.Location.Location.ToVector2(), EffectEnum.GanonAshes);
                    int itemX = (int)link.Pos.X + linkSize / 2 - item.Location.Width / 2;
                    int itemY = (int)link.Pos.Y - item.Location.Height;
                    item.Location = new Rectangle(itemX, itemY, item.Location.Width, item.Location.Height);
                    item.PickedUpDuration = 0;
                    room.RoomSound.AddSoundEffect(SoundEnum.NewItem);
                }
                else
                    item.PickedUpDuration = pickUpAnimationTime;
            }
        }

        private void CheckItemIncrement(IItem item, IPlayer link)
        {
            if (item is Key || item is BombItem) room.RoomSound.AddSoundEffect(SoundEnum.GetKey);
            if (item is Rupee || item is BlueRupee) room.RoomSound.AddSoundEffect(SoundEnum.GetRupee);
            link.IncrementItem(item.PlayerItems);
        }

        private void CheckItemAB(IItem item, IPlayer link)
        {
            link.AddToInventory(item.PlayerItems);
            if (IsSword(item.PlayerItems))
                link.SetHUDItem(PlayerItems.AItem, item.PlayerItems);
            else
                link.SetHUDItem(PlayerItems.BItem, item.PlayerItems);
        }

        private bool IsSword(PlayerItems item) => item == PlayerItems.Sword || item == PlayerItems.WhiteSword || item == PlayerItems.MagicalSword;
    }
}
