using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

//Author: Stuti Shah
//Updated: 04/19/21 by shah.1440
namespace sprint0
{
    public class HUDInventory : HUDInventoryHelper
    {
        public HUDInventory(Game1 game) : base(game) { }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (inventoryItems.Count != 0)
            {
                foreach (KeyValuePair<PlayerItems, Rectangle> hudElement in inventoryItems)
                    if (LocationMapping.ContainsKey(hudElement.Key)) spriteBatch.Draw(Texture, hudElement.Value, ItemMap[hudElement.Key], Color.White);
                if (Item != PlayerItems.None && !HasBowArrowCombo()) spriteBatch.Draw(Texture, CurrentItem, ItemMap[Item], Color.White);
                else DrawBowArrow(spriteBatch);
            }
        }

        private void DrawBowArrow(SpriteBatch spriteBatch)
        {
            if (Item != PlayerItems.None)
            {
                int shift = 8;
                if (HasItem(PlayerItems.Arrow))
                    spriteBatch.Draw(Texture, new Rectangle(CurrentItem.X - shift, CurrentItem.Y, CurrentItem.Width, CurrentItem.Height), ItemMap[PlayerItems.Arrow], Color.White);
                else
                    spriteBatch.Draw(Texture, new Rectangle(CurrentItem.X - shift, CurrentItem.Y, CurrentItem.Width, CurrentItem.Height), ItemMap[PlayerItems.SilverArrow], Color.White);
                spriteBatch.Draw(Texture, new Rectangle(CurrentItem.X + shift, CurrentItem.Y, CurrentItem.Width, CurrentItem.Height), ItemMap[PlayerItems.Bow], Color.White);
            }
        }

        public void AddItem(PlayerItems newItem)
        {
            if (!HasItem(newItem) && LocationMapping.ContainsKey(newItem) && inventoryItems.Count <= maxItems)
            {
                if (!itemToSecondaryItem.ContainsKey(newItem)) inventoryItems.Add(newItem, LocationMapping[newItem]);
                else if (!secondaryItems.Contains(itemToSecondaryItem[newItem]))
                {
                    secondaryItems.Add(itemToSecondaryItem[newItem]);
                    inventoryItems.Add(newItem, LocationMapping[newItem]);
                }
                else HandleSecondaryItem(newItem);
            }
            else HandleFairy(newItem);
        }

        private void HandleFairy(PlayerItems item)
        {
            if (item == PlayerItems.Fairy && !HasItem(item))
                inventoryItems.Add(item, none);
        }

        private void BItemSwitch(PlayerItems item, PlayerItems switchTo, PlayerItems toRemove)
        {
            if (item == switchTo)
            {
                RemoveItem(toRemove);
                inventoryItems.Add(item, LocationMapping[item]);
                if (Item == PlayerItems.None)
                {
                    Item = item;
                    SwitchItem = true;
                }
            }
        }
        private void HandleSecondaryItem(PlayerItems item)
        {
            BItemSwitch(item, PlayerItems.MagicalBoomerang, PlayerItems.Boomerang);
            BItemSwitch(item, PlayerItems.BlueCandle, PlayerItems.RedCandle);
            BItemSwitch(item, PlayerItems.BluePotion, PlayerItems.RedPotion);
            BItemSwitch(item, PlayerItems.BlueRing, PlayerItems.RedRing);
            BItemSwitch(item, PlayerItems.SilverArrow, PlayerItems.Arrow);
        }

        private bool HasBowArrowCombo()
            => (Item == PlayerItems.Arrow || Item == PlayerItems.SilverArrow || Item == PlayerItems.Bow)
            && secondaryItems.Contains(PlayerItems.ArrowType) && inventoryItems.ContainsKey(PlayerItems.Bow);
    }
}