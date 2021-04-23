using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

//Author: Hannah Johnson and co
/*
 * Last updated: 04/04/21 by shah.1440
 */
namespace sprint0
{
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

        public IItem MakeItem(ItemEnum spriteType, Vector2 location)
        {
            return spriteType switch
            {
                ItemEnum.MagicalBoomerang => new BlueBoomerangItem(texture1, location),
                ItemEnum.Boomerang => new BoomerangItem(texture1, location),
                ItemEnum.BlueRing => new BlueRing(texture1, location),
                ItemEnum.RedRing => new Ring(texture1, location),
                ItemEnum.BlueCandle => new BlueCandle(texture1, location),
                ItemEnum.RedCandle => new Candle(texture1, location),
                ItemEnum.Food => new Meat(texture1, location),
                ItemEnum.Letter => new BlueMap(texture1, location),
                ItemEnum.Map => new Map(texture1, location),
                ItemEnum.BluePotion => new BluePotion(texture1, location),
                ItemEnum.RedPotion => new Potion(texture1, location),
                ItemEnum.BlueRupee => new BlueRupee(texture1, location),
                ItemEnum.Rupee => new Rupee(texture1, location),
                ItemEnum.Clock => new Clock(texture1, location),
                ItemEnum.Bow => new Bow(texture1, location),
                ItemEnum.HeartContainer => new HeartContainer(texture1, location),
                ItemEnum.TriforcePiece => new TriforcePiece(texture1, location, game),
                ItemEnum.Compass => new Compass(texture1, location),
                ItemEnum.Key => new Key(texture1, location),
                ItemEnum.Fairy => new Fairy(texture1, location, game),
                ItemEnum.FairyDistract => new FairyDistract(texture1, location, game),
                ItemEnum.Arrow => new ArrowItem(texture1, location),
                ItemEnum.Bomb => new BombItem(texture1, location),
                ItemEnum.PowerBracelet => new PowerBracelet(texture1, location),
                ItemEnum.BookOfMagic => new BookOfMagic(texture1, location),
                ItemEnum.Flute => new Flute(texture1, location),
                ItemEnum.Raft => new Raft(texture1, location),
                ItemEnum.Stepladder => new StepLadder(texture1, location),
                ItemEnum.MagicalKey => new MagicalKey(texture1, location),
                ItemEnum.MagicalRod => new MagicalRod(texture1, location),
                ItemEnum.MagicalSword => new MagicalSword(texture1, location),
                ItemEnum.WhiteSword => new WhiteSword(texture1, location),
                ItemEnum.WoodenSword => new WoodenSword(texture1, location),
                ItemEnum.GanonTriforceAshes => new GanonTriforceAshes(texture2, location, game),
                _ => throw new ArgumentException("Invalid sprite! " + spriteType.ToString() + " Sprite factory failed."),
            };
        }

    }
}
