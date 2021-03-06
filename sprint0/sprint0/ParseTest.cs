using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Xml;
using System.Xml.Serialization;
using Microsoft.Xna.Framework;
//<? xml version = "1.0" encoding = "utf-8" ?>
namespace sprint0
{
    public class ParseTest
    {
        private XmlReader roomReader;
        private FileStream roomStream;
        private String path;
        private List<ISprite> sprites;
        Game1 game1;
        EnemiesSpriteFactory enemyFactory;
        ItemsWeaponsSpriteFactory itemFactory;
        DungeonFactory dungeonFactory;
        BossesSpriteFactory bossFactory;

        public ParseTest(Game1 game1, String roomNo)
        {
            //path = "LevelData/" + roomNo; // "LevelData/Room3";
            path = "Content/LevelData/Room";
            path += roomNo + ".xml";
            //path += ".xml";
            roomStream = File.OpenRead(path);

            roomReader = XmlReader.Create(roomStream);
            sprites = new List<ISprite>();
            this.game1 = game1;
            enemyFactory = new EnemiesSpriteFactory(this.game1);
            itemFactory = new ItemsWeaponsSpriteFactory(this.game1);
            dungeonFactory = new DungeonFactory(this.game1);
            bossFactory = new BossesSpriteFactory(this.game1);
        }

        public List<ISprite> LoadLevel()
        {
            using (roomReader)
            {
                while (roomReader.Read())
                {
                    if (roomReader.IsStartElement() && roomReader.HasAttributes)
                    {
                        AddElement();
                    }
                }
            }
            //Console.ReadKey();
            return sprites;
        }

        public Direction WeaponDirection(String dir)
        {
            return dir switch
            {
                "North" => Direction.n,
                "East" => Direction.e,
                "West" => Direction.w,
                "South" => Direction.s,
                _ => Direction.n,
            };
        }

        public void AddElement()
        {
            switch (roomReader.Name.ToString())
            {
                case "EnemyNPC":
                    sprites.Add(enemyFactory.MakeSprite(roomReader.GetAttribute("ObjectName"), new Vector2(int.Parse(roomReader.GetAttribute("LocationX")), int.Parse(roomReader.GetAttribute("LocationY")))));
                    break;
                case "ItemWeapon":
                    Direction dir = WeaponDirection(roomReader.GetAttribute("Direction"));
                    int lifespan = Int32.Parse(roomReader.GetAttribute("Lifespan"));
                    sprites.Add(itemFactory.MakeSprite(roomReader.GetAttribute("ObjectName"), new Vector2(int.Parse(roomReader.GetAttribute("LocationX")), int.Parse(roomReader.GetAttribute("LocationY"))), dir, lifespan));
                    break;
                case "Boss":
                    if (roomReader.HasAttributes)
                    {
                        sprites.Add(bossFactory.MakeSprite(roomReader.GetAttribute("ObjectName"), new Vector2(int.Parse(roomReader.GetAttribute("LocationX")), int.Parse(roomReader.GetAttribute("LocationY")))));
                    }
                    break;
                case "Dungeon":
                    if (roomReader.HasAttributes)
                    {
                        sprites.Add(dungeonFactory.MakeSprite(roomReader.GetAttribute("ObjectName"), new Vector2(int.Parse(roomReader.GetAttribute("LocationX")), int.Parse(roomReader.GetAttribute("LocationY")))));
                    }
                    break;
                default:
                    throw new ArgumentException("Invalid sprite! Level loading failed.");
            }
        }
    }
}
