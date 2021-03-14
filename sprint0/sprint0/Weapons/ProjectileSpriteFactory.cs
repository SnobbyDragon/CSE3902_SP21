using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

//Author: Hannah Johnson and co
/*
 * Last updated: 3/14/21 by shah.1440
 */
namespace sprint0
{
    public class ProjectileSpriteFactory
    {
        private readonly Texture2D texture1, texture2, texture3;

        public ProjectileSpriteFactory(Game1 game)
        {
            texture1 = game.Content.Load<Texture2D>("Images/ItemsAndWeapons");
            texture2 = game.Content.Load<Texture2D>("Images/Link");
            texture3 = game.Content.Load<Texture2D>("Images/DungeonEnemies");
        }
        /*
         * Note: if the lifespan is predetermined (for instance with "bomb", use 0)
         */
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
        // need different method because has vector direction
        public IProjectile MakeFireball(Vector2 location, Vector2 direction, IEntity source)
        {
            return new Fireball(texture3, location, direction, source);
        }
    }
}
