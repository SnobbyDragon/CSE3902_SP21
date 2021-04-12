using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

//Author: Stuti Shah
//Updated: 04/03/21 by shah.1440
namespace sprint0
{
    public class MainHUD
    {
        private readonly HUDFactory hudFactory;
        private Dictionary<PlayerItems, IHUD> hudMainItems;
        private HUDMiniMap hudMiniMap;

        public MainHUD(Game1 game) => hudFactory = new HUDFactory(game);

        public void PopulateMainHUD()
        {
            hudMainItems = new Dictionary<PlayerItems, IHUD>
            {
                {PlayerItems.HUD, hudFactory.MakeHUD(HUDEnum.HUD, new Vector2(0,0)) },
                {PlayerItems.AItem, hudFactory.MakeHUD(HUDEnum.HUDA, new Vector2(0,0)) },
                {PlayerItems.BItem, hudFactory.MakeHUD(HUDEnum.HUDB, new Vector2(0,0)) },
            };
            hudMiniMap = hudFactory.MakeMiniMap();
        }

        public void UpdateBItem(PlayerItems item) => hudMainItems[PlayerItems.BItem].Item = item;

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (KeyValuePair<PlayerItems, IHUD> hudElement in hudMainItems)
                hudElement.Value.Draw(spriteBatch);
            hudMiniMap.Draw(spriteBatch);
        }

        public PlayerItems GetItem(PlayerItems item)
        {
            if (hudMainItems.ContainsKey(item)) return hudMainItems[item].Item;
            else return PlayerItems.None;
        }

        public void SetItem(PlayerItems source, PlayerItems newItem)
        {
            if (hudMainItems.ContainsKey(source) && source == PlayerItems.AItem)
                hudMainItems[source].SetAItem(newItem);
            else hudMainItems[source].SetItem(newItem);
        }

        public void Update() => hudMiniMap.Update();

        public void RemoveBItem() => hudMainItems[PlayerItems.BItem].SetItem(PlayerItems.None);
    }
}
