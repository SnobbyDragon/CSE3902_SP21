using System.Collections.Generic;
using Microsoft.Xna.Framework;

//Author: Stuti Shah
//Updated: 04/03/21 by shah.1440
namespace sprint0
{
    public class HUDItemMapping
    {
        protected readonly Dictionary<PlayerItems, Rectangle> itemMap, locationMapping;
        protected readonly List<PlayerItems> topRowItems;
        protected readonly Dictionary<PlayerItems, PlayerItems> itemToSecondaryItem;
        public Dictionary<PlayerItems, Rectangle> ItemMap { get => itemMap; }
        public Dictionary<PlayerItems, Rectangle> LocationMapping { get => locationMapping; }
        public List<PlayerItems> TopRowItems { get => topRowItems; }
        public Rectangle CurrentItem { get => currentItem; }
        protected readonly Rectangle none;
        private readonly int height = 16, smallWidth = 8, bigWidth = 16, yPosTop = 24, yPosMiddle = 48, yPosBottom = 64, currentItemX = 68, mapHeight = 88;
        private readonly Rectangle currentItem;
        protected int Width { get => 8; }
        protected int Height { get => 16; }
        protected int YPos { get => 137; }
        protected Rectangle source;

        public HUDItemMapping()
        {
            none = new Rectangle(0, 0, 0, 0);
            itemToSecondaryItem = new Dictionary<PlayerItems, PlayerItems>
            {
                {PlayerItems.Boomerang, PlayerItems.BoomerangType },
                {PlayerItems.MagicalBoomerang, PlayerItems.BoomerangType },
                {PlayerItems.Arrow, PlayerItems.ArrowType },
                {PlayerItems.SilverArrow, PlayerItems.ArrowType },
                {PlayerItems.RedCandle, PlayerItems.CandleType },
                {PlayerItems.BlueCandle, PlayerItems.CandleType },
                {PlayerItems.RedRing, PlayerItems.RingType },
                {PlayerItems.BlueRing, PlayerItems.RingType },
                {PlayerItems.BluePotion, PlayerItems.PotionType },
                {PlayerItems.RedPotion, PlayerItems.PotionType },
            };
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
                { PlayerItems.Letter, GetSource(686, YPos)},
                { PlayerItems.BluePotion, GetSource(695, YPos)},
                { PlayerItems.RedPotion, GetSource(704, YPos)},
                { PlayerItems.MagicalRod, GetSource(715, YPos)},
                { PlayerItems.BookOfMagic, GetSource(538, YPos+19)},
                { PlayerItems.RedRing, GetSource(549, YPos+19)},
                { PlayerItems.MagicalKey, GetSource(579, YPos+19)},
                { PlayerItems.PowerBracelet, GetSource(590, YPos+19)},
                { PlayerItems.Map, GetSource(601, YPos+19)},
                { PlayerItems.Compass, GetSourceCompass(614, YPos+19)},
                { PlayerItems.Raft, GetSourceRaftLadder(519, YPos+19)},
                { PlayerItems.StepLadder, GetSourceRaftLadder(560, YPos+19)},
                { PlayerItems.ItemSelectorRed, GetSourceRaftLadder(519, YPos)},
                { PlayerItems.ItemSelectorBlue, GetSourceRaftLadder(536, YPos)},
            };
            topRowItems = new List<PlayerItems> { PlayerItems.Raft, PlayerItems.BookOfMagic, PlayerItems.StepLadder, PlayerItems.MagicalKey, PlayerItems.PowerBracelet, PlayerItems.RedRing };
            locationMapping = new Dictionary<PlayerItems, Rectangle>
            {
                { PlayerItems.Raft, GetSource(129, yPosTop, bigWidth, height)},
                { PlayerItems.BookOfMagic, GetSource(152, yPosTop, smallWidth, height) },
                { PlayerItems.RedRing, GetSource(164, yPosTop, smallWidth, height) },
                { PlayerItems.StepLadder, GetSource(176, yPosTop, bigWidth, height) },
                { PlayerItems.MagicalKey, GetSource(196, yPosTop, smallWidth, height) },
                { PlayerItems.PowerBracelet, GetSource(208, yPosTop, smallWidth, height) },
                { PlayerItems.MagicalBoomerang, GetSource(132, yPosMiddle, smallWidth, height) },
                { PlayerItems.Boomerang, GetSource(132, yPosMiddle, smallWidth, height) },
                { PlayerItems.Bomb, GetSource(156, yPosMiddle, smallWidth, height) },
                { PlayerItems.Bow, GetSource(184, yPosMiddle, smallWidth, height) },
                { PlayerItems.Arrow, GetSource(176, yPosMiddle, smallWidth, height) },
                { PlayerItems.SilverArrow, GetSource(176, yPosMiddle, smallWidth, height) },
                { PlayerItems.RedCandle, GetSource(204, yPosMiddle, smallWidth, height) },
                { PlayerItems.BlueCandle, GetSource(204, yPosMiddle, smallWidth, height) },
                { PlayerItems.Flute, GetSource(132, yPosBottom, smallWidth, height) },
                { PlayerItems.Food, GetSource(156, yPosBottom, smallWidth, height) },
                { PlayerItems.RedPotion, GetSource(180, yPosBottom, smallWidth, height) },
                { PlayerItems.BluePotion, GetSource(180, yPosBottom, smallWidth, height) },
                { PlayerItems.MagicalRod, GetSource(204, yPosBottom, smallWidth, height) },
                { PlayerItems.Map, GetSource(48, yPosTop+mapHeight, smallWidth, height) },
                { PlayerItems.Compass, GetSource(44, yPosBottom+mapHeight, bigWidth-1, height) },
            };
            currentItem = GetSource(currentItemX, yPosMiddle, smallWidth, height);
        }
        private Rectangle GetSource(int xPos, int yPos) => new Rectangle(xPos, yPos, Width, Height);
        private Rectangle GetSourceCompass(int xPos, int yPos) => new Rectangle(xPos, yPos, Width + 3, Height);
        private Rectangle GetSourceRaftLadder(int xPos, int yPos) => new Rectangle(xPos, yPos, Width * 2, Height);
        private Rectangle GetSource(int xPos, int yPos, int width, int height)
            => new Rectangle((int)(xPos * Game1.Scale), (int)((yPos + Game1.HUDHeight) * Game1.Scale), (int)(width * Game1.Scale), (int)(height * Game1.Scale));
    }
}
