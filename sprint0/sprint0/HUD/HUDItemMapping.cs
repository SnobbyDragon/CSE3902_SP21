using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

//Author: Stuti Shah
//Updated: 03/25/21 by shah.1440
namespace sprint0
{
    public class HUDItemMapping
    {
        protected readonly Dictionary<PlayerItems, Rectangle> itemMap;
        public Dictionary<PlayerItems, Rectangle> ItemMap { get => itemMap; }
        protected int Width { get => 8; }
        protected int Height { get => 16; }
        protected int YPos { get => 137; }
        protected Rectangle source;
        public HUDItemMapping()
        {
            itemMap = new Dictionary<PlayerItems, Rectangle>
            {
                { PlayerItems.Sword, GetSource(555, YPos)},
                { PlayerItems.WhiteSword, GetSource(564, YPos)},
                { PlayerItems.MagicalSword, GetSource(573, YPos)},
                { PlayerItems.Boomerang, GetSource(584, YPos)},
                { PlayerItems.MagicalBoomerang, GetSource(593, YPos)},
                { PlayerItems.Bomb, GetSource(604, YPos)},
                { PlayerItems.Arrow, GetSource(615, YPos)},
                { PlayerItems.SilverArrow, GetSource(624, YPos)},
                { PlayerItems.Bow, GetSource(633, YPos)},
                { PlayerItems.BlueCandle, GetSource(644, YPos)},
                { PlayerItems.RedCandle, GetSource(653, YPos)},
                { PlayerItems.Flute, GetSource(664, YPos)},
                { PlayerItems.Food, GetSource(675, YPos)},
                { PlayerItems.Map, GetSource(686, YPos)},
                { PlayerItems.BluePotion, GetSource(695, YPos)},
                { PlayerItems.RedPotion, GetSource(704, YPos)},
                { PlayerItems.MagicalRod, GetSource(715, YPos)},
                { PlayerItems.BookOfMagic, GetSource(538, YPos+19)},
                { PlayerItems.RedRing, GetSource(549, YPos+19)},
                { PlayerItems.MagicalKey, GetSource(579, YPos+19)},
                { PlayerItems.PowerBracelet, GetSource(590, YPos+19)},
                { PlayerItems.Letter, GetSource(601, YPos+19)},
                { PlayerItems.Compass, GetSourceCompass(614, YPos+19)},
                { PlayerItems.Raft, GetSourceRaftLadder(520, YPos+19)},
                { PlayerItems.StepLadder, GetSourceRaftLadder(560, YPos+19)},
            };
        }

        private Rectangle GetSource(int xPos, int yPos)
        {
            source = new Rectangle(xPos, yPos, Width, Height);
            return source;
        }
        private Rectangle GetSourceCompass(int xPos, int yPos)
        {
            source = new Rectangle(xPos, yPos, Width + 3, Height);
            return source;
        }
        private Rectangle GetSourceRaftLadder(int xPos, int yPos)
        {
            source = new Rectangle(xPos, yPos, Width * 2, Height);
            return source;
        }
    }
}
