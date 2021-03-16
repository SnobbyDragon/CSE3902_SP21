using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

//Author: Stuti Shah
//Updated: 03/15/21 by shah.1440
namespace sprint0
{
    public class HUDFactory
    {
        Game1 game1;
        readonly Texture2D texture;

        public HUDFactory(Game1 game)
        {
            this.game1 = game;
            texture = game.Content.Load<Texture2D>("Images/HUDPauseScreen");
        }

        public IHUDInventory MakeHUDItem(String spriteType, Vector2 location)
        {
            switch (spriteType)
            {
                case "rupee inventory":
                    return new RupeeHUD(texture, new Vector2(location.X + 97 * Game1.Scale, location.Y + 16 * Game1.Scale));
                case "key inventory":
                    return new KeyHUD(texture, new Vector2(location.X + 97 * Game1.Scale, location.Y + 32 * Game1.Scale));
                case "bomb inventory":
                    return new BombHUD(texture, new Vector2(location.X + 97 * Game1.Scale, location.Y + 40 * Game1.Scale));
                case "heart":
                    return new HeartHUD(texture, new Vector2(location.X + 176 * Game1.Scale, location.Y + 32 * Game1.Scale));
                default:
                    throw new ArgumentException("Invalid sprite! Sprite factory failed.");
            }
        }

        public IHUD MakeHUD(String spriteType, Vector2 location)
        {
            switch (spriteType)
            {
                case "hud":
                    return new HUD(texture, location);
                case "hudA":
                    return new HUDItemA(texture, new Vector2(location.X + 153 * Game1.Scale, location.Y + 24 * Game1.Scale));
                case "hudB":
                    return new HUDItemB(texture, new Vector2(location.X + 128 * Game1.Scale, location.Y + 24 * Game1.Scale));
                default:
                    throw new ArgumentException("Invalid sprite! Sprite factory failed.");
            }
        }
    }
}
