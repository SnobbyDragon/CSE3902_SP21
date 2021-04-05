﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Xml;
using System.Xml.Serialization;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
//Author: Stuti Shah
//Updated: 03/14/21 by Stuti Shah
namespace sprint0
{
    public class LevelLoader
    {
        private readonly XmlReader roomReader;
        private readonly FileStream roomStream;
        private readonly XmlReader roomReaderInvisible;
        private readonly FileStream roomStreamInvisible;
        private readonly string genericPath = "../../../Content/LevelData/Room";
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

        private readonly Game1 game;
        private readonly EnemiesSpriteFactory enemyFactory;
        private readonly ItemsSpriteFactory itemFactory;
        private readonly DungeonFactory dungeonFactory;
        private readonly BossesSpriteFactory bossFactory;
        private readonly NpcsSpriteFactory npcFactory;
        private readonly EffectSpriteFactory effectFactory;

        public LevelLoader(Game1 game, int roomNo)
        {
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
            this.game = game;
            roomStreamInvisible = File.OpenRead(Path.GetFullPath(@genericPath + "Invisible" + xmlExtension));
            roomReaderInvisible = XmlReader.Create(roomStreamInvisible);

            enemyFactory = new EnemiesSpriteFactory(this.game);
            effectFactory = new EffectSpriteFactory(this.game);
            itemFactory = new ItemsSpriteFactory(this.game);
            dungeonFactory = new DungeonFactory(this.game);
            bossFactory = new BossesSpriteFactory(this.game);
            npcFactory = new NpcsSpriteFactory(this.game);
        }

        public void RoomSetup(XmlReader xmlReader, FileStream fileStream)
        {

            using (xmlReader)
            {
                while (xmlReader.Read())
                {
                    if (xmlReader.IsStartElement() && xmlReader.HasAttributes) AddElement(xmlReader);
                }
            }
            xmlReader.Close();
            fileStream.Close();
        }

        public (List<ISprite>, List<IProjectile>, List<IBlock>, List<IEnemy>, List<INpc>, List<IItem>, List<IEffect>) LoadLevel()
        {
            RoomSetup(roomReader, roomStream);
            if (roomNo != 0) RoomSetup(roomReaderInvisible, roomStreamInvisible);
            return (sprites, projectiles, blocks, enemies, npcs, items, effects);
        }

        public void AddElement(XmlReader xmlReader)
        {
            Vector2 location = new Vector2(int.Parse(xmlReader.GetAttribute("LocationX")), int.Parse(xmlReader.GetAttribute("LocationY")));
            string objectName = xmlReader.GetAttribute("ObjectName");
            switch (xmlReader.Name.ToString())
            {
                case "Enemy":
                    effects.Add(effectFactory.MakeSpawn(objectName, location));
                    break;
                case "Item":
                    items.Add(itemFactory.MakeItem(objectName, location));
                    break;
                case "Boss":
                    if (objectName.Equals("dodongo") || objectName.Equals("aquamentus"))
                    {
                        effects.Add(effectFactory.MakeSpawn(objectName, location));
                    }
                    else
                    {
                        enemies.Add(bossFactory.MakeSprite(objectName, location));
                    }

                    break;
                case "Dungeon":
                    if (objectName.Contains("bombed opening"))
                        sprites.Add(dungeonFactory.MakeSprite(objectName.Replace("bombed opening", "wall"), location, true));
                    else
                        sprites.Add(dungeonFactory.MakeSprite(objectName, location));
                    break;
                case "Block":
                    string width = xmlReader.GetAttribute("Width");
                    string height = xmlReader.GetAttribute("Height");
                    if (width != null && height != null)
                        blocks.Add(dungeonFactory.MakeBlock(objectName, location, int.Parse(width), int.Parse(height)));
                    else
                        blocks.Add(dungeonFactory.MakeBlock(objectName, location));
                    break;
                case "NPC":
                    npcs.Add(npcFactory.MakeSprite(ParseNPC(objectName), location));
                    break;
                case "Player":
                    game.Room.Player.Pos = location;
                    break;
                default:
                    throw new ArgumentException("Invalid sprite! Level loading failed.");
            }
        }
        private NPCEnum ParseNPC(String npc)
             => (NPCEnum)Enum.Parse(typeof(NPCEnum), npc, true);


    }
}
