﻿using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

//Author: Hannah Johnson and co
/*
 * Last updated: 3/25/21 by shah.1440
 */
namespace sprint0
{
    public enum ItemEnum
    {
        MagicalBoomerang, Boomerang, BlueRing, RedRing, BlueCandle, RedCandle,
        Food, Letter, Map, BluePotion, RedPotion, BlueRupee, Rupee,
        Clock, Bow, HeartContainer, TriforcePiece, Compass, Key, Fairy,
        Arrow, Bomb, PowerBracelet, BookOfMagic, Flute, Raft, Stepladder,
        MagicalKey, MagicalRod, MagicalSword, WhiteSword, WoodenSword, GanonTriforceAshes
    }
    public class ItemsSpriteFactory
    {
        private readonly Texture2D texture1;
        private readonly Texture2D texture2;
        private readonly Game1 game;

        public ItemsSpriteFactory(Game1 game)
        {
            this.game = game;
            texture1 = game.Content.Load<Texture2D>("Images/ItemsAndWeapons");
            texture2 = game.Content.Load<Texture2D>("Images/Bosses");
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
                "triforce piece" => new TriforcePiece(texture1, location, game),
                "compass" => new Compass(texture1, location),
                "key" => new Key(texture1, location),
                "fairy" => new Fairy(texture1, location, game),
                "arrow" => new ArrowItem(texture1, location),
                "bomb" => new BombItem(texture1, location),
                "power bracelet" => new PowerBracelet(texture1, location),
                "book of magic" => new BookOfMagic(texture1, location),
                "flute" => new Flute(texture1, location),
                "raft" => new Raft(texture1, location),
                "stepladder" => new StepLadder(texture1, location),
                "magical key" => new MagicalKey(texture1, location),
                "magical rod" => new MagicalRod(texture1, location),
                "magical sword" => new MagicalSword(texture1, location),
                "white sword" => new WhiteSword(texture1, location),
                "wooden sword" => new WoodenSword(texture1, location),
                "ganontriforceashes" => new GanonTriforceAshes(texture2, location, game),
                _ => throw new ArgumentException("Invalid sprite! " + spriteType + " Sprite factory failed."),
            };
        }

    }
}
