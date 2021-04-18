using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

//Author: Stuti Shah
//Updated: 04/12/21 by shah.1440
namespace sprint0
{
    public class HUDInventory : HUDItemMapping
    {
        private readonly Dictionary<PlayerItems, Rectangle> inventoryItems;
        public Dictionary<PlayerItems, Rectangle> InventoryItems { get => inventoryItems; }
        private readonly List<PlayerItems> aItem, secondaryItems;
        public Rectangle Location { get; set; }
        public PlayerItems Item { get; set; }
        private readonly int maxItems = 15;
        public Texture2D Texture { get; set; }
        public bool SwitchItem { get; set; }
        public HUDInventory(Game1 game)
        {
            inventoryItems = new Dictionary<PlayerItems, Rectangle>();
            secondaryItems = new List<PlayerItems>();
            aItem = new List<PlayerItems>();
            Texture = new HUDFactory(game).Texture;
            SwitchItem = false;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            if (inventoryItems.Count != 0)
            {
                foreach (KeyValuePair<PlayerItems, Rectangle> hudElement in inventoryItems)
                    if (LocationMapping.ContainsKey(hudElement.Key)) spriteBatch.Draw(Texture, hudElement.Value, ItemMap[hudElement.Key], Color.White);
                if (Item != PlayerItems.None) spriteBatch.Draw(Texture, CurrentItem, ItemMap[Item], Color.White);
            }
        }
        public void RemoveItem(PlayerItems item)
        {
            if (HasItem(item)) inventoryItems.Remove(item);
            if (Item == item) SetItem(PlayerItems.None);
        }
        public void SetItem(PlayerItems item)
        {
            if (HasItem(item) || item == PlayerItems.None) Item = item;
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
            if (item == PlayerItems.Fairy)
                inventoryItems.Add(item, none);
        }
        public void AddAItem(PlayerItems newItem)
        {
            if (!aItem.Contains(newItem) && ItemMap.ContainsKey(newItem)) aItem.Add(newItem);
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
        }
        public bool HasItem(List<PlayerItems> itemList)
        {
            bool hasItem = false;
            foreach (PlayerItems item in itemList) hasItem = hasItem || HasItem(item);
            return hasItem;
        }
        public PlayerItems ChangeSword(PlayerItems currentSword)
        {
            if (aItem.Count != 0)
                return aItem[(aItem.IndexOf(currentSword) + 1) % aItem.Count];
            else return PlayerItems.None;
        }
        public bool HasAItem() => aItem.Count != 0;
        public bool HasItem(PlayerItems item) => inventoryItems.ContainsKey(item);
    }
}