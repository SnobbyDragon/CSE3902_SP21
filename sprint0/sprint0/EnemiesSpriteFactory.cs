using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace sprint0
{
    public class EnemiesSpriteFactory
    {
        Game1 game;

        public EnemiesSpriteFactory(Game1 game)
        {
            this.game = game;
        }

        public ISprite MakeSprite(String spriteType, Vector2 location)
        {
            Texture2D texture;
            texture = game.Content.Load<Texture2D>("Images/DungeonEnemies");
            switch (spriteType)
            {
                
                case "wallmaster":
                    return new Wallmaster(texture, location);
                default:
                    throw new ArgumentException("Invalid sprite! Sprite factory failed.");
            }
        }
    }
}
