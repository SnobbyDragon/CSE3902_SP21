﻿using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

//Author: Hannah Johnson and co
namespace sprint0
{
    public class NpcsSpriteFactory
    {
        private readonly Texture2D texture;

        public NpcsSpriteFactory(Game1 game)
            => texture = game.Content.Load<Texture2D>("Images/NPCs");

        public INpc MakeSprite(NPCEnum spriteType, Vector2 location)
        {
            return spriteType switch
            {
                NPCEnum.OldMan1 => new OldPerson(texture, location, spriteType),
                NPCEnum.OldMan2 => new OldPerson(texture, location, spriteType),
                NPCEnum.OldWoman => new OldPerson(texture, location, spriteType),
                NPCEnum.GreenMerchant => new Merchant(texture, location, Color.Green),
                NPCEnum.WhiteMerchant => new Merchant(texture, location, Color.White),
                NPCEnum.RedMerchant => new Merchant(texture, location, Color.Red),
                NPCEnum.Flame => new Flame(texture, location),
                _ => throw new ArgumentException("Invalid sprite! " + spriteType.ToString() + " Sprite factory failed."),
            };
        }
    }
}
