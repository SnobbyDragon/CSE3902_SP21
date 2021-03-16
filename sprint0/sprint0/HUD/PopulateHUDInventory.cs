using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

//Author: Stuti Shah
//Updated: 03/15/21 by shah.1440
namespace sprint0
{
    public enum HUDItems
    {
        Key, Rupee, Bomb, Heart
    }

    public class PopulateHUDInventory
    {
        private readonly HUDFactory hudFactory;
        private Dictionary<HUDItems, IHUDInventory> inventory;

        public PopulateHUDInventory(Game1 game)
        {
            hudFactory = new HUDFactory(game);
        }

        public void PopulateInventoryHUD()
        {
            inventory = new Dictionary<HUDItems, IHUDInventory>()
            {
                {HUDItems.Bomb, hudFactory.MakeHUDItem("bomb inventory", new Vector2(0,0))},
                {HUDItems.Key,hudFactory.MakeHUDItem("key inventory", new Vector2(0,0))},
                {HUDItems.Rupee, hudFactory.MakeHUDItem("rupee inventory", new Vector2(0,0))},
                {HUDItems.Heart, hudFactory.MakeHUDItem("heart", new Vector2(0,0))}
            };
        }

        public void DrawItemHUD(SpriteBatch spriteBatch)
        {
            foreach (KeyValuePair<HUDItems, IHUDInventory> hudElement in inventory)
            {
                hudElement.Value.Draw(spriteBatch);
            }
        }

        public Dictionary<HUDItems, IHUDInventory> GetInventory()
        {
            return inventory;
        }

        public void AddHUDFunction(IItem item, ManageHUDInventory manage)
        {
            if (item is Key key) key.GetPopulate(manage);
            else if (item is BombItem bomb) bomb.GetPopulate(manage);
            else if (item is Rupee rupee) rupee.GetPopulate(manage);
            else if (item is BlueRupee blueRupee) blueRupee.GetPopulate(manage);
        }

    }
}
