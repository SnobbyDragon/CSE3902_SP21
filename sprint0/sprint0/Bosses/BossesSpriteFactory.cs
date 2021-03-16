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

        public IEnemy MakeSprite(string spriteType, Vector2 location)
        {

            return spriteType switch
            {
                "aquamentus" => new Aquamentus(texture, location, game),
                "patra" => new Patra(texture, location, game),
                "manhandla" => new Manhandla(texture, location, game),
                "gleeok" => new Gleeok(texture, location, game),
                "ganon" => new Ganon(texture, location, game),
                "orange gohma" => new Gohma(texture, location, "orange", game),
                "blue gohma" => new Gohma(texture, location, "blue", game),
                "dodongo" => new Dodongo(texture, location, game),
                "digdogger" => new Digdogger(texture, location, game),
                _ => throw new ArgumentException("Invalid sprite! " + spriteType + " Sprite factory failed."),
            };
        }
    }
}
