using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
namespace sprint0
{
    public class HUDInventoryHelper : HUDItemMapping
    {
        protected readonly Dictionary<PlayerItems, Rectangle> inventoryItems;
        public Dictionary<PlayerItems, Rectangle> InventoryItems { get => inventoryItems; }
        protected readonly List<PlayerItems> aItem, secondaryItems;
        public Rectangle Location { get; set; }
        public PlayerItems Item { get; set; }
        protected readonly int maxItems = 15;
        public Texture2D Texture { get; set; }
        public bool SwitchItem { get; set; }
        public HUDInventoryHelper(Game1 game)
        {
            inventoryItems = new Dictionary<PlayerItems, Rectangle>();
            secondaryItems = new List<PlayerItems>();
            aItem = new List<PlayerItems>();
            Texture = new HUDFactory(game).Texture;
            SwitchItem = false;
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

        public bool HasAItem() => aItem.Count != 0;
        public bool HasItem(PlayerItems item) => inventoryItems.ContainsKey(item);
        public PlayerItems ChangeSword(PlayerItems currentSword)
        {
            if (aItem.Count != 0)
                return aItem[(aItem.IndexOf(currentSword) + 1) % aItem.Count];
            else return PlayerItems.None;
        }

        public bool HasItem(List<PlayerItems> itemList)
        {
            bool hasItem = false;
            foreach (PlayerItems item in itemList) hasItem = hasItem || HasItem(item);
            return hasItem;
        }

        public void AddAItem(PlayerItems newItem)
        {
            if (!aItem.Contains(newItem) && ItemMap.ContainsKey(newItem)) aItem.Add(newItem);
        }
    }
}
