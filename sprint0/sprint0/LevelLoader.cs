﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using Microsoft.Xna.Framework;
//Author: Stuti Shah
//Updated: 04/22/21 by li.10011
namespace sprint0
{
    public class LevelLoader
    {
        private readonly XmlReader roomReader;
        private readonly FileStream roomStream;
        private readonly XmlReader roomReaderInvisible;
        private readonly FileStream roomStreamInvisible;
        private readonly string genericPath = "";
        private readonly string genericPathStart = "../../../Content/LevelData/";
        private readonly string genericPathFinish = "/Room";
        private readonly string xmlExtension = ".xml";
        private readonly string path;
        private readonly int roomNo;
        private readonly List<ISprite> sprites;
        private readonly List<IProjectile> projectiles;
        private readonly List<IBlock> blocks;
        private readonly List<IEnemy> enemies;
        private readonly List<INpc> npcs;
        private readonly List<IItem> items;
        private readonly List<IEffect> effects;
        private readonly Dictionary<int, Vector2> locations;

        private readonly Game1 game;
        private readonly ItemsSpriteFactory itemFactory;
        private readonly DungeonFactory dungeonFactory;
        private readonly BossesSpriteFactory bossFactory;
        private readonly NpcsSpriteFactory npcFactory;
        private readonly EffectSpriteFactory effectFactory;

        public LevelLoader(Game1 game, int roomNo, bool loadSaved = false)
        {
            genericPath = (loadSaved ? LevelSaver.SavedGamePath : genericPathStart) + game.LevelString + genericPathFinish;
            path = Path.GetFullPath(@genericPath) + roomNo.ToString() + xmlExtension;
            roomStream = File.OpenRead(path);
            roomReader = XmlReader.Create(roomStream);
            this.roomNo = roomNo;
            sprites = new List<ISprite>();
            projectiles = new List<IProjectile>();
            blocks = new List<IBlock>();
            enemies = new List<IEnemy>();
            npcs = new List<INpc>();
            items = new List<IItem>();
            effects = new List<IEffect>();
            locations = new Dictionary<int, Vector2>();
            this.game = game;
            roomStreamInvisible = File.OpenRead(Path.GetFullPath(@genericPath + "Invisible" + xmlExtension));
            roomReaderInvisible = XmlReader.Create(roomStreamInvisible);

            effectFactory = new EffectSpriteFactory(this.game);
            itemFactory = new ItemsSpriteFactory(this.game);
            dungeonFactory = new DungeonFactory(this.game, roomNo);
            bossFactory = new BossesSpriteFactory(this.game);
            npcFactory = new NpcsSpriteFactory(this.game);
        }

        public void RoomSetup(XmlReader xmlReader, FileStream fileStream)
        {
            using (xmlReader)
            {
                while (xmlReader.Read())
                {
                    if (xmlReader.IsStartElement() && xmlReader.HasAttributes)
                        AddElement(xmlReader);
                }
            }
            xmlReader.Close();
            fileStream.Close();
        }

        public (List<ISprite>, List<IProjectile>, List<IBlock>, List<IEnemy>, List<INpc>, List<IItem>, List<IEffect>, Dictionary<int, Vector2>) LoadLevel()
        {
            RoomSetup(roomReader, roomStream);
            if (roomNo != 0) RoomSetup(roomReaderInvisible, roomStreamInvisible);
            return (sprites, projectiles, blocks, enemies, npcs, items, effects, locations);
        }

        public void AddElement(XmlReader xmlReader)
        {
            Vector2 location = new Vector2(int.Parse(xmlReader.GetAttribute("LocationX")), int.Parse(xmlReader.GetAttribute("LocationY")));
            string objectName = xmlReader.GetAttribute("ObjectName");
            switch (xmlReader.Name.ToString())
            {
                case "Enemy":
                    effects.Add(effectFactory.MakeSpawn(ParseEnemy(objectName), location));
                    break;
                case "Item":
                    items.Add(itemFactory.MakeItem(ParseItem(objectName), location));
                    break;
                case "Boss":
                    if (objectName.Equals("Dodongo") || objectName.Equals("Aquamentus"))
                        effects.Add(effectFactory.MakeSpawn(ParseEnemy(objectName), location));
                    else
                        enemies.Add(bossFactory.MakeSprite(ParseEnemy(objectName), location));
                    break;
                case "Dungeon":
                    if (objectName.Contains("BombedOpening"))
                        sprites.Add(dungeonFactory.MakeSprite(ParseDungeon(objectName.Replace("BombedOpening", "Wall")), location, true));
                    else
                        sprites.Add(dungeonFactory.MakeSprite(ParseDungeon(objectName), location));
                    break;
                case "Block":
                    string width = xmlReader.GetAttribute("Width");
                    string height = xmlReader.GetAttribute("Height");
                    string sound = xmlReader.GetAttribute("Sound");
                    string direction= xmlReader.GetAttribute("Direction");
                    if (direction != null)
                        blocks.Add(dungeonFactory.MakeBlock(ParseBlock(objectName), location, ParseDirection(direction)));
                    else if (sound!=null)
                        blocks.Add(dungeonFactory.MakeBlock(ParseBlock(objectName), location, int.Parse(sound)));
                    else if (width != null && height != null)
                        blocks.Add(dungeonFactory.MakeBlock(ParseBlock(objectName), location, int.Parse(width), int.Parse(height)));
                    else
                        blocks.Add(dungeonFactory.MakeBlock(ParseBlock(objectName), location));
                    break;
                case "NPC":
                    npcs.Add(npcFactory.MakeSprite(ParseNPC(objectName), location));
                    break;
                case "Player":
                    game.Room.Player.Pos = location;
                    locations.Add(roomNo, location);
                    break;
                default:
                    throw new ArgumentException("Invalid sprite! Level loading failed.");
            }
        }
        private NPCEnum ParseNPC(string npc)
             => (NPCEnum)Enum.Parse(typeof(NPCEnum), npc, true);
        private EnemyEnum ParseEnemy(string enemy)
             => (EnemyEnum)Enum.Parse(typeof(EnemyEnum), enemy, true);
        private ItemEnum ParseItem(string item)
             => (ItemEnum)Enum.Parse(typeof(ItemEnum), item, true);
        private DungeonEnum ParseDungeon(string dungeon)
             => (DungeonEnum)Enum.Parse(typeof(DungeonEnum), dungeon, true);
        private BlockEnum ParseBlock(string block)
             => (BlockEnum)Enum.Parse(typeof(BlockEnum), block, true);
        private Direction ParseDirection(string dir)
             => (Direction)Enum.Parse(typeof(Direction), dir, true);
    }
}
