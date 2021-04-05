using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace sprint0
{
    public class BossesSpriteFactory
    {
        private readonly Game1 game;
        private readonly Texture2D texture;


        public BossesSpriteFactory(Game1 game)
        {
            this.game = game;
            texture = game.Content.Load<Texture2D>("Images/Bosses");
        }

        public IEnemy MakeSprite(EnemyEnum spriteType, Vector2 location)
        {
            return spriteType switch
            {
                EnemyEnum.Aquamentus => new Aquamentus(texture, location, game),
                EnemyEnum.Patra => new Patra(texture, location, game),
                EnemyEnum.Manhandla => new Manhandla(texture, location, game),
                EnemyEnum.Gleeok => new Gleeok(texture, location, game),
                EnemyEnum.Ganon => new Ganon(texture, location, game),
                EnemyEnum.OrangeGohma => new Gohma(texture, location, "orange", game),
                EnemyEnum.BlueGohma => new Gohma(texture, location, "blue", game),
                EnemyEnum.Dodongo => new Dodongo(texture, location, game),
                EnemyEnum.Digdogger => new Digdogger(texture, location, game),
                _ => throw new ArgumentException("Invalid sprite! " + spriteType + " Sprite factory failed."),
            };
        }
    }
}
