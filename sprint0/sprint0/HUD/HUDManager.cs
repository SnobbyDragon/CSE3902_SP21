using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

//Author: Stuti Shah
//Updated: 04/03/21 by shah.1440
namespace sprint0
{
    public class HUDManager
    {
        private readonly Game1 game;
        private readonly PopulateHUDInventory populateHUDInventory;
        private readonly MainHUD mainHUD;
        private readonly HUDInventory pauseInventory;
        private readonly List<PlayerItems>
            arrowList = new List<PlayerItems> { PlayerItems.Arrow, PlayerItems.SilverArrow },
            boomerangList = new List<PlayerItems> { PlayerItems.Boomerang, PlayerItems.MagicalBoomerang };
        public int Health { get => health; set => health = value; }
        public PlayerItems CurrentItem { get => currentItem; }
        public PlayerItems CurrentAItem { get => currentAItem; }
        private PlayerItems currentItem, currentAItem;
        private int health;

        public HUDManager(Game1 game)
        {
            this.game = game;
            mainHUD = new MainHUD(this.game);
            currentItem = PlayerItems.None;
            currentAItem = PlayerItems.None;
            pauseInventory = game.universalScreenManager.PauseScreenManager.Inventory();
            populateHUDInventory = new PopulateHUDInventory(this.game);
        }

        public void Update()
        {
            populateHUDInventory.Update();
            health = populateHUDInventory.GetNum(PlayerItems.Heart);
            mainHUD.Update();
            currentItem = mainHUD.GetItem(PlayerItems.BItem);
            currentAItem = mainHUD.GetItem(PlayerItems.AItem);
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
        public bool HasItem(PlayerItems item) => pauseInventory.HasItem(item);
        public bool HasKeys() => populateHUDInventory.GetNum(PlayerItems.Key) > 0;
        public void DecrementKey()
        {
            if (!HasItem(PlayerItems.MagicalKey) && HasKeys()) Decrement(PlayerItems.Key);
        }
        public bool HasBowAndArrow() => pauseInventory.HasItem(PlayerItems.Bow) && pauseInventory.HasItem(arrowList);
        public bool HasSword() => pauseInventory.HasAItem();
        public bool CanUseBomb() => pauseInventory.HasItem(PlayerItems.Bomb) && (populateHUDInventory.GetNum(PlayerItems.Bomb) > 0);
        public bool HasBoomerang() => pauseInventory.HasItem(boomerangList);
        public void AddBItem(PlayerItems item) => pauseInventory.AddItem(item);
        public void SetItem(PlayerItems source, PlayerItems item)
        {
            mainHUD.SetItem(source, item);
            if (source == PlayerItems.BItem && item != PlayerItems.Map) pauseInventory.SetItem(item);
            else pauseInventory.AddAItem(item);
        }
        public void RemoveBItem(PlayerItems item)
        {
            mainHUD.RemoveBItem();
            pauseInventory.RemoveItem(item);
        }
        public void RemoveBomb()
        {
            if (!CanUseBomb() && currentItem == PlayerItems.Bomb) RemoveBItem(PlayerItems.Bomb);
        }
        public void GainHealth(int num) => populateHUDInventory.GainHealth(num);
        public void ChangeNum(PlayerItems item, int num) => populateHUDInventory.ChangeNum(item, num);
        public void Increment(PlayerItems item) => populateHUDInventory.IncrementItem(item);
        public void Decrement(PlayerItems item) => populateHUDInventory.DecrementItem(item);
        public void TakeDamage(int damage) => health = populateHUDInventory.TakeDamage(damage);
        public void SetBItem(PlayerItems item)
        {
            currentItem = item;
            mainHUD.UpdateBItem(item);
        }
    }
}
