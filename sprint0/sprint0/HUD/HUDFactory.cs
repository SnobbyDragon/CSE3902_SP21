using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

//Author: Stuti Shah
//Updated: 03/15/21 by shah.1440
namespace sprint0
{
    public enum HUDEnum
    {
        Rupee, Key, Bomb, Heart, HUD, HUDA, HUDB
    }
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

        public IHUDInventory MakeHUDItem(HUDEnum spriteType, Vector2 location)
        {
            return spriteType switch
            {
                HUDEnum.Rupee => new AbstractHUDInventory(texture, new Vector2(location.X + 97 * Game1.Scale, location.Y + 16 * Game1.Scale)),
                HUDEnum.Key => new AbstractHUDInventory(texture, new Vector2(location.X + 97 * Game1.Scale, location.Y + 32 * Game1.Scale)),
                HUDEnum.Bomb => new AbstractHUDInventory(texture, new Vector2(location.X + 97 * Game1.Scale, location.Y + 40 * Game1.Scale)),
                HUDEnum.Heart => new HeartHUD(texture, new Vector2(location.X + 176 * Game1.Scale, location.Y + 32 * Game1.Scale)),
                _ => throw new ArgumentException("Invalid sprite! Sprite factory failed."),
            };
        }

        public IHUD MakeHUD(HUDEnum spriteType, Vector2 location)
        {
            return spriteType switch
            {
                HUDEnum.HUD => new HUD(texture, location),
                HUDEnum.HUDA => new HUDItem(texture, new Vector2((location.X + 153) * Game1.Scale, location.Y + 24 * Game1.Scale)),
                HUDEnum.HUDB => new HUDItem(texture, new Vector2((location.X + 128) * Game1.Scale, location.Y + 24 * Game1.Scale)),
                _ => throw new ArgumentException("Invalid sprite! Sprite factory failed."),
            };
        }
        public HUDMiniMap MakeMiniMap() => new HUDMiniMap(game);
    }
}
