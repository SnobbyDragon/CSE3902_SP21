using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

//Author: Hannah Johnson and co
/*
 * Last updated: 2/21/21 by urick.9
 */
namespace sprint0
{
    public class ItemsWeaponsSpriteFactory
    {
        private readonly Game1 game;
        private readonly Texture2D texture;

        public ItemsWeaponsSpriteFactory(Game1 game)
        {
            this.game = game;
            texture = game.Content.Load<Texture2D>("Images/ItemsAndWeapons");
        }
        /*
         * Note: if the lifespan is predetermined(for instnace with "bomb", use 0)
         */
        public ISprite MakeSprite(String spriteType, Vector2 location, Direction dir, int lifespan)
        {


            return spriteType switch
            {
                "red heart" => new Heart(texture, location, "red"),
                "half heart" => new Heart(texture, location, "half"),
                "pink heart" => new Heart(texture, location, "pink"),
                "blue heart" => new Heart(texture, location, "blue"),
                "heart container" => new HeartContainer(texture, location),
                "fairy" => new Fairy(texture, location),
                "bomb" => new Bomb(texture, location, dir),
                "clock" => new Clock(texture, location),
                "boomerang" => new Boomerang(texture, location, dir),
                "bow" => new Bow(texture, location),
                "gold triforce piece" => new TriforcePiece(texture, location, "gold"),
                "blue triforce piece" => new TriforcePiece(texture, location, "blue"),
                "arrow" => new Arrow(texture, location, dir, lifespan),
                "compass" => new Compass(texture, location),
                "key" => new Key(texture, location),
                "rupee" => new Rupee(texture, location),
                _ => throw new ArgumentException("Invalid sprite! Sprite factory failed."),
            };
        }
    }
}
