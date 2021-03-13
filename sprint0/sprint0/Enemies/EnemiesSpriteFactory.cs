using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

//Author: Hannah Johnson and co

namespace sprint0
{
    public class EnemiesSpriteFactory
    {
        private readonly Game1 game;
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
                "wallmaster" => new Wallmaster(texture, location, game),
                "teal gel" => new Gel(texture, location, game, "teal"),
                "blue gel" => new Gel(texture, location, game, "blue"),
                "green gel" => new Gel(texture, location, game, "green"),
                "blkgold gel" => new Gel(texture, location, game, "blkgold"),
                "lime gel" => new Gel(texture, location, game, "lime"),
                "brown gel" => new Gel(texture, location, game, "brown"),
                "grey gel" => new Gel(texture, location, game, "grey"),
                "blkwhite gel" => new Gel(texture, location, game, "blkwhite"),
                "green zol" => new Zol(texture, location, "green", game),
                "blkgold zol" => new Zol(texture, location, "blkgold", game),
                "lime zol" => new Zol(texture, location, "lime", game),
                "brown zol" => new Zol(texture, location, "brown", game),
                "grey zol" => new Zol(texture, location, "grey", game),
                "blkwhite zol" => new Zol(texture, location, "blkwhite", game),

                "snake" => new Snake(texture, location,game),
                "red goriya" => new Goriya(texture, location, "red", game),
                "blue goriya" => new Goriya(texture, location, "blue", game),
                "red keese" => new Keese(texture, location, "red", game),
                "blue keese" => new Keese(texture, location, "blue", game),
                "stalfos" => new Stalfos(texture, location, game),
                "trap" => new Trap(texture, location, game),

                //"goriya boomerang horizontal" => new GoriyaBoomerang(texture, location, 0), TODO move to projectile or change to enemy?
                //"goriya boomerang vertical" => new GoriyaBoomerang(texture, location, 2),
                //"goriya boomerang diagonal" => new GoriyaBoomerang(texture, location, 4),
                _ => throw new ArgumentException("Invalid sprite! Sprite factory failed."),
            };
        }
    }
}
