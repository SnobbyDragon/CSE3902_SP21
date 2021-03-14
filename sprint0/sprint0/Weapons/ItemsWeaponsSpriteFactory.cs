using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

//Author: Hannah Johnson and co
/*
 * Last updated: 3/14/21 by li.10011
 */
namespace sprint0
{
    public class ItemsWeaponsSpriteFactory
    {
        private readonly Texture2D texture1, texture2, texture3;

        public ItemsWeaponsSpriteFactory(Game1 game)
        {
            texture1 = game.Content.Load<Texture2D>("Images/ItemsAndWeapons");
            texture2 = game.Content.Load<Texture2D>("Images/Link");
            texture3 = game.Content.Load<Texture2D>("Images/DungeonEnemies");
        }
        /*
         * Note: if the lifespan is predetermined (for instance with "bomb", use 0)
         */
        public ISprite MakeSprite(string spriteType, Vector2 location, Direction dir, int lifespan)
        {
            return spriteType switch
            {
                "red heart" => new Heart(texture1, location, "red"),
                "half heart" => new Heart(texture1, location, "half"),
                "pink heart" => new Heart(texture1, location, "pink"),
                "blue heart" => new Heart(texture1, location, "blue"),
                _ => throw new ArgumentException("Invalid sprite! " + spriteType + " Sprite factory failed."),
            };
        }

        public IItem MakeItem(string spriteType, Vector2 location, Direction dir, int lifespan)
        {
            return spriteType switch
            {
                "blue boomerang" => new BlueBoomerangItem(texture1, location),
                "boomerang" => new BoomerangItem(texture1, location),
                "blue ring" => new BlueRing(texture1, location),
                "ring" => new Ring(texture1, location),
                "blue candle" => new BlueCandle(texture1, location),
                "candle" => new Candle(texture1, location),
                "meat" => new Meat(texture1, location),
                "blue map" => new BlueMap(texture1, location),
                "map" => new Map(texture1, location),
                "blue potion" => new BluePotion(texture1, location),
                "potion" => new Potion(texture1, location),
                "rupee" => new Rupee(texture1, location),
                "clock" => new Clock(texture1, location),
                "bow" => new Bow(texture1, location),
                "heart container" => new HeartContainer(texture1, location),
                "gold triforce piece" => new TriforcePiece(texture1, location, "gold"),
                "blue triforce piece" => new TriforcePiece(texture1, location, "blue"),
                "compass" => new Compass(texture1, location),
                "key" => new Key(texture1, location),
                "fairy" => new Fairy(texture1, location),
                _ => throw new ArgumentException("Invalid sprite! " + spriteType + " Sprite factory failed."),
            };
        }

        public IProjectile MakeProjectile(string spriteType, Vector2 location, Direction dir, IEntity shooter)
        {
            return spriteType switch
            {
                "boomerang" => new Boomerang(texture3, location, dir, shooter),
                "arrow" => new Arrow(texture1, location, dir, shooter),
                "sword beam" => new SwordBeam(texture2, location, dir, shooter),
                _ => throw new ArgumentException("Invalid sprite! Sprite factory failed."),
            };
        }

        public IWeapon MakeWeapon(string spriteType, Vector2 location, Direction dir, IPlayer player)
        {
            return spriteType switch
            {
                "bomb" => new Bomb(texture2, location, dir),
                "sword" => new Sword(location, dir, player),
                _ => throw new ArgumentException("Invalid sprite! Sprite factory failed."),
            };
        }

        // need different method because has vector direction
        public IProjectile MakeFireball(Vector2 location, Vector2 direction, IEntity source)
        {
            return new Fireball(texture3, location, direction, source);
        }
    }
}
