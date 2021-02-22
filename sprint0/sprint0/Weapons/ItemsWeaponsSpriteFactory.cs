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
        private readonly Texture2D texture1;
        private readonly Texture2D texture2;

        public ItemsWeaponsSpriteFactory(Game1 game)
        {
            this.game = game;
            texture1 = game.Content.Load<Texture2D>("Images/ItemsAndWeapons");
            texture2 = game.Content.Load<Texture2D>("Images/Link");
        }
        /*
         * Note: if the lifespan is predetermined(for instnace with "bomb", use 0)
         */
        public ISprite MakeSprite(String spriteType, Vector2 location, Direction dir, int lifespan)
        {


            return spriteType switch
            {
                "red heart" => new Heart(texture1, location, "red"),
                "half heart" => new Heart(texture1, location, "half"),
                "pink heart" => new Heart(texture1, location, "pink"),
                "blue heart" => new Heart(texture1, location, "blue"),
                "heart container" => new HeartContainer(texture1, location),
                "fairy" => new Fairy(texture1, location),
                "bomb" => new Bomb(texture2, location, dir, lifespan),
                "clock" => new Clock(texture1, location),
                "boomerang" => new Boomerang(texture1, location, dir),
                "bow" => new Bow(texture1, location),
                "gold triforce piece" => new TriforcePiece(texture1, location, "gold"),
                "blue triforce piece" => new TriforcePiece(texture1, location, "blue"),
                "arrow" => new Arrow(texture1, location, dir, lifespan),
                "compass" => new Compass(texture1, location),
                "key" => new Key(texture1, location),
                "rupee" => new Rupee(texture1, location),
                _ => throw new ArgumentException("Invalid sprite! Sprite factory failed."),
            };
        }
    }
}
