using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

//Author: Hannah Johnson and co

namespace sprint0
{
    public class EnemiesSpriteFactory
    {
        private readonly Game1 game;
        private readonly Texture2D texture;
        private readonly Texture2D textureSpawn;

        public EnemiesSpriteFactory(Game1 game)
        {
            this.game = game;
            texture = game.Content.Load<Texture2D>("Images/DungeonEnemies");
            textureSpawn = game.Content.Load<Texture2D>("Images/Link");
        }

        public IEnemy MakeSprite(string spriteType, Vector2 location)
        {

            return spriteType switch
            {
                "wallmaster" => new Wallmaster(texture, location, game),
                "teal gel" => new Gel(texture, location, game, Color.Teal),
                "blue gel" => new Gel(texture, location, game, Color.Blue),
                "green gel" => new Gel(texture, location, game, Color.Green),
                "gold gel" => new Gel(texture, location, game, Color.Gold),
                "lime gel" => new Gel(texture, location, game, Color.Lime),
                "brown gel" => new Gel(texture, location, game, Color.Brown),
                "gray gel" => new Gel(texture, location, game, Color.Gray),
                "white gel" => new Gel(texture, location, game, Color.White),
                "green zol" => new Zol(texture, location, Color.Green, game),
                "gold zol" => new Zol(texture, location, Color.Gold, game),
                "lime zol" => new Zol(texture, location, Color.Lime, game),
                "brown zol" => new Zol(texture, location, Color.Brown, game),
                "gray zol" => new Zol(texture, location, Color.Gray, game),
                "white zol" => new Zol(texture, location, Color.White, game),
                "snake" => new Snake(texture, location, game),
                "red goriya" => new Goriya(texture, location, Color.Red, game),
                "blue goriya" => new Goriya(texture, location, Color.Blue, game),
                "red keese" => new Keese(texture, location, Color.Red, game),
                "blue keese" => new Keese(texture, location, Color.Blue, game),
                "stalfos" => new Stalfos(texture, location, game),
                "trap" => new Trap(texture, location, game),
                "trapparatus" => new Trapparatus(texture, location, game),
                _ => throw new ArgumentException("Invalid sprite! " + spriteType + " Sprite factory failed."),
            };
        }

        public IEnemy MakeSpawn(string enemy, Vector2 location)
        {
            return new SpawnCloud(textureSpawn, location, game, enemy);
        }
    }
}
