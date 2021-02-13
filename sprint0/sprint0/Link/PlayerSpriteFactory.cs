using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace sprint0
{
    public class PlayerSpriteFactory
    {
        Game1 game;
        Texture2D texture;

        public PlayerSpriteFactory(Game1 game)
        {
            this.game = game;
            texture = game.Content.Load<Texture2D>("Images/Link");
        }

        public ISprite MakeSprite(String spriteType, Vector2 location)
        {
            switch (spriteType)
            {
                case "link up idle":
                    return new UpIdleLinkSprite(texture, location);
                case "link down idle":
                    return new DownIdleLinkSprite(texture, location);
                case "link left idle":
                    return new LeftIdleLinkSprite(texture, location);
                case "link right idle":
                    return new RightIdleLinkSprite(texture, location);
                case "link up walking":
                    return new UpWalkingLinkSprite(texture, location);
                default:
                    throw new ArgumentException("Invalid sprite! Player sprite factory failed.");
            }
        }
    }
}
