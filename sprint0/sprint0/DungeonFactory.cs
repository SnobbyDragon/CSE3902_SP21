using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace sprint0
{
    public class DungeonFactory
    {
        private Game1 game;
        private Texture2D texture;

        public DungeonFactory(Game1 game)
        {
            this.game = game;
            texture = game.Content.Load<Texture2D>("Images/DungeonTileset");

        }

        public ISprite MakeSprite(String spriteType, Vector2 location)
        {

            switch (spriteType)
            {

                case "block":
                    return new Block(texture, location);
                case "tile":
                    return new Tile(texture, location);
                case "gap":
                    return new Gap(texture, location);
                case "stairs":
                    return new Stairs(texture, location);
                case "ladder":
                    return new Ladder(texture, location);
                case "brick":
                    return new Brick(texture, location);
                default:
                    throw new ArgumentException("Invalid sprite! Sprite factory failed.");
            }
        }
    }
}
