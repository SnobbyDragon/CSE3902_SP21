using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

//Author: Hannah Johnson and co
/*
 * Last updated: 3/14/21 by shah.1440
 */
namespace sprint0
{
    public class MiscSpriteFactory
    {
        private readonly Texture2D texture1;

        public MiscSpriteFactory(Game1 game)
        {
            texture1 = game.Content.Load<Texture2D>("Images/ItemsAndWeapons");
        }
        public ISprite MakeSprite(string spriteType, Vector2 location)
        {
            return spriteType switch
            {
                "red heart" => new Heart(texture1, location, "red"),
                "half heart" => new Heart(texture1, location, "half"),
                "pink heart" => new Heart(texture1, location, "pink"),
                "blue heart" => new Heart(texture1, location, "blue"),
                _ => throw new ArgumentException("Invalid sprite! " + spriteType + " Sprite factory failed."),
            };
        }


    }
}
