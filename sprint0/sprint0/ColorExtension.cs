using System;
using Microsoft.Xna.Framework;

namespace sprint0
{
    public static class ColorExtension
    {
        private static readonly int knownColorMin = 28, knownColorMax = 167;

        public static string GetName(this Color color)
        {
            for (int i = knownColorMin; i < knownColorMax; i++)
            {
                var knownColor = (System.Drawing.KnownColor)i;
                var syscolor = System.Drawing.Color.FromKnownColor(knownColor);
                if (syscolor.A == color.A && syscolor.R == color.R && syscolor.G == color.G && syscolor.B == color.B)
                    return knownColor.ToString().ToLower();
            }
            throw new ArgumentException("Invalid color " + color + "! Cannot get name as string.");
        }
    }
}
