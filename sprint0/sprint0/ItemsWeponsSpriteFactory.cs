using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace sprint0
{
    public class ItemsWeponsSpriteFactory
    {
        Game1 game;

        public ItemsWeponsSpriteFactory(Game1 game)
        {
            this.game = game;
        }

        public ISprite MakeSprite(String spriteType, Vector2 location)
        {
            Texture2D texture;
            texture = game.Content.Load<Texture2D>("Images/ItemsAndWeapons");
            switch (spriteType)
            {
                
                case "red heart":
                    return new Heart(texture, location, "red");
                case "half heart":
                    return new Heart(texture, location, "half");
                case "pink heart":
                    return new Heart(texture, location, "pink");
                case "blue heart":
                    return new Heart(texture, location, "blue");
                case "heart container":
                    return new HeartContainer(texture, location);
                default:
                    throw new ArgumentException("Invalid sprite! Sprite factory failed.");
            }
        }
    }
}
