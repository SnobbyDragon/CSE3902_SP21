﻿using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

//Author: Hannah Johnson and co
/*
 * Last updated: 3/14/21 by shah.1440
 */
namespace sprint0
{
    public class WeaponsSpriteFactory
    {
        private readonly Texture2D texture2;

        public WeaponsSpriteFactory(Game1 game)
        {
            texture2 = game.Content.Load<Texture2D>("Images/Link");
        }
        /*
         * Note: if the lifespan is predetermined (for instance with "bomb", use 0)
         */

        public IWeapon MakeWeapon(string spriteType, Vector2 location, Direction dir, IPlayer player)
        {
            return spriteType switch
            {
                "bomb" => new Bomb(texture2, location, dir),
                "sword" => new Sword(location, dir, player),
                _ => throw new ArgumentException("Invalid sprite! Sprite factory failed."),
            };
        }
    }
}