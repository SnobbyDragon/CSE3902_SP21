using System;
using Microsoft.Xna.Framework;

namespace sprint0
{
    public enum NPCEnum
    {
        OldMan1, OldMan2, OldWoman, GreenMerchant, WhiteMerchant, RedMerchant, Flame
    }

    public static class NPCEnumExtension
    {
        public static NPCEnum ToNPCEnum(this string npc)
            => (NPCEnum)Enum.Parse(typeof(NPCEnum), npc, true);

        public static string GetName(this NPCEnum npc)
            => Enum.GetName(npc.GetType(), npc);

        public static NPCEnum ToNPCEnum(this INpc npc)
        {
            if (npc is OldPerson oldPerson) return oldPerson.Type;
            if (npc is Merchant merchant) return GetMerchantEnum(merchant);
            if (npc is Flame) return NPCEnum.Flame;
            throw new ArgumentException("Not a valid npc!");
        }

        private static NPCEnum GetMerchantEnum(Merchant merchant)
        {
            if (merchant.Type == Color.Green) return NPCEnum.GreenMerchant;
            if (merchant.Type == Color.White) return NPCEnum.WhiteMerchant;
            if (merchant.Type == Color.Red) return NPCEnum.RedMerchant;
            throw new ArgumentException("Not a valid merchant!");
        }
    }
}
