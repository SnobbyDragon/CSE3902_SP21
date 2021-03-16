using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

//Author: Stuti Shah
//Updated: 03/15/21 by shah.1440
namespace sprint0
{
    public class ManageHUDInventory
    {
        private Dictionary<HUDItems, IHUDInventory> Inventory;
        public ManageHUDInventory(PopulateHUDInventory hudPop)
        {
            Inventory = hudPop.GetInventory();
        }
        public void IncrementItem(HUDItems item)
        {
            Inventory[item].Increment();
        }
        public void DecrementItem(HUDItems item)
        {
            Inventory[item].Decrement();
        }
        public void ChangeNum(HUDItems item, int num)
        {
            Inventory[item].ChangeNum(num);
        }
    }
}
