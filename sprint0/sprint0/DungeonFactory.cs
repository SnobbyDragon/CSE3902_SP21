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
                default:
                    throw new ArgumentException("Invalid sprite! Sprite factory failed.");
            }
        }
    }
}
