using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace sprint0
{
    public class HUDMiniMapping
    {
        protected enum RoomPosition
        {
            Top = 0, Bottom = 1, Both = 2, Location = 3, LevelNum = 4
        }
        protected readonly Dictionary<int, Rectangle> roomPos;
        private readonly Dictionary<int, int> rowMapping1, rowMapping2, rowMapping3;
        protected readonly Dictionary<int, int> overlap;
        protected readonly List<Dictionary<int, int>> fullMapping;
        protected readonly List<Rectangle> source;
        private readonly int xOffset = 663, yOffset = 108,
            totalFrames = 3, startX = 24, startY = 24;
        protected int sideLength = 8;
        public HUDMiniMapping()
        {
            source = SpritesheetHelper.GetFramesH(xOffset, yOffset, sideLength, sideLength, totalFrames);
            source.Add(new Rectangle(528, 126, sideLength, sideLength));
            source.Add(new Rectangle(537, 117, sideLength, sideLength));
            roomPos = new Dictionary<int, Rectangle>();
            rowMapping1 = new Dictionary<int, int>
            {
                {18, (int)RoomPosition.Top},
                {0, (int)RoomPosition.Top },
                {1, (int)RoomPosition.Top },
                {2, (int)RoomPosition.Both },
                {8, (int)RoomPosition.Top },
                {9, (int)RoomPosition.Top },
            };
            rowMapping2 = new Dictionary<int, int>
            {
                {4, (int)RoomPosition.Top},
                {5, (int)RoomPosition.Both },
                {6, (int)RoomPosition.Both },
                {7, (int)RoomPosition.Both },
                {10, (int)RoomPosition.Top },
            };
            rowMapping3 = new Dictionary<int, int>
            {
                {14, (int)RoomPosition.Bottom},
                {15, (int)RoomPosition.Both },
                {17, (int)RoomPosition.Bottom },
            };
            overlap = new Dictionary<int, int>
            {
                {3, 2},
                {11, 5},
                {12, 6},
                {13, 7},
                {16, 14},
            };
            fullMapping = new List<Dictionary<int, int>>
            {
                rowMapping1,
                rowMapping2,
                rowMapping3,
            };
            AddMapping();
        }
        private void AddMapping()
        {
            AddToMapping(fullMapping[0], startX - sideLength, startY);
            AddToMapping(fullMapping[1], startX, startY + sideLength);
            AddToMapping(fullMapping[2], startX + sideLength, startY + sideLength * 2);
        }

        private void AddToMapping(Dictionary<int, int> mapping, int xStart, int yStart)
        {
            int x = xStart, y = yStart;
            foreach (KeyValuePair<int, int> roomMap in mapping)
            {
                roomPos.Add(roomMap.Key, new Rectangle((int)(x * Game1.Scale), (int)(y * Game1.Scale),
                    (int)(sideLength * Game1.Scale), (int)(sideLength * Game1.Scale)));
                if (roomMap.Key == 2)
                    x += sideLength;
                x += sideLength;
            }
        }
    }
}
