using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

//Author: Hannah Johnson and co

namespace sprint0
{
    public enum EnemyEnum
    {
        Wallmaster, TealGel, BlueGel, GreenGel, GoldGel, LimeGel, BrownGel, GrayGel, WhiteGel,
        GreenZol, GoldZol, LimeZol, BrownZol, GrayZol, WhiteZol,
        Snake, RedGoriya, BlueGoriya, RedKeese, BlueKeese, Stalfos, Trap, Trapparatus,
        Aquamentus, Patra, Manhandla, Gleeok, Ganon, OrangeGohma, BlueGohma, Dodongo, Digdogger,
        Gel, Goriya, Keese, Zol, Gohma, Owl
    }
    public class EnemiesSpriteFactory
    {
        private readonly Game1 game;
        private readonly Texture2D texture;
        private readonly Texture2D texture2;

        public EnemiesSpriteFactory(Game1 game)
        {
            this.game = game;
            texture = game.Content.Load<Texture2D>("Images/DungeonEnemies");
            texture2 = game.Content.Load<Texture2D>("Images/OwlBoss");

        }

        public IEnemy MakeSprite(EnemyEnum spriteType, Vector2 location)
        {

            return spriteType switch
            {
                EnemyEnum.Wallmaster => new Wallmaster(texture, location, game),
                EnemyEnum.TealGel => new Gel(texture, location, game, Color.Teal),
                EnemyEnum.BlueGel => new Gel(texture, location, game, Color.Blue),
                EnemyEnum.GreenGel => new Gel(texture, location, game, Color.Green),
                EnemyEnum.GoldGel => new Gel(texture, location, game, Color.Gold),
                EnemyEnum.LimeGel => new Gel(texture, location, game, Color.Lime),
                EnemyEnum.BrownGel => new Gel(texture, location, game, Color.Brown),
                EnemyEnum.GrayGel => new Gel(texture, location, game, Color.Gray),
                EnemyEnum.WhiteGel => new Gel(texture, location, game, Color.White),
                EnemyEnum.GreenZol => new Zol(texture, location, Color.Green, game),
                EnemyEnum.GoldZol => new Zol(texture, location, Color.Gold, game),
                EnemyEnum.LimeZol => new Zol(texture, location, Color.Lime, game),
                EnemyEnum.BrownZol => new Zol(texture, location, Color.Brown, game),
                EnemyEnum.GrayZol => new Zol(texture, location, Color.Gray, game),
                EnemyEnum.WhiteZol => new Zol(texture, location, Color.White, game),
                EnemyEnum.Snake => new Snake(texture, location, game),
                EnemyEnum.RedGoriya => new Goriya(texture, location, Color.Red, game),
                EnemyEnum.BlueGoriya => new Goriya(texture, location, Color.Blue, game),
                EnemyEnum.RedKeese => new Keese(texture, location, Color.Red, game),
                EnemyEnum.BlueKeese => new Keese(texture, location, Color.Blue, game),
                EnemyEnum.Stalfos => new Stalfos(texture, location, game),
                EnemyEnum.Trap => new Trap(texture, location, game),
                EnemyEnum.Trapparatus => new Trapparatus(texture, location, game),
                EnemyEnum.Owl => new Owl(texture2, location, game),
                _ => throw new ArgumentException("Invalid sprite! " + spriteType.ToString() + " Sprite factory failed."),
            };
        }

    }
}
