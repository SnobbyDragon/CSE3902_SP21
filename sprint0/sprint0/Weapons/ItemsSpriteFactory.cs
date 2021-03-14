﻿using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

//Author: Hannah Johnson and co
/*
 * Last updated: 3/14/21 by shah.1440
 */
namespace sprint0
{
    public class ItemsSpriteFactory
    {
        private readonly Texture2D texture1;

        public ItemsSpriteFactory(Game1 game)
        {
            texture1 = game.Content.Load<Texture2D>("Images/ItemsAndWeapons");
        }

        public IItem MakeItem(string spriteType, Vector2 location)
        {
            return spriteType switch
            {
                "blue boomerang" => new BlueBoomerangItem(texture1, location),
                "boomerang" => new BoomerangItem(texture1, location),
                "blue ring" => new BlueRing(texture1, location),
                "ring" => new Ring(texture1, location),
                "blue candle" => new BlueCandle(texture1, location),
                "candle" => new Candle(texture1, location),
                "meat" => new Meat(texture1, location),
                "blue map" => new BlueMap(texture1, location),
                "map" => new Map(texture1, location),
                "blue potion" => new BluePotion(texture1, location),
                "potion" => new Potion(texture1, location),
                "blue rupee" => new BlueRupee(texture1, location),
                "rupee" => new Rupee(texture1, location),
                "clock" => new Clock(texture1, location),
                "bow" => new Bow(texture1, location),
                "heart container" => new HeartContainer(texture1, location),
                "gold triforce piece" => new TriforcePiece(texture1, location, "gold"),
                "blue triforce piece" => new TriforcePiece(texture1, location, "blue"),
                "compass" => new Compass(texture1, location),
                "key" => new Key(texture1, location),
                "fairy" => new Fairy(texture1, location),
                _ => throw new ArgumentException("Invalid sprite! " + spriteType + " Sprite factory failed."),
            };
        }

    }
}
