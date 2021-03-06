﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace sprint0
{
    public enum LinkEnum
    {
        LinkUpIdle, LinkDownIdle, LinkLeftIdle, LinkRightIdle, LinkUpSword, LinkDownSword, LinkLeftSword, LinkRightSword,
        LinkUpWalking, LinkDownWalking, LinkLeftWalking, LinkRightWalking,
        LinkUpItem, LinkDownItem, LinkLeftItem, LinkRightItem, LinkPickUpItem
    }
    public class PlayerSpriteFactory
    {
        private readonly Texture2D texture;

        public PlayerSpriteFactory(Game1 game)
            => texture = game.Content.Load<Texture2D>("Images/Link");

        public ISprite MakeSprite(LinkEnum spriteType, Vector2 location, PlayerItems swordType = PlayerItems.Sword)
        {
            return spriteType switch
            {
                LinkEnum.LinkUpIdle => new UpIdleLinkSprite(texture, location),
                LinkEnum.LinkDownIdle => new DownIdleLinkSprite(texture, location),
                LinkEnum.LinkLeftIdle => new LeftIdleLinkSprite(texture, location),
                LinkEnum.LinkRightIdle => new RightIdleLinkSprite(texture, location),
                LinkEnum.LinkUpSword => new UpWoodSwordSprite(texture, location, swordType),
                LinkEnum.LinkDownSword => new DownWoodSwordSprite(texture, location, swordType),
                LinkEnum.LinkLeftSword => new LeftWoodSwordSprite(texture, location, swordType),
                LinkEnum.LinkRightSword => new RightWoodSwordSprite(texture, location, swordType),
                LinkEnum.LinkUpWalking => new UpWalkingLinkSprite(texture, location),
                LinkEnum.LinkDownWalking => new DownWalkingLinkSprite(texture, location),
                LinkEnum.LinkLeftWalking => new LeftWalkingLinkSprite(texture, location),
                LinkEnum.LinkRightWalking => new RightWalkingLinkSprite(texture, location),
                LinkEnum.LinkUpItem => new UpUseItemSprite(texture, location),
                LinkEnum.LinkDownItem => new DownUseItemSprite(texture, location),
                LinkEnum.LinkLeftItem => new LeftUseItemSprite(texture, location),
                LinkEnum.LinkRightItem => new RightUseItemSprite(texture, location),
                LinkEnum.LinkPickUpItem => new PickUpItemSprite(texture, location),
                _ => throw new ArgumentException("Invalid sprite! " + spriteType.ToString() + " Player sprite factory failed."),
            };
        }
    }
}
