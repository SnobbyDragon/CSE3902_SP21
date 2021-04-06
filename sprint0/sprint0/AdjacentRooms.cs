using System;
using System.Collections.Generic;

namespace sprint0
{
    public static class AdjacentRooms
    {
        private static readonly Dictionary<int, Dictionary<Direction, int>> adjacentRooms = new Dictionary<int, Dictionary<Direction, int>>
            {
                { 1, new Dictionary<Direction, int> { { Direction.East, 2 }, { Direction.West, 18 } } },
                { 2, new Dictionary<Direction, int> { { Direction.West, 1 }, { Direction.South, 3 } } },
                { 3, new Dictionary<Direction, int> { { Direction.North, 2 }, { Direction.South, 6 } } },
                { 4, new Dictionary<Direction, int> { { Direction.East, 5 } } },
                { 5, new Dictionary<Direction, int> { { Direction.West, 4 }, { Direction.East, 6 }, { Direction.South, 11 } } },
                { 6, new Dictionary<Direction, int> { { Direction.North, 3 }, { Direction.South, 12 }, { Direction.East, 7 }, { Direction.West, 5 } } },
                { 7, new Dictionary<Direction, int> { { Direction.East, 10 }, { Direction.South, 13 }, { Direction.West, 6 } } },
                { 8, new Dictionary<Direction, int> { { Direction.East, 9 }, { Direction.South, 10 } } },
                { 9, new Dictionary<Direction, int> { { Direction.West, 8 } } },
                { 10, new Dictionary<Direction, int> { { Direction.North, 8 }, { Direction.West, 7 } } },
                { 11, new Dictionary<Direction, int> { { Direction.East, 12 }, { Direction.North, 5 } } },
                { 12, new Dictionary<Direction, int> { { Direction.East, 13 }, { Direction.North, 6 }, { Direction.West, 11 }, { Direction.South, 14 } } },
                { 13, new Dictionary<Direction, int> { { Direction.West, 12 }, { Direction.North, 7 } } },
                { 14, new Dictionary<Direction, int> { { Direction.North, 12 }, { Direction.South, 16 } } },
                { 15, new Dictionary<Direction, int> { { Direction.East, 16 } } },
                { 16, new Dictionary<Direction, int> { { Direction.West, 15 }, { Direction.East, 17 }, { Direction.North, 14 } } },
                { 17, new Dictionary<Direction, int> { { Direction.West, 16 } } },
                { 18, new Dictionary<Direction, int> { { Direction.East, 1 } } }
            };

        public static int GetAdjacentRoom(int currRoomIndex, Direction side)
        {
            return adjacentRooms[currRoomIndex][side];
        }

        public static Dictionary<Direction, int> ListOfAdjacentRooms(int roomIndex) {
            return adjacentRooms[roomIndex];
        }
    }
}
