using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace sprint0
{
    public class BossesSpriteFactory
    {
        Game1 game;
        private Texture2D texture;
        

        public BossesSpriteFactory(Game1 game)
        {
            this.game = game;
            texture = game.Content.Load<Texture2D>("Images/Bosses");
        }

        public ISprite MakeSprite(String spriteType, Vector2 location)
        {
            
            switch (spriteType)
            {
     
                case "aquamentus":
                    return new Aquamentus(texture, location, game);
                case "patra":
                    return new Patra(texture, location);
                case "manhandla":
                    return new Manhandla(texture, location, game);
                case "gleeok":
                    return new Gleeok(texture, location, game);
                case "ganon":
                    return new Ganon(texture, location, game);
                case "orange gohma":
                    return new Gohma(texture, location, "orange", game);
                case "blue gohma":
                    return new Gohma(texture, location, "blue", game);
                case "dodongo":
                    return new Dodongo(texture, location);
                case "digdogger":
                    return new Digdogger(texture, location);
                default:
                    throw new ArgumentException("Invalid sprite! Sprite factory failed.");
            }
        }
    }
}
