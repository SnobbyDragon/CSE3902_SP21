using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

//Author: Hannah Johnson
namespace sprint0
{
    public class ItemSpawner
    {
        private readonly Random rand = new Random();
        private readonly Dictionary<EnemyEnum, ItemEnum[]> enemyItemMap = new Dictionary<EnemyEnum, ItemEnum[]> {
            {EnemyEnum.Gel, new ItemEnum[] { ItemEnum.None, ItemEnum.Arrow, ItemEnum.Rupee } },
            {EnemyEnum.Goriya,new ItemEnum[] { ItemEnum.None, ItemEnum.Rupee, ItemEnum.Bomb } },
            {EnemyEnum.Keese,new ItemEnum[] { ItemEnum.None, ItemEnum.Rupee, ItemEnum.Food } },
            {EnemyEnum.Snake,new ItemEnum[] {ItemEnum.None, ItemEnum.Raft, ItemEnum.Stepladder, ItemEnum.Rupee, ItemEnum.Fairy } },
            {EnemyEnum.Stalfos,new ItemEnum[] { ItemEnum.None, ItemEnum.Rupee, ItemEnum.Clock, ItemEnum.RedPotion, ItemEnum.Bomb, ItemEnum.Food } },
            {EnemyEnum.Wallmaster,new ItemEnum[] { ItemEnum.None, ItemEnum.Compass, ItemEnum.RedPotion, ItemEnum.Rupee, ItemEnum.Clock, ItemEnum.RedRing, ItemEnum.Food } },
            {EnemyEnum.Zol,new ItemEnum[] { ItemEnum.None } },
            {EnemyEnum.Aquamentus,new ItemEnum[] { ItemEnum.HeartContainer } },
            {EnemyEnum.Digdogger,new ItemEnum[] { ItemEnum.None, ItemEnum.BlueRupee, ItemEnum.Rupee } },
            {EnemyEnum.Dodongo,new ItemEnum[] { ItemEnum.None, ItemEnum.Raft, ItemEnum.Flute, ItemEnum.BookOfMagic, ItemEnum.Bomb } },
            {EnemyEnum.Ganon,new ItemEnum[] { ItemEnum.None, ItemEnum.WhiteSword, ItemEnum.BlueRupee, ItemEnum.MagicalKey, ItemEnum.Flute, ItemEnum.BluePotion } },
            {EnemyEnum.Gleeok,new ItemEnum[] { ItemEnum.None, ItemEnum.Stepladder, ItemEnum.Clock, ItemEnum.BlueRupee, ItemEnum.Rupee } },
            {EnemyEnum.Gohma,new ItemEnum[] { ItemEnum.None, ItemEnum.PowerBracelet, ItemEnum.BookOfMagic, ItemEnum.Food, ItemEnum.Raft } },
            {EnemyEnum.Manhandla,new ItemEnum[] { ItemEnum.None, ItemEnum.BlueCandle, ItemEnum.BluePotion, ItemEnum.BlueRupee, ItemEnum.MagicalRod, ItemEnum.MagicalSword } },
            {EnemyEnum.Patra,new ItemEnum[] { ItemEnum.None, ItemEnum.BlueRing, ItemEnum.BlueCandle, ItemEnum.Letter, ItemEnum.BluePotion, ItemEnum.BlueRupee } },
        };
        private readonly RoomItems roomItems;

        public ItemSpawner(RoomItems roomItems) => this.roomItems = roomItems;

        //Adds random item
        public void SpawnItem(EnemyEnum enemy, Vector2 location)
        {
            ItemEnum[] itemArray = enemyItemMap.GetValueOrDefault(enemy);
            int randPos = rand.Next(itemArray.Length);
            ItemEnum item = itemArray[randPos];
            if (item != ItemEnum.None) roomItems.AddItem(location, item);
        }

        //Adds specific item
        public void SpawnItem(Vector2 location, ItemEnum item)
        {
            if (item != ItemEnum.None) roomItems.AddItem(location, item);
        }
    }
}