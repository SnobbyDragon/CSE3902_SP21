using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Xml;
using System.Xml.Serialization;
using Microsoft.Xna.Framework;
//Author: Stuti Shah
//Updated: 03/06/21
namespace sprint0
{
    public class LevelLoader
    {
        private XmlReader roomReader;
        private FileStream roomStream;
        private string path;

        private List<ISprite> sprites;
        private List<IProjectile> projectiles;
        private List<IBlock> blocks;
        private List<IEnemy> enemies;

        private Game1 game1;
        private EnemiesSpriteFactory enemyFactory;
        private ItemsWeaponsSpriteFactory itemFactory;
        private DungeonFactory dungeonFactory;
        private BossesSpriteFactory bossFactory;
        private NpcsSpriteFactory npcFactory;

        public LevelLoader(Game1 game1, int roomNo)
        {
            //path, open stream, open file to read
            path = Path.GetFullPath(@"../../../Content/LevelData/Room");
            path += roomNo.ToString();
            path += ".xml";
            roomStream = File.OpenRead(path);
            roomReader = XmlReader.Create(roomStream);

            sprites = new List<ISprite>();
            projectiles = new List<IProjectile>();
            blocks = new List<IBlock>();
            enemies = new List<IEnemy>();
            this.game1 = game1;

            //factories
            enemyFactory = new EnemiesSpriteFactory(this.game1);
            itemFactory = new ItemsWeaponsSpriteFactory(this.game1);
            dungeonFactory = new DungeonFactory(this.game1);
            bossFactory = new BossesSpriteFactory(this.game1);
            npcFactory = new NpcsSpriteFactory(this.game1);
        }

        public (List<ISprite>, List<IProjectile>, List<IBlock>, List<IEnemy>) LoadLevel()
        {
            using (roomReader)
            {
                while (roomReader.Read())
                {
                    if (roomReader.IsStartElement() && roomReader.HasAttributes)
                    {
                        AddElement(); //add elements
                    }
                }
            }
            return (sprites, projectiles, blocks, enemies);
        }

        public Direction WeaponDirection(string dir)
        {
            //converts direction string from xml into Direction enum
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
            //add element depending on the type of element
            switch (roomReader.Name.ToString())
            {
                case "Enemy":
                    enemies.Add(enemyFactory.MakeSprite(roomReader.GetAttribute("ObjectName"), new Vector2(int.Parse(roomReader.GetAttribute("LocationX")), int.Parse(roomReader.GetAttribute("LocationY")))));
                    break;
                case "ItemWeapon":
                    Direction dir = WeaponDirection(roomReader.GetAttribute("Direction"));
                    int lifespan = int.Parse(roomReader.GetAttribute("Lifespan"));
                    sprites.Add(itemFactory.MakeSprite(roomReader.GetAttribute("ObjectName"), new Vector2(int.Parse(roomReader.GetAttribute("LocationX")), int.Parse(roomReader.GetAttribute("LocationY"))), dir, lifespan));
                    break;
                case "Projectile":
                    Direction dir1 = WeaponDirection(roomReader.GetAttribute("Direction"));
                    int lifespan1 = int.Parse(roomReader.GetAttribute("Lifespan"));
                    projectiles.Add(itemFactory.MakeProjectile(roomReader.GetAttribute("ObjectName"), new Vector2(int.Parse(roomReader.GetAttribute("LocationX")), int.Parse(roomReader.GetAttribute("LocationY"))), dir1, lifespan1, null)); //TODO randomly null for now
                    break;
                case "Boss":
                    if (roomReader.HasAttributes)
                        enemies.Add(bossFactory.MakeSprite(roomReader.GetAttribute("ObjectName"), new Vector2(int.Parse(roomReader.GetAttribute("LocationX")), int.Parse(roomReader.GetAttribute("LocationY")))));
                    break;
                case "Dungeon":
                    if (roomReader.HasAttributes)
                        sprites.Add(dungeonFactory.MakeSprite(roomReader.GetAttribute("ObjectName"), new Vector2(int.Parse(roomReader.GetAttribute("LocationX")), int.Parse(roomReader.GetAttribute("LocationY")))));
                    break;
                case "Block":
                    if (roomReader.HasAttributes)
                        blocks.Add(dungeonFactory.MakeBlock(roomReader.GetAttribute("ObjectName"), new Vector2(int.Parse(roomReader.GetAttribute("LocationX")), int.Parse(roomReader.GetAttribute("LocationY")))));
                    break;
                case "NPC": // NPCs have the same behaviour as blocks
                    if (roomReader.HasAttributes)
                        blocks.Add(npcFactory.MakeSprite(roomReader.GetAttribute("ObjectName"), new Vector2(int.Parse(roomReader.GetAttribute("LocationX")), int.Parse(roomReader.GetAttribute("LocationY")))));
                    break;
                case "Player":
                    if (roomReader.HasAttributes)
                        game1.Player.Pos = new Vector2(int.Parse(roomReader.GetAttribute("LocationX")), int.Parse(roomReader.GetAttribute("LocationY")));
                    break;
                default:
                    throw new ArgumentException("Invalid sprite! Level loading failed.");
            }
        }
    }
}
