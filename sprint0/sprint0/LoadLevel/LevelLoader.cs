using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Xml;
using System.Xml.Serialization;
using Microsoft.Xna.Framework;
//Author: Stuti Shah
//Updated: 03/14/21 by Stuti Shah
namespace sprint0
{
    public class LevelLoader
    {
        private readonly XmlReader roomReader;
        private readonly FileStream roomStream;
        private readonly string path;
        private readonly int roomNo;
        private readonly List<ISprite> sprites;
        private readonly List<IProjectile> projectiles;
        private readonly List<IBlock> blocks;
        private readonly List<IEnemy> enemies;
        private readonly List<INpc> npcs;
        private readonly List<IItem> items;

        private readonly Game1 game1;
        private readonly EnemiesSpriteFactory enemyFactory;
        private readonly ItemsSpriteFactory itemFactory;
        private readonly DungeonFactory dungeonFactory;
        private readonly BossesSpriteFactory bossFactory;
        private readonly NpcsSpriteFactory npcFactory;

        public LevelLoader(Game1 game1, int roomNo)
        {
            //path, open stream, open file to read
            path = Path.GetFullPath(@"../../../Content/LevelData/Room") + roomNo.ToString() + ".xml";
            roomStream = File.OpenRead(path);
            roomReader = XmlReader.Create(roomStream);
            this.roomNo = roomNo;
            sprites = new List<ISprite>();
            projectiles = new List<IProjectile>();
            blocks = new List<IBlock>();
            enemies = new List<IEnemy>();
            npcs = new List<INpc>();
            items = new List<IItem>();
            this.game1 = game1;

            //factories
            enemyFactory = new EnemiesSpriteFactory(this.game1);
            itemFactory = new ItemsSpriteFactory(this.game1);
            dungeonFactory = new DungeonFactory(this.game1);
            bossFactory = new BossesSpriteFactory(this.game1);
            npcFactory = new NpcsSpriteFactory(this.game1);
        }

        public (List<ISprite>, List<IProjectile>, List<IBlock>, List<IEnemy>, List<INpc>, List<IItem>) LoadLevel()
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
            if (roomNo != 0) AddRoomBorderBlocks();
            return (sprites, projectiles, blocks, enemies, npcs, items);
        }

        public void AddElement()
        {
            Vector2 location = new Vector2(int.Parse(roomReader.GetAttribute("LocationX")), int.Parse(roomReader.GetAttribute("LocationY")));
            string objectName = roomReader.GetAttribute("ObjectName");
            //add element depending on the type of element
            switch (roomReader.Name.ToString())
            {
                case "Enemy":
                    enemies.Add(enemyFactory.MakeSprite(objectName, location));
                    break;
                case "Item":
                    items.Add(itemFactory.MakeItem(objectName, location));
                    break;
                case "Boss":
                    if (roomReader.HasAttributes)
                        enemies.Add(bossFactory.MakeSprite(objectName, location));
                    break;
                case "Dungeon":
                    if (roomReader.HasAttributes)
                        sprites.Add(dungeonFactory.MakeSprite(objectName, location));
                    break;
                case "Block":
                    if (roomReader.HasAttributes)
                        blocks.Add(dungeonFactory.MakeBlock(objectName, location));
                    break;
                case "NPC": // NPCs have the same behaviour as blocks
                    if (roomReader.HasAttributes)
                        npcs.Add(npcFactory.MakeSprite(objectName, location));
                    break;
                case "Player":
                    if (roomReader.HasAttributes)
                        game1.Player.Pos = location;
                    break;
                default:
                    throw new ArgumentException("Invalid sprite! Level loading failed.");
            }
        }

        public void AddRoomBorderBlocks()
        {
            int blockSize = (int)(16 * Game1.Scale);
            int leftBorder = (int)(16 * Game1.Scale);
            int rightBorder = (int)((Game1.Width - Game1.BorderThickness) * Game1.Scale);
            int topBorder = (int)((Game1.HUDHeight + 16) * Game1.Scale);
            int bottomBorder = (int)((Game1.HUDHeight + Game1.MapHeight - Game1.BorderThickness) * Game1.Scale);
            // TODO: Figure out better formula for magic number coords
            blocks.Add(dungeonFactory.MakeBlock("invisible block", new Vector2(leftBorder, 200)));
            blocks.Add(dungeonFactory.MakeBlock("invisible block", new Vector2(leftBorder, 240)));
            blocks.Add(dungeonFactory.MakeBlock("invisible block", new Vector2(leftBorder, 280)));
            // space in case there is a door
            blocks.Add(dungeonFactory.MakeBlock("invisible block", new Vector2(leftBorder, 400)));
            blocks.Add(dungeonFactory.MakeBlock("invisible block", new Vector2(leftBorder, 440)));
            blocks.Add(dungeonFactory.MakeBlock("invisible block", new Vector2(leftBorder, 480)));

            blocks.Add(dungeonFactory.MakeBlock("invisible block", new Vector2(rightBorder, 200)));
            blocks.Add(dungeonFactory.MakeBlock("invisible block", new Vector2(rightBorder, 240)));
            blocks.Add(dungeonFactory.MakeBlock("invisible block", new Vector2(rightBorder, 280)));
            // space in case there is a door
            blocks.Add(dungeonFactory.MakeBlock("invisible block", new Vector2(rightBorder, 400)));
            blocks.Add(dungeonFactory.MakeBlock("invisible block", new Vector2(rightBorder, 440)));
            blocks.Add(dungeonFactory.MakeBlock("invisible block", new Vector2(rightBorder, 480)));

            blocks.Add(dungeonFactory.MakeBlock("invisible block", new Vector2(80, topBorder)));
            blocks.Add(dungeonFactory.MakeBlock("invisible block", new Vector2(120, topBorder)));
            blocks.Add(dungeonFactory.MakeBlock("invisible block", new Vector2(160, topBorder)));
            blocks.Add(dungeonFactory.MakeBlock("invisible block", new Vector2(200, topBorder)));
            blocks.Add(dungeonFactory.MakeBlock("invisible block", new Vector2(240, topBorder)));
            // space in case there is a door
            blocks.Add(dungeonFactory.MakeBlock("invisible block", new Vector2(360, topBorder)));
            blocks.Add(dungeonFactory.MakeBlock("invisible block", new Vector2(400, topBorder)));
            blocks.Add(dungeonFactory.MakeBlock("invisible block", new Vector2(440, topBorder)));
            blocks.Add(dungeonFactory.MakeBlock("invisible block", new Vector2(480, topBorder)));
            blocks.Add(dungeonFactory.MakeBlock("invisible block", new Vector2(520, topBorder)));

            blocks.Add(dungeonFactory.MakeBlock("invisible block", new Vector2(80, bottomBorder)));
            blocks.Add(dungeonFactory.MakeBlock("invisible block", new Vector2(120, bottomBorder)));
            blocks.Add(dungeonFactory.MakeBlock("invisible block", new Vector2(160, bottomBorder)));
            blocks.Add(dungeonFactory.MakeBlock("invisible block", new Vector2(200, bottomBorder)));
            blocks.Add(dungeonFactory.MakeBlock("invisible block", new Vector2(240, bottomBorder)));
            // space in case there is a door
            blocks.Add(dungeonFactory.MakeBlock("invisible block", new Vector2(360, bottomBorder)));
            blocks.Add(dungeonFactory.MakeBlock("invisible block", new Vector2(400, bottomBorder)));
            blocks.Add(dungeonFactory.MakeBlock("invisible block", new Vector2(440, bottomBorder)));
            blocks.Add(dungeonFactory.MakeBlock("invisible block", new Vector2(480, bottomBorder)));
            blocks.Add(dungeonFactory.MakeBlock("invisible block", new Vector2(520, bottomBorder)));

            for (int i = (int)(Game1.HUDHeight * Game1.Scale); i <= (int)((Game1.HUDHeight + Game1.MapHeight) * Game1.Scale); i += blockSize)
            {
                blocks.Add(dungeonFactory.MakeBlock("invisible block", new Vector2(leftBorder - blockSize, i)));
                blocks.Add(dungeonFactory.MakeBlock("invisible block", new Vector2(rightBorder + blockSize, i)));
            }
            for (int i = -40; i <= (int)(Game1.Width * Game1.Scale); i += blockSize)
            {
                blocks.Add(dungeonFactory.MakeBlock("invisible block", new Vector2(i, topBorder - blockSize)));
                blocks.Add(dungeonFactory.MakeBlock("invisible block", new Vector2(i, bottomBorder + blockSize)));
            }
        }
    }
}
