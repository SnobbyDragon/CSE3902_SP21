﻿using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;

namespace sprint0
{
    public class LoadLevel
    {
        public RoomProjectile RoomProjectile { get => roomProjectile; }
        public RoomWeapon RoomWeapon { get => roomWeapon; }
        public RoomBlocks RoomBlocks { get => roomBlocks; }
        public RoomItems RoomItems { get => roomItems; }
        public RoomNPCs RoomNPCs { get => roomNPCs; }
        public RoomEnemies RoomEnemies { get => roomEnemies; }
        public RoomSprite RoomSprite { get => roomSprite; }
        public RoomSound RoomSound { get => roomSound; }
        private RoomProjectile roomProjectile;
        private RoomWeapon roomWeapon;
        private RoomBlocks roomBlocks;
        private RoomItems roomItems;
        private RoomNPCs roomNPCs;
        private RoomEnemies roomEnemies;
        private RoomSprite roomSprite;
        private RoomSound roomSound;
        public LoadLevel(Game1 game)
        {
            roomProjectile = new RoomProjectile(game);
            roomWeapon = new RoomWeapon(game);
            roomBlocks = new RoomBlocks();
            roomItems = new RoomItems();
            roomNPCs = new RoomNPCs();
            roomEnemies = new RoomEnemies(game);
            roomSprite = new RoomSprite(game);
            roomSound = new RoomSound(game);
        }
        public void PopulateLists((List<ISprite>, List<IProjectile>, List<IBlock>, List<IEnemy>, List<INpc>, List<IItem>) roomElements)
        {
            roomSprite.RoomSprites = roomElements.Item1;
            roomProjectile.Projectiles = roomElements.Item2;
            roomBlocks.Blocks = roomElements.Item3;
            roomEnemies.Enemies = roomElements.Item4;
            roomNPCs.NPCs = roomElements.Item5;
            roomItems.Items = roomElements.Item6;
        }

        public void RemoveDead()
        {
            roomEnemies.EnemySpawnUpdate();
            roomEnemies.RemoveDead();
            roomWeapon.RemoveDead();
            roomProjectile.RemoveDead();
            roomWeapon.RemoveDeadTwo();
            roomProjectile.RemoveDeadTwo();
            roomWeapon.RemoveDeadTwo();
            roomSound.RemoveDead();
        }

        public void Clear()
        {
            roomWeapon.Clear();
            roomProjectile.Clear();
            roomSound.Clear();
        }

        public void Update()
        {
            roomSprite.Update();
            roomProjectile.Update();
            roomWeapon.Update();
            roomBlocks.Update();
            roomEnemies.Update();
            roomNPCs.Update();
            roomItems.Update();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            roomSprite.Draw(spriteBatch);
            roomBlocks.Draw(spriteBatch);
            roomWeapon.Draw(spriteBatch);
            roomProjectile.Draw(spriteBatch);
            roomEnemies.Draw(spriteBatch);
            roomNPCs.Draw(spriteBatch);
            roomItems.Draw(spriteBatch);
            roomProjectile.Draw(spriteBatch);
        }
    }
}