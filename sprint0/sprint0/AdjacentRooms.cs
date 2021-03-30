using System;
using System.Collections.Generic;

namespace sprint0
{
    public static class AdjacentRooms
    {
        private static readonly Dictionary<int, Dictionary<Direction, int>> adjacentRooms = new Dictionary<int, Dictionary<Direction, int>>
            {
                { 1, new Dictionary<Direction, int> { { Direction.e, 2 } } },
                { 2, new Dictionary<Direction, int> { { Direction.w, 1 }, { Direction.s, 3 } } },
                { 3, new Dictionary<Direction, int> { { Direction.n, 2 }, { Direction.s, 6 } } },
                { 4, new Dictionary<Direction, int> { { Direction.e, 5 } } },
                { 5, new Dictionary<Direction, int> { { Direction.w, 4 }, { Direction.e, 6 }, { Direction.s, 11 } } },
                { 6, new Dictionary<Direction, int> { { Direction.n, 3 }, { Direction.s, 12 }, { Direction.e, 7 }, { Direction.w, 5 } } },
                { 7, new Dictionary<Direction, int> { { Direction.e, 10 }, { Direction.s, 13 }, { Direction.w, 6 } } },
                { 8, new Dictionary<Direction, int> { { Direction.e, 9 }, { Direction.s, 10 } } },
                { 9, new Dictionary<Direction, int> { { Direction.w, 8 } } },
                { 10, new Dictionary<Direction, int> { { Direction.n, 8 }, { Direction.w, 7 } } },
                { 11, new Dictionary<Direction, int> { { Direction.e, 12 }, { Direction.n, 5 } } },
                { 12, new Dictionary<Direction, int> { { Direction.e, 13 }, { Direction.n, 6 }, { Direction.w, 11 }, { Direction.s, 14 } } },
                { 13, new Dictionary<Direction, int> { { Direction.w, 12 }, { Direction.n, 7 } } },
                { 14, new Dictionary<Direction, int> { { Direction.n, 12 }, { Direction.s, 16 } } },
                { 15, new Dictionary<Direction, int> { { Direction.e, 16 } } },
                { 16, new Dictionary<Direction, int> { { Direction.w, 15 }, { Direction.e, 17 } } }, //TODO does south door go somewhere?
                { 17, new Dictionary<Direction, int> { { Direction.w, 16 } } },
                { 18, new Dictionary<Direction, int> { { Direction.e, 0 } } }
            };

        public static int GetAdjacentRoom(int currRoomIndex, Direction side)
        {
            return adjacentRooms[currRoomIndex][side];
        }
    }
}
