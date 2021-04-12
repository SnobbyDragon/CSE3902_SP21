using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

//Author: Stuti Shah
//Updated: 04/03/21 by shah.1440
namespace sprint0
{
    public class HUDInventory : HUDItemMapping
    {
        private Dictionary<PlayerItems, Rectangle> inventoryItems;
        public Dictionary<PlayerItems, Rectangle> InventoryItems { get => inventoryItems; }
        private readonly List<PlayerItems> aItem;
        public Rectangle Location { get; set; }
        public PlayerItems Item { get; set; }
        public PlayerItems AItem { get; set; }
        private readonly int maxItems = 15;
        public Texture2D Texture { get; set; }

        public HUDInventory(Game1 game)
        {
            inventoryItems = new Dictionary<PlayerItems, Rectangle>();
            aItem = new List<PlayerItems>();
            Texture = new HUDFactory(game).Texture;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            if (inventoryItems.Count != 0)
            {
                foreach (KeyValuePair<PlayerItems, Rectangle> hudElement in inventoryItems)
                    if (LocationMapping.ContainsKey(hudElement.Key))
                        spriteBatch.Draw(Texture, hudElement.Value, ItemMap[hudElement.Key], Color.White);
                if (Item != PlayerItems.None)
                    spriteBatch.Draw(Texture, CurrentItem, ItemMap[Item], Color.White);
            }
        }

        public void SetItem(PlayerItems item)
        {
            if (HasItem(item) || item == PlayerItems.None) Item = item;
        }

        public void AddItem(PlayerItems newItem)
        {
            if (!HasItem(newItem) && LocationMapping.ContainsKey(newItem) && inventoryItems.Count <= maxItems)
                inventoryItems.Add(newItem, LocationMapping[newItem]);
        }

        public void AddAItem(PlayerItems newItem)
        {
            if (!aItem.Contains(newItem) && ItemMap.ContainsKey(newItem)) aItem.Add(newItem);
        }

        public void Update() { }
        public void RemoveItem(PlayerItems item)
        {
            if (HasItem(item))
                inventoryItems.Remove(item);
            if (Item == item)
                SetItem(PlayerItems.None);
        }

        public bool HasItem(List<PlayerItems> itemList)
        {
            bool hasItem = false;
            foreach (PlayerItems item in itemList)
                hasItem = hasItem || HasItem(item);
            return hasItem;
        }
        public bool HasAItem() => aItem.Count != 0;
        public bool HasItem(PlayerItems item) => inventoryItems.ContainsKey(item);
    }
}