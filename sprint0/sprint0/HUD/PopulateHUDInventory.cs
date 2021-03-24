using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

//Author: Stuti Shah
//Updated: 03/24/21 by shah.1440
namespace sprint0
{

    public class PopulateHUDInventory
    {
        private readonly HUDFactory hudFactory;
        private Dictionary<PlayerItems, IHUDInventory> inventory;

        public PopulateHUDInventory(Game1 game)
        {
            hudFactory = new HUDFactory(game);
        }

        public void PopulateInventoryHUD()
        {
            inventory = new Dictionary<PlayerItems, IHUDInventory>()
            {
                {PlayerItems.Bomb, hudFactory.MakeHUDItem("bomb inventory", new Vector2(0,0))},
                {PlayerItems.Key,hudFactory.MakeHUDItem("key inventory", new Vector2(0,0))},
                {PlayerItems.Rupee, hudFactory.MakeHUDItem("rupee inventory", new Vector2(0,0))},
                {PlayerItems.Heart, hudFactory.MakeHUDItem("heart", new Vector2(0,0))}
            };
        }

        public void DrawItemHUD(SpriteBatch spriteBatch)
        {
            foreach (KeyValuePair<PlayerItems, IHUDInventory> hudElement in inventory)
            {
                hudElement.Value.Draw(spriteBatch);
            }
        }

        public void Update()
        {
            foreach (KeyValuePair<PlayerItems, IHUDInventory> hudElement in inventory)
            {
                hudElement.Value.Update();
            }
        }

        public void IncrementItem(PlayerItems item)
        {
            if (inventory.ContainsKey(item)) inventory[item].Increment();
        }

        public void DecrementItem(PlayerItems item)
        {
            if (inventory.ContainsKey(item)) inventory[item].Decrement();
        }

        public void ChangeNum(PlayerItems item, int num)
        {
            if (inventory.ContainsKey(item)) inventory[item].ChangeNum(num);
        }

        public int GetHealth()
        {
            return ((HeartHUD)inventory[PlayerItems.Heart]).CurrentHealth;
        }
    }
}
