using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

/*
 * Last updated: 04/01/21 by he.1528
 */
namespace sprint0
{
    public class EffectSpriteFactory
    {
        private readonly Texture2D texture2;

        public EffectSpriteFactory(Game1 game)
        {
            texture2 = game.Content.Load<Texture2D>("Images/Link");
        }
        public IEffect MakeSprite(string spriteType, Vector2 location)
        {
            return spriteType switch
            {
                "hit sprite" => new HitSprite(texture2, location),
                "sword beam explode" => new SwordBeamExplode(texture2, location),
                "death" => new DeathCloud(texture2, location),
                _ => throw new ArgumentException("Invalid sprite! " + spriteType + " Sprite factory failed."),
            };
        }


    }
}
