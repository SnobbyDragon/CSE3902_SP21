using System;
using System.Collections.Generic;

namespace sprint0
{
    public static class AdjacentRooms2
    {
        private static readonly Dictionary<int, Dictionary<Direction, int>> adjacentRooms = new Dictionary<int, Dictionary<Direction, int>>
            {
                { 0, new Dictionary<Direction, int> { { Direction.East, 1 } } },
                { 1, new Dictionary<Direction, int> { { Direction.West, 0 }, { Direction.East, 2 } } },
                { 2, new Dictionary<Direction, int> { { Direction.West, 1 }, { Direction.East, 3 } } },
                { 3, new Dictionary<Direction, int> { { Direction.West, 2 }, { Direction.East, 4 } } },
                { 4, new Dictionary<Direction, int> { { Direction.West, 3 }, { Direction.East, 5 } } },
                { 5, new Dictionary<Direction, int> { { Direction.West, 4 }} }
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
