using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace sprint0
{
    public class ItemsWeaponsSpriteFactory
    {
        Game1 game;
        Texture2D texture;

        public ItemsWeaponsSpriteFactory(Game1 game)
        {
            this.game = game;
            texture = game.Content.Load<Texture2D>("Images/ItemsAndWeapons");
        }

        public ISprite MakeSprite(String spriteType, Vector2 location)
        {


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
                case "fairy":
                    return new Fairy(texture, location);
                case "bomb":
                    return new Bomb(texture, location);
                case "clock":
                    return new Clock(texture, location);
                case "boomerang":
                    return new Boomerang(texture, location);
                case "bow":
                    return new Bow(texture, location);
                case "triforce piece":
                    return new TriforcePiece(texture, location, "gold");
                case "triforce piece":
                    return new TriforcePiece(texture, location, "blue");
                case "arrow":
                    return new Arrow(texture, location);
                case "compass":
                    return new Compass(texture, location);
                case "key":
                    return new Key(texture, location);
                case "rupee":
                    return new Rupee(texture, location);
                default:
                    throw new ArgumentException("Invalid sprite! Sprite factory failed.");
            }
        }
    }
}
