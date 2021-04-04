using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

//Author: Stuti Shah
//Updated: 04/04/21 by shah.1440
namespace sprint0
{

    public class PopulateHUDInventory
    {
        private readonly HUDFactory hudFactory;
        private Dictionary<PlayerItems, IHUDInventory> inventory;

        public PopulateHUDInventory(Game1 game) => hudFactory = new HUDFactory(game);

        public void PopulateInventoryHUD()
        {

            inventory = new Dictionary<PlayerItems, IHUDInventory>()
            {

                {PlayerItems.Bomb, hudFactory.MakeHUDItem(HUDEnum.Bomb, new Vector2(0,0))},
                {PlayerItems.Key,hudFactory.MakeHUDItem(HUDEnum.Key, new Vector2(0,0))},
                {PlayerItems.Rupee, hudFactory.MakeHUDItem(HUDEnum.Rupee, new Vector2(0,0))},
                {PlayerItems.Heart, hudFactory.MakeHUDItem(HUDEnum.Heart, new Vector2(0,0))}
            };
        }

        public void DrawItemHUD(SpriteBatch spriteBatch)
        {
            foreach (KeyValuePair<PlayerItems, IHUDInventory> hudElement in inventory)
                hudElement.Value.Draw(spriteBatch);
        }

        public void Update()
        {
            foreach (KeyValuePair<PlayerItems, IHUDInventory> hudElement in inventory)
                hudElement.Value.Update();
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

        public int GetNum(PlayerItems item) => inventory[item].CurrentNum;
        public int TakeDamage(int damage)
        {
            inventory[PlayerItems.Heart].ChangeNum(damage);
            return inventory[PlayerItems.Heart].CurrentNum;
        }
        public void GainHealth(int num) => inventory[PlayerItems.Heart].ChangeNum(-1 * num);
    }
}
