using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

//Author: Stuti Shah
//Updated: 04/03/21 by shah.1440
namespace sprint0
{
    public class PauseScreenManager
    {
        private readonly Game1 game;
        private readonly PauseScreen pauseScreen;
        private readonly HUDInventory hudInventory;
        private readonly PauseScreenMap pauseScreenMap;
        private readonly ItemSelection itemSelection;
        private bool itemSetup;

        public PauseScreenManager(Game1 game)
        {
            this.game = game;
            pauseScreen = new PauseScreen(this.game);
            hudInventory = new HUDInventory(this.game);
            pauseScreenMap = new PauseScreenMap(this.game);
            hudInventory.Item = PlayerItems.None;
            itemSelection = new ItemSelection(this.game);
            itemSetup = true;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            pauseScreen.Draw(spriteBatch);
            hudInventory.Draw(spriteBatch);
            itemSelection.Draw(spriteBatch);
            pauseScreenMap.Draw(spriteBatch);
        }

        public void Update()
        {
            pauseScreenMap.Update();
            hudInventory.Item = game.hudManager.CurrentItem;
            itemSetup = true;
        }

        public PlayerItems BItem() => hudInventory.Item;
        public void HandleLeft() => itemSelection.HandleLeft();
        public void HandleRight() => itemSelection.HandleRight();
        public PlayerItems GetSelectedItem() => itemSelection.GetSelectedItem();
        public void UpdateItemSelection()
        {
            itemSelection.Update();
            if (itemSelection.GetSelectedItem() != PlayerItems.None)
                hudInventory.Item = itemSelection.GetSelectedItem();
        }

        public HUDInventory Inventory() => hudInventory;
        public void SetupItemSelector()
        {
            if (itemSetup)
            {
                itemSelection.GetCurrentItem(hudInventory.Item);
                itemSelection.GetInventory(hudInventory.InventoryItems);
                itemSetup = false;
            }
        }
    }
}
