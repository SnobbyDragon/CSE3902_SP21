using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

//Author: Stuti Shah
//Updated: 03/15/21 by shah.1440
namespace sprint0
{
    public class HUDFactory
    {
        private readonly Game1 game;
        private readonly Texture2D texture;
        public Texture2D Texture { get => texture; }

        public HUDFactory(Game1 game)
        {
            this.game = game;
            texture = game.Content.Load<Texture2D>("Images/HUDPauseScreen");
        }

        public IHUDInventory MakeHUDItem(string spriteType, Vector2 location)
        {
            return spriteType switch
            {
                "rupee inventory" => new RupeeHUD(texture, new Vector2(location.X + 97 * Game1.Scale, location.Y + 16 * Game1.Scale)),
                "key inventory" => new KeyHUD(texture, new Vector2(location.X + 97 * Game1.Scale, location.Y + 32 * Game1.Scale)),
                "bomb inventory" => new BombHUD(texture, new Vector2(location.X + 97 * Game1.Scale, location.Y + 40 * Game1.Scale)),
                "heart" => new HeartHUD(texture, new Vector2(location.X + 176 * Game1.Scale, location.Y + 32 * Game1.Scale)),
                _ => throw new ArgumentException("Invalid sprite! Sprite factory failed."),
            };
        }

        public IHUD MakeHUD(string spriteType, Vector2 location)
        {
            return spriteType switch
            {
                "hud" => new HUD(texture, location),
                "hudA" => new HUDItem(texture, new Vector2((location.X + 153) * Game1.Scale, location.Y + 24 * Game1.Scale)),
                "hudB" => new HUDItem(texture, new Vector2((location.X + 128) * Game1.Scale, location.Y + 24 * Game1.Scale)),
                "inventory" => new HUDInventory(game),
                //"location" => new HUDLocation(texture, location),
                _ => throw new ArgumentException("Invalid sprite! Sprite factory failed."),
            };
        }
        public HUDMiniMap MakeMiniMap()
        {
            return new HUDMiniMap(game);
        }
    }
}
