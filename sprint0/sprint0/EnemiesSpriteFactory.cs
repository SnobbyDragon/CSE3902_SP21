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
                default:
                    throw new ArgumentException("Invalid sprite! Sprite factory failed.");
            }
        }
    }
}
