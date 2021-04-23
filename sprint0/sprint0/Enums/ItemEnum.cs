using System;
namespace sprint0
{
    public enum ItemEnum
    {
        MagicalBoomerang, Boomerang, BlueRing, RedRing, BlueCandle, RedCandle,
        Food, Letter, Map, BluePotion, RedPotion, BlueRupee, Rupee,
        Clock, Bow, HeartContainer, TriforcePiece, Compass, Key, Fairy,
        Arrow, Bomb, PowerBracelet, BookOfMagic, Flute, Raft, Stepladder,
        MagicalKey, MagicalRod, MagicalSword, WhiteSword, WoodenSword, GanonTriforceAshes, None, FairyDistract
    }

    public static class ItemEnumExtension
    {
        public static ItemEnum ToItemEnum(this string item)
             => (ItemEnum)Enum.Parse(typeof(ItemEnum), item, true);

        public static string GetName(this ItemEnum item)
            => Enum.GetName(item.GetType(), item);

        public static ItemEnum ToItemEnum(this IItem item)
        {
            if (item is BlueBoomerangItem) return ItemEnum.MagicalBoomerang;
            if (item is BoomerangItem) return ItemEnum.Boomerang;
            if (item is Ring) return ItemEnum.RedRing;
            if (item is Candle) return ItemEnum.RedCandle;
            if (item is Meat) return ItemEnum.Food;
            if (item is BlueMap) return ItemEnum.Letter;
            if (item is Potion) return ItemEnum.RedPotion;
            if (item is ArrowItem) return ItemEnum.Arrow;
            if (item is BombItem) return ItemEnum.Bomb;
            return item.GetType().Name.ToItemEnum();
        }
    }
}
