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
                    return new Aquamentus(texture, location);
                case "aquamentus fireball":
                    return new AquamentusFireball(texture, location);
                case "patra":
                    return new Patra(texture, location);
                case "patra minion":
                    return new PatraMinion(texture, location);
                case "manhandla":
                    return new Manhandla(texture, location);
                case "manhandla fireball":
                    return new ManhandlaFireball(texture, location);
                case "gleeok":
                    return new Gleeok(texture, location);
                case "gleeok fireball":
                    return new GleeokFireball(texture, location);
                case "ganon":
                    return new Ganon(texture, location);
                case "ganon fireball center":
                    return new GanonFireball(texture, location, "center");
                case "ganon fireball up":
                    return new GanonFireball(texture, location, "up");
                case "ganon fireball up left":
                    return new GanonFireball(texture, location, "up left");
                case "ganon fireball left":
                    return new GanonFireball(texture, location, "left");
                case "ganon fireball down left":
                    return new GanonFireball(texture, location, "down left");
                case "ganon fireball down":
                    return new GanonFireball(texture, location, "down");
                case "ganon fireball down right":
                    return new GanonFireball(texture, location, "down right");
                case "ganon fireball right":
                    return new GanonFireball(texture, location, "right");
                case "ganon fireball up right":
                    return new GanonFireball(texture, location, "up right");
                case "orange gohma":
                    return new Gohma(texture, location, "orange");
                case "blue gohma":
                    return new Gohma(texture, location, "blue");
                case "dodongo":
                    return new Dodongo(texture, location);
                default:
                    throw new ArgumentException("Invalid sprite! Sprite factory failed.");
            }
        }
    }
}
