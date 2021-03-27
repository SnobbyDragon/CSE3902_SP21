
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
//Author: Hannah Johnson
namespace sprint0
{
    public class ItemSpawner 
    {

        private readonly Random rand = new Random();
        private readonly Dictionary<string, string[]> enemyItemMap = new Dictionary<string, string[]> {
            {"Gel", new string[] { "", "heart container", "rupee", "key" } },
            {"Goriya",new string[] { "" } },
            {"Keese",new string[] { "" } },
            {"Snake",new string[] { "" } },
            {"Stalfos",new string[] { "" } },
            {"Wallmaster",new string[] { "" } },
            {"Zol",new string[] { "" } },
            {"Aquamentus",new string[] { "heart container" } },
            {"Digdogger",new string[] { "" } },
            {"Dodongo",new string[] { "" } },
            {"Ganon",new string[] { "" } },
            {"Gleeok",new string[] { "" } },
            {"Ghoma",new string[] { "" } },
            {"Manhandla",new string[] { "" } },
            {"Patra",new string[] { "" } },
        };
        private RoomItems roomItems;


        public ItemSpawner(RoomItems roomItems)
        {
            this.roomItems = roomItems;
            
        }

        //Adds random item
        public void SpawnItem(String enemy,Vector2 location)
        {
            string[] itemArray= enemyItemMap.GetValueOrDefault(enemy);
            int randPos = rand.Next(itemArray.Length);
            string item = itemArray[randPos];
            if(item!="") roomItems.AddItem(location, item);
        }

        //Adds specific item
        public void SpawnItem(Vector2 location, String item)
        {
           
            if (item != "") roomItems.AddItem(location, item);
        }

    }
}