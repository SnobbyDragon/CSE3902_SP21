using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace sprint0
{
    public class RoomItems
    {
        public List<IItem> Items { get => items; set => items = value; }
        private List<IItem> items;
        private ItemsSpriteFactory itemFactory;
        public List<IItem> ItemsToSpawn { get => itemsToSpawn; set => itemsToSpawn = value; }
        private List<IItem> itemsToSpawn;

        public RoomItems(Game1 game)
        {
            items = new List<IItem>();
            itemsToSpawn = new List<IItem>();
            itemFactory = new ItemsSpriteFactory(game);
        }

        public void AddItem(Vector2 location, string item)
            => itemsToSpawn.Add(itemFactory.MakeItem(item, location));


        public void Update()
        {
            foreach (IItem item in items)
                item.Update();
        }

        public void ItemSpawnUpdate()
        {
            if (itemsToSpawn.Count > 0)
            {
                items.AddRange(itemsToSpawn);
                itemsToSpawn.Clear();
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (IItem item in items)
                item.Draw(spriteBatch);
        }
    }
}
