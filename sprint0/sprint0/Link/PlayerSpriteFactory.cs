﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace sprint0
{
    public class PlayerSpriteFactory
    {
        readonly Texture2D texture;

        public PlayerSpriteFactory(Game1 game)
        {
            texture = game.Content.Load<Texture2D>("Images/Link");
        }

        public ISprite MakeSprite(String spriteType, Vector2 location)
        {
            return spriteType switch
            {
                "link up idle" => new UpIdleLinkSprite(texture, location),
                "link down idle" => new DownIdleLinkSprite(texture, location),
                "link left idle" => new LeftIdleLinkSprite(texture, location),
                "link right idle" => new RightIdleLinkSprite(texture, location),
                "link up sword" => new UpWoodSwordSprite(texture, location),
                "link down sword" => new DownWoodSwordSprite(texture, location),
                "link left sword" => new LeftWoodSwordSprite(texture, location),
                "link right sword" => new RightWoodSwordSprite(texture, location),
                "link up walking" => new UpWalkingLinkSprite(texture, location),
                "link down walking" => new DownWalkingLinkSprite(texture, location),
                "link left walking" => new LeftWalkingLinkSprite(texture, location),
                "link right walking" => new RightWalkingLinkSprite(texture, location),
                _ => throw new ArgumentException("Invalid sprite! Player sprite factory failed."),
            };
        }
    }
}
