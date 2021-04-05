using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

//Author: Hannah Johnson and co
/*
 * Last updated: 3/28/21 by he.1528
 */
namespace sprint0
{
    public enum ProjectileEnum
    {
        Boomerang, Arrow, SwordBeam, Flame
    }
    public class ProjectileSpriteFactory
    {
        private readonly Texture2D texture1, texture2, texture3, texture4;
        private readonly Game1 game;
        public ProjectileSpriteFactory(Game1 game)
        {
            this.game = game;
            texture1 = game.Content.Load<Texture2D>("Images/ItemsAndWeapons");
            texture2 = game.Content.Load<Texture2D>("Images/Link");
            texture3 = game.Content.Load<Texture2D>("Images/DungeonEnemies");
            texture4 = game.Content.Load<Texture2D>("Images/Bosses");
        }

        public IProjectile MakeProjectile(string spriteType, Vector2 location, Direction dir, IEntity shooter)
        {
            return spriteType switch
            {
                "boomerang" => new Boomerang(texture3, location, dir, shooter, game.Room),
                "arrow" => new Arrow(texture1, location, dir, shooter, game.Room),
                "sword beam" => new SwordBeam(texture2, location, dir, shooter, game.Room),
                "flame" => new FlameProjectile(texture2, location, dir, shooter),
                _ => throw new ArgumentException("Invalid sprite! Sprite factory failed."),
            };
        }
        public IProjectile MakeFireball(Vector2 location, Vector2 direction, IEntity source)
        {
            if (source is Statue)
                return new Fireball(texture3, location, direction, source);
            return new Fireball(texture4, location, direction, source);
        }
    }
}
