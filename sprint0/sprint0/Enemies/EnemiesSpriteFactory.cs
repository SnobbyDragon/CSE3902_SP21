using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

//Author: Hannah Johnson and co

namespace sprint0
{
    public class EnemiesSpriteFactory
    {
        Game1 game;
        private Texture2D texture;

        public EnemiesSpriteFactory(Game1 game)
        {
            this.game = game;
            texture = game.Content.Load<Texture2D>("Images/DungeonEnemies");
        }

        public IEnemy MakeSprite(String spriteType, Vector2 location)
        {

            return spriteType switch
            {
                "wallmaster" => new Wallmaster(texture, location),
                "teal gel" => new Gel(texture, location, "teal"),
                "blue gel" => new Gel(texture, location, "blue"),
                "green gel" => new Gel(texture, location, "green"),
                "blkgold gel" => new Gel(texture, location, "blkgold"),
                "lime gel" => new Gel(texture, location, "lime"),
                "brown gel" => new Gel(texture, location, "brown"),
                "grey gel" => new Gel(texture, location, "grey"),
                "blkwhite gel" => new Gel(texture, location, "blkwhite"),
                "green zol" => new Zol(texture, location, "green"),
                "blkgold zol" => new Zol(texture, location, "blkgold"),
                "lime zol" => new Zol(texture, location, "lime"),
                "brown zol" => new Zol(texture, location, "brown"),
                "grey zol" => new Zol(texture, location, "grey"),
                "blkwhite zol" => new Zol(texture, location, "blkwhite"),
                "snake" => new Snake(texture, location),
                "red goriya" => new Goriya(texture, location, "red"),
                "blue goriya" => new Goriya(texture, location, "blue"),
                "red keese" => new Keese(texture, location, "red"),
                "blue keese" => new Keese(texture, location, "blue"),
                "stalfos" => new Stalfos(texture, location),
                "trap" => new Trap(texture, location),
                //"goriya boomerang horizontal" => new GoriyaBoomerang(texture, location, 0), TODO move to projectile or change to enemy?
                //"goriya boomerang vertical" => new GoriyaBoomerang(texture, location, 2),
                //"goriya boomerang diagonal" => new GoriyaBoomerang(texture, location, 4),
                _ => throw new ArgumentException("Invalid sprite! Sprite factory failed."),
            };
        }
    }
}
