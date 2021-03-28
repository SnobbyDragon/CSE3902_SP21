
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
            {"Gel", new string[] { "", "arrow", "rupee"} },
            {"Goriya",new string[] { "","rupee" , "bomb"} },
            {"Keese",new string[] { "", "rupee", "meat" } },
            {"Snake",new string[] { "", "raft", "stepladder", "rupee" ,"fairy"} },
            {"Stalfos",new string[] { "", "rupee", "clock", "potion", "bomb" , "meat"} },
            {"Wallmaster",new string[] { "","compass", "potion", "rupee", "clock", "ring", "meat" } },
            {"Zol",new string[] { "" } },
            {"Aquamentus",new string[] { "heart container" } },
            {"Digdogger",new string[] { "" , "blue rupee", "rupee"} },
            {"Dodongo",new string[] { "", "raft", "flute", "book of magic", "bomb" } },
            {"Ganon",new string[] { "", "white sword", "blue rupee","magical key","flute", "blue potion" } },
            {"Gleeok",new string[] { "", "stepladder", "clock","blue rupee", "rupee" } },
            {"Gohma",new string[] { "", "power bracelet", "book of magic", "meat", "raft" } },
            {"Manhandla",new string[] { "", "blue candel", "blue potion", "blue rupee", "magical rod", "magical sword" } },
            {"Patra",new string[] { "","blue ring", "blue candel","blue map","blue potion", "blue rupee" } },
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