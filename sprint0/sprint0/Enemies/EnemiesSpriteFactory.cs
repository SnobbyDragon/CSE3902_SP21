using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace sprint0
{
    public class EnemiesSpriteFactory
    {
        Game1 game;
        private Texture2D texture;

        public EnemiesSpriteFactory(Game1 game)
        {
            this.game = game;
            texture = game.Content.Load<Texture2D>("Images/DungeonEnemies");
        }

        public ISprite MakeSprite(String spriteType, Vector2 location)
        {

            switch (spriteType)
            {

                case "wallmaster":
                    return new Wallmaster(texture, location);
                case "teal gel":
                    return new Gel(texture, location, "teal");
                case "blue gel":
                    return new Gel(texture, location, "blue");
                case "green gel":
                    return new Gel(texture, location, "green");
                case "blkgold gel":
                    return new Gel(texture, location, "blkgold");
                case "lime gel":
                    return new Gel(texture, location, "lime");
                case "brown gel":
                    return new Gel(texture, location, "brown");
                case "grey gel":
                    return new Gel(texture, location, "grey");
                case "blkwhite gel":
                    return new Gel(texture, location, "blkwhite");
                case "green zol":
                    return new Zol(texture, location, "green");
                case "blkgold zol":
                    return new Zol(texture, location, "blkgold");
                case "lime zol":
                    return new Zol(texture, location, "lime");
                case "brown zol":
                    return new Zol(texture, location, "brown");
                case "grey zol":
                    return new Zol(texture, location, "grey");
                case "blkwhite zol":
                    return new Zol(texture, location, "blkwhite");
                case "snake":
                    return new Snake(texture, location);
                case "red goriya":
                    return new Goriya(texture, location, "red");
                case "blue goriya":
                    return new Goriya(texture, location, "blue");
                case "red keese":
                    return new Keese (texture, location, "red");
                case "blue keese":
                    return new Keese (texture, location, "blue");
                case "stalfos":
                    return new Stalfos(texture, location);
                case "trap":
                    return new Trap(texture, location);
                default:
                    throw new ArgumentException("Invalid sprite! Sprite factory failed.");
            }
        }
    }
}
