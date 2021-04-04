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
        private Game1 game;
        private PopulateHUDInventory populateHUDInventory;
        private readonly MainHUD mainHUD;
        private HUDInventory pauseInventory;
        private List<PlayerItems>
            swordList = new List<PlayerItems> { PlayerItems.Sword, PlayerItems.WhiteSword, PlayerItems.MagicalSword },
            arrowList = new List<PlayerItems> { PlayerItems.Arrow, PlayerItems.SilverArrow },
            boomerangList = new List<PlayerItems> { PlayerItems.Boomerang, PlayerItems.MagicalBoomerang };

        public int Health { get => health; set => health = value; }
        public PlayerItems CurrentItem { get => currentItem; }
        private PlayerItems currentItem;
        private int health;


        public HUDManager(Game1 game)
        {
            this.game = game;
            mainHUD = new MainHUD(this.game);
            currentItem = PlayerItems.None;
            pauseInventory = game.universalScreenManager.pauseScreenManager.HUDInventory;
            populateHUDInventory = new PopulateHUDInventory(this.game);
            //health = populateHUDInventory.GetNum(PlayerItems.Heart);
        }

        public void Update()
        {
            Refresh();

            populateHUDInventory.Update();
            health = populateHUDInventory.GetNum(PlayerItems.Heart);
            mainHUD.Update();
            currentItem = mainHUD.GetItem(PlayerItems.BItem);
            pauseInventory.Update();
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
        public bool HasBowAndArrow() => pauseInventory.HasItem(PlayerItems.Bow) && pauseInventory.HasItem(arrowList);
        public bool HasSword() => pauseInventory.HasItem(swordList);
        public bool HasBlueCandle() => pauseInventory.HasItem(PlayerItems.BlueCandle);
        public bool CanUseBomb() => pauseInventory.HasItem(PlayerItems.Bomb) && (populateHUDInventory.GetNum(PlayerItems.Bomb) > 0);
        public bool HasBoomerang() => pauseInventory.HasItem(boomerangList);
        public bool HasMap() => pauseInventory.HasItem(PlayerItems.Map);
        public bool HasCompass() => pauseInventory.HasItem(PlayerItems.Compass);

        private void Refresh() => pauseInventory = game.universalScreenManager.pauseScreenManager.HUDInventory;

        public PlayerItems GetBItem() => mainHUD.GetItem(PlayerItems.BItem);
        public void AddBItem(PlayerItems item) => pauseInventory.AddItem(item);
        public void SetItem(PlayerItems source, PlayerItems item)
        {
            mainHUD.SetItem(source, item);
            if (source == PlayerItems.BItem)
                pauseInventory.SetItem(item);
            else pauseInventory.AddAItem(item);
        }
        public void RemoveBItem(PlayerItems item)
        {
            mainHUD.RemoveBItem();
            pauseInventory.RemoveItem(item);
        }
        public void RemoveBomb()
        {
            if (!CanUseBomb() && currentItem == PlayerItems.Bomb)
                RemoveBItem(PlayerItems.Bomb);
        }
        public void GainHealth(int num) => populateHUDInventory.GainHealth(num);
        public void ChangeNum(PlayerItems item, int num) => populateHUDInventory.ChangeNum(item, num);
        public void Increment(PlayerItems item) => populateHUDInventory.IncrementItem(item);
        public void Decrement(PlayerItems item) => populateHUDInventory.DecrementItem(item);
        public void TakeDamage(int damage) => health = populateHUDInventory.TakeDamage(damage);
    }
}
