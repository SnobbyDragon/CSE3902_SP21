﻿using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
namespace sprint0
{
    public class PauseScreenMapping
    {
        protected enum RoomDirection
        {
            None = 0, Right = 1, Left = 2, LeftRight = 3,
            Down = 4, RightDown = 5, LeftDown = 6, LeftRightDown = 7,
            Up = 8, RightUp = 9, LeftUp = 10, LeftRightUp = 11, UpDown = 12, RightUpDown = 13, LeftUpDown = 14, LeftRightUpDown = 15, Empty = 16, Location = 17
        }
        protected readonly List<Rectangle> sources;
        private readonly Dictionary<int, int> rowMapping1, rowMapping2, rowMapping3, rowMapping4, rowMapping5, rowMapping6;
        protected readonly Dictionary<int, Rectangle> roomPos;
        protected readonly List<Dictionary<int, int>> fullMapping;
        private readonly int xOffset = 519, yOffset = 108, totalFrames = 16, height = 88;
        protected readonly int sideLength = 8, baseX = 136, baseY;
        public PauseScreenMapping()
        {
            sources = SpritesheetHelper.GetFramesH(xOffset, yOffset, sideLength, sideLength, totalFrames);
            sources.Add(new Rectangle(587, 91, sideLength * 2, sideLength * 2));
            sources.Add(new Rectangle(528, 126, sideLength, sideLength));
            baseY = height + Game1.HUDHeight + (sideLength * 2);
            roomPos = new Dictionary<int, Rectangle>();
            rowMapping1 = new Dictionary<int, int>
            {
                {18, (int)RoomDirection.None },
                {0, (int)RoomDirection.Right },
                {1, (int)RoomDirection.Right },
                {2, (int)RoomDirection.LeftDown },
            };
            rowMapping2 = new Dictionary<int, int>
            {
                {3, (int)RoomDirection.UpDown },
                {8, (int)RoomDirection.RightDown },
                {9, (int)RoomDirection.Left },
            };
            rowMapping3 = new Dictionary<int, int>
            {
                {4, (int)RoomDirection.Right },
                {5, (int)RoomDirection.LeftRightDown },
                {6, (int)RoomDirection.LeftRightUpDown },
                {7, (int)RoomDirection.LeftRightDown },
                {10, (int)RoomDirection.LeftUp },
            };
            rowMapping4 = new Dictionary<int, int>
            {
                {11, (int)RoomDirection.RightUp },
                {12, (int)RoomDirection.LeftRightUpDown },
                {13, (int)RoomDirection.LeftUp },
            };
            rowMapping5 = new Dictionary<int, int>
            {
                {14, (int)RoomDirection.UpDown },
            };
            rowMapping6 = new Dictionary<int, int>
            {
                {15, (int)RoomDirection.Right },
                {16, (int)RoomDirection.LeftRightUpDown },
                {17, (int)RoomDirection.Left },
            };
            fullMapping = new List<Dictionary<int, int>>
            {
                rowMapping1,
                rowMapping2,
                rowMapping3,
                rowMapping4,
                rowMapping5,
                rowMapping6,
            };
            AddMapping();
        }
        private void AddMapping()
        {
            AddToMapping(fullMapping[0], baseX, baseY);
            AddToMapping(fullMapping[1], baseX + 3 * sideLength, baseY + sideLength);
            AddToMapping(fullMapping[2], baseX + sideLength, baseY + 2 * sideLength);
            AddToMapping(fullMapping[3], baseX + 2 * sideLength, baseY + 3 * sideLength);
            AddToMapping(fullMapping[4], baseX + 3 * sideLength, baseY + 4 * sideLength);
            AddToMapping(fullMapping[5], baseX + 2 * sideLength, baseY + 5 * sideLength);
        }

        private void AddToMapping(Dictionary<int, int> mapping, int xStart, int yStart)
        {
            int x = xStart, y = yStart;
            foreach (KeyValuePair<int, int> roomMap in mapping)
            {
                roomPos.Add(roomMap.Key, new Rectangle((int)(x * Game1.Scale), (int)(y * Game1.Scale), (int)(sideLength * Game1.Scale), (int)(sideLength * Game1.Scale)));
                if (roomMap.Key == 3)
                    x += sideLength;
                x += sideLength;
            }
        }
    }
}
