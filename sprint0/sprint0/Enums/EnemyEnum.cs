using System;
using Microsoft.Xna.Framework;

namespace sprint0
{
    public enum EnemyEnum
    {
        Wallmaster, TealGel, BlueGel, GreenGel, GoldGel, LimeGel, BrownGel, GrayGel, WhiteGel,
        GreenZol, GoldZol, LimeZol, BrownZol, GrayZol, WhiteZol,
        Snake, RedGoriya, BlueGoriya, RedKeese, BlueKeese, Stalfos, Trap, Trapparatus,
        Aquamentus, Patra, Manhandla, Gleeok, Ganon, OrangeGohma, BlueGohma, Dodongo, Digdogger,
        Gel, Goriya, Keese, Zol, Gohma, Owl, FairyEnemy
    }

    public static class EnemyEnumExtension
    {
        public static EnemyEnum ToEnemyEnum(this string enemy)
             => (EnemyEnum)Enum.Parse(typeof(EnemyEnum), enemy, true);

        public static string GetName(this EnemyEnum enemy)
            => Enum.GetName(enemy.GetType(), enemy);

        public static EnemyEnum ToEnemyEnum(this IEnemy enemy)
        {
            if (enemy is Gohma gohma) return GetGohmaEnum(gohma);
            if (enemy is Keese keese) return GetKeeseEnum(keese);
            if (enemy is Zol zol) return GetZolEnum(zol);
            if (enemy is Gel gel) return GetGelEnum(gel);
            if (enemy is Goriya goriya) return GetGoriyaEnum(goriya);
            return enemy.GetType().Name.ToEnemyEnum();
        }

        private static EnemyEnum GetGohmaEnum(Gohma gohma)
        {
            if (gohma.Color == Color.Orange) return EnemyEnum.OrangeGohma;
            if (gohma.Color == Color.Blue) return EnemyEnum.BlueGohma;
            throw new ArgumentException("Not a valid gohma!");
        }

        private static EnemyEnum GetKeeseEnum(Keese keese)
        {
            if (keese.Color == Color.Blue) return EnemyEnum.BlueKeese;
            if (keese.Color == Color.Red) return EnemyEnum.RedKeese;
            throw new ArgumentException("Not a valid keese!");
        }

        private static EnemyEnum GetZolEnum(Zol zol)
        {
            if (zol.Color == Color.Green) return EnemyEnum.GreenZol;
            if (zol.Color == Color.Gold) return EnemyEnum.GoldZol;
            if (zol.Color == Color.Lime) return EnemyEnum.LimeZol;
            if (zol.Color == Color.Brown) return EnemyEnum.BrownZol;
            if (zol.Color == Color.Gray) return EnemyEnum.GrayZol;
            if (zol.Color == Color.White) return EnemyEnum.WhiteZol;
            throw new ArgumentException("Not a valid zol!");
        }

        private static EnemyEnum GetGelEnum(Gel gel)
        {
            if (gel.Color == Color.Teal) return EnemyEnum.TealGel;
            if (gel.Color == Color.Blue) return EnemyEnum.BlueGel;
            if (gel.Color == Color.Green) return EnemyEnum.GreenGel;
            if (gel.Color == Color.Gold) return EnemyEnum.GoldGel;
            if (gel.Color == Color.Lime) return EnemyEnum.LimeGel;
            if (gel.Color == Color.Brown) return EnemyEnum.BrownGel;
            if (gel.Color == Color.Gray) return EnemyEnum.GrayGel;
            if (gel.Color == Color.White) return EnemyEnum.WhiteGel;
            throw new ArgumentException("Not a valid gel!");
        }

        private static EnemyEnum GetGoriyaEnum(Goriya goriya)
        {
            if (goriya.Color == Color.Red) return EnemyEnum.RedGoriya;
            if (goriya.Color == Color.Blue) return EnemyEnum.BlueGoriya;
            throw new ArgumentException("Not a valid goriya!");
        }
    }
}
