using System;
using Microsoft.Xna.Framework;

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
                Direction.e => Direction.w,
                Direction.w => Direction.e,
                Direction.ne => Direction.sw,
                Direction.nw => Direction.se,
                Direction.se => Direction.nw,
                Direction.sw => Direction.ne,
                _ => throw new ArgumentException("Invalid direction! No opposite direction.")
            };
        }

        public static Vector2 ToVector2(this Direction direction)
        {
            return direction switch
            {
                Direction.n => new Vector2(0, -1),
                Direction.s => new Vector2(0, 1),
                Direction.e => new Vector2(1, 0),
                Direction.w => new Vector2(-1, 0),
                Direction.ne => ToVector2(Direction.n) + ToVector2(Direction.e),
                Direction.nw => ToVector2(Direction.n) + ToVector2(Direction.w),
                Direction.se => ToVector2(Direction.s) + ToVector2(Direction.e),
                Direction.sw => ToVector2(Direction.s) + ToVector2(Direction.w),
                _ => throw new ArgumentException("Invalid direction! No opposite direction.")
            };
        }
    }
}
