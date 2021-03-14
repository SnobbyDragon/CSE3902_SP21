using System;
namespace sprint0
{
    public enum Direction { n, s, e, w, ne, nw, se, sw };

    public static class DirectionMethods
    {
        public static Direction OppositeDirection(this Direction direction)
        {
            return direction switch
            {
                Direction.n => Direction.s,
                Direction.s => Direction.n,
                Direction.e => Direction.s,
                Direction.w => Direction.s,
                Direction.ne => Direction.sw,
                Direction.nw => Direction.se,
                Direction.se => Direction.nw,
                Direction.sw => Direction.ne,
                _ => throw new ArgumentException("Invalid direction! No opposite direction.")
            };
        }
    }
}
