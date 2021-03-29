using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

//Author: Stuti Shah
//Updated: 03/26/21 by shah.1440
namespace sprint0
{
    public class HUDManager
    {
        private Game1 game;
        private PopulateHUDInventory populateHUDInventory;
        public PopulateHUDInventory PopulateHUDInventory { get => populateHUDInventory; }
        private MainHUD mainHUD;
        private Dictionary<PlayerItems, Rectangle> inventory;
        private List<PlayerItems> aItem;
        public MainHUD MainHUD { get => mainHUD; }

        public HUDManager(Game1 game)
        {
            this.game = game;
            mainHUD = new MainHUD(this.game);
            populateHUDInventory = new PopulateHUDInventory(this.game);
            inventory = game.pauseScreenManager.Inventory();
            aItem = game.pauseScreenManager.AItems();
        }

        public void Update()
        {
            inventory = game.pauseScreenManager.Inventory();
            aItem = game.pauseScreenManager.AItems();
            populateHUDInventory.Update();
            mainHUD.Update();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            mainHUD.Draw(spriteBatch);
            populateHUDInventory.DrawItemHUD(spriteBatch);
        }

        public void LoadHUD()
        {
            mainHUD.PopulateMainHUD();
            populateHUDInventory.PopulateInventoryHUD();
        }

        public bool HasBowAndArrow()
        {
            return (inventory.ContainsKey(PlayerItems.Arrow) || inventory.ContainsKey(PlayerItems.SilverArrow)) && inventory.ContainsKey(PlayerItems.Bow);
        }

        public bool HasSword()
        {
            return aItem.Contains(PlayerItems.Sword) || aItem.Contains(PlayerItems.WhiteSword) || aItem.Contains(PlayerItems.MagicalSword);
        }

        public bool HasBlueCandle()
        {
            return inventory.ContainsKey(PlayerItems.BlueCandle);
        }

        public bool CanUseBomb()
        {
            return inventory.ContainsKey(PlayerItems.Bomb) && (populateHUDInventory.GetNum(PlayerItems.Bomb) > 0);
        }

        public bool HasBoomerang()
        {
            return inventory.ContainsKey(PlayerItems.MagicalBoomerang) || inventory.ContainsKey(PlayerItems.Boomerang);
        }

        public bool HasMap()
        {
            return inventory.ContainsKey(PlayerItems.Map);
        }

        public bool HasCompass()
        {
            return inventory.ContainsKey(PlayerItems.Compass);
        }

        public void Refresh()
        {
            populateHUDInventory = new PopulateHUDInventory(game);
            inventory = game.pauseScreenManager.Inventory();
            aItem = game.pauseScreenManager.AItems();
        }
    }
}
