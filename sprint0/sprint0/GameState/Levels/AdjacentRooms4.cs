using System;
using System.Collections.Generic;

namespace sprint0
{
    public static class AdjacentRooms4
    {
        private static readonly Dictionary<int, Dictionary<Direction, int>> adjacentRooms = new Dictionary<int, Dictionary<Direction, int>>
            {
                { 0, new Dictionary<Direction, int> { { Direction.South, 2 }, { Direction.East, 1 } } },
                { 1, new Dictionary<Direction, int> { { Direction.West, 0 }, { Direction.South, 3 } } },
                { 2, new Dictionary<Direction, int> { { Direction.North, 0 }, { Direction.East, 3 } } },
                { 3, new Dictionary<Direction, int> { { Direction.East, 4 }, { Direction.West, 2 }, { Direction.North, 1 } } },
                { 4, new Dictionary<Direction, int> { { Direction.West, 3}, { Direction.South, 9 }, { Direction.East, 5 } } },
                { 5, new Dictionary<Direction, int> { { Direction.North, 8 }, { Direction.East, 4 }, { Direction.West, 6 } } },
                { 6, new Dictionary<Direction, int> { { Direction.East, 5 }, { Direction.North, 7 } } },
                { 7, new Dictionary<Direction, int> { { Direction.East, 8 }, { Direction.South, 6 } } },
                { 8, new Dictionary<Direction, int> { { Direction.East, 7 }, { Direction.South, 5 } } },
                { 9, new Dictionary<Direction, int> { { Direction.North, 4}, { Direction.South, 10 } } },
                { 10, new Dictionary<Direction, int> { { Direction.North, 9 }, { Direction.West, 11 } } },
                { 11, new Dictionary<Direction, int> { { Direction.East, 10 }, { Direction.West, 12 } } },
                { 12, new Dictionary<Direction, int> { { Direction.East, 11 }, { Direction.West, 13 } } },
                { 13, new Dictionary<Direction, int> { { Direction.East, 12 } } },
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
