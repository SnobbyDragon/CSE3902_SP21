using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

//Author: Stuti Shah
//Updated: 03/24/21 by shah.1440
namespace sprint0
{
    public class HUDManager
    {
        private Game1 game;
        private PopulateHUDInventory populateHUDInventory;
        public PopulateHUDInventory PopulateHUDInventory { get => populateHUDInventory; }
        private MainHUD mainHUD;
        public MainHUD MainHUD { get => mainHUD; }

        public HUDManager(Game1 game)
        {
            this.game = game;
            mainHUD = new MainHUD(this.game);
            populateHUDInventory = new PopulateHUDInventory(this.game);
        }

        public void Update()
        {
            populateHUDInventory.Update();
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
    }
}
