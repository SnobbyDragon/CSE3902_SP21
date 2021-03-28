using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

//Author: Stuti Shah
//Updated: 03/26/21 by shah.1440
namespace sprint0
{
    public class PauseScreenManager
    {
        private readonly Game1 game;
        private readonly PauseScreen pauseScreen;
        private HUDInventory hudInventory;
        public HUDInventory HUDInventory { get => hudInventory; set => hudInventory = value; }

        public PauseScreenManager(Game1 game)
        {
            this.game = game;
            pauseScreen = new PauseScreen(this.game);
            hudInventory = new HUDInventory(this.game);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            pauseScreen.Draw(spriteBatch);
            hudInventory.Draw(spriteBatch);
        }

        public void Update()
        {
            hudInventory.SetItem(game.hudManager.MainHUD.GetItem(PlayerItems.BItem));
        }

        public Dictionary<PlayerItems, Rectangle> Inventory()
        {
            return hudInventory.InventoryItems;
        }
        public List<PlayerItems> AItems()
        {
            return hudInventory.AItem;
        }
    }
}
