using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

//Author: Stuti Shah
//Updated: 03/15/21 by shah.1440
namespace sprint0
{
    public class MainHUD
    {
        private readonly HUDFactory hudFactory;
        private List<IHUD> hudMainItems;

        public MainHUD(Game1 game)
        {
            hudFactory = new HUDFactory(game);
        }

        public List<IHUD> PopulateMainHUD()
        {
            hudMainItems = new List<IHUD>
            {
                hudFactory.MakeHUD("hud", new Vector2(0,0)),
                hudFactory.MakeHUD("hudA", new Vector2(0,0)),
                hudFactory.MakeHUD("hudB", new Vector2(0,0)),
            };
            return hudMainItems;
        }

        public void DrawMainHUD(List<IHUD> hudItems, SpriteBatch spriteBatch)
        {
            foreach (IHUD hudElement in hudItems)
                hudElement.Draw(spriteBatch);
        }
    }
}
