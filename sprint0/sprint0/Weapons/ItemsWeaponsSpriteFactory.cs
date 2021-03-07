using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

//Author: Hannah Johnson and co
/*
 * Last updated: 3/4/21 by li.10011
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
                "heart container" => new HeartContainer(texture1, location),
                "clock" => new Clock(texture1, location),
                "bow" => new Bow(texture1, location),
                "gold triforce piece" => new TriforcePiece(texture1, location, "gold"),
                "blue triforce piece" => new TriforcePiece(texture1, location, "blue"),
                "compass" => new Compass(texture1, location),
                "key" => new Key(texture1, location),
                "rupee" => new Rupee(texture1, location),
                _ => throw new ArgumentException("Invalid sprite! Sprite factory failed."),
            };
        }

        public IProjectile MakeProjectile(string spriteType, Vector2 location, Direction dir, int lifespan, IEntity source)
        {
            return spriteType switch
            {
                "fairy" => new Fairy(texture1, location),
                "bomb" => new Bomb(texture2, location, dir, lifespan, source),
                "boomerang" => new Boomerang(texture3, location, dir, lifespan, source),
                "arrow" => new Arrow(texture1, location, dir, lifespan, source),
                "sword beam" => new SwordBeam(texture2, location, dir, lifespan, source),
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
