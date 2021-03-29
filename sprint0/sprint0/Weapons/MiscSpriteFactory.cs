using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

//Author: Hannah Johnson and co
/*
 * Last updated: 3/28/21 by he.1528
 */
namespace sprint0
{
    public class MiscSpriteFactory
    {
        private readonly Texture2D texture2;

        public MiscSpriteFactory(Game1 game)
        {
            texture2 = game.Content.Load<Texture2D>("Images/Link");
        }
        public ISprite MakeSprite(string spriteType, Vector2 location)
        {
            return spriteType switch
            {
                "hit sprite" => new HitSprite(texture2, location),
                "sword beam explode" => new SwordBeamExplode(texture2, location),
                _ => throw new ArgumentException("Invalid sprite! " + spriteType + " Sprite factory failed."),
            };
        }


    }
}
