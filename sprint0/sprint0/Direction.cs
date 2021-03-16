using System;
using System.Collections.Generic;
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

        /*
         * Gets adjacent directions of the opposite type (cardinal / ordinal).
         */
        public static List<Direction> AdjacentDirectionsDiffType(this Direction direction)
        {
            return direction switch
            {
                Direction.n => new List<Direction> { Direction.nw, Direction.ne },
                Direction.s => new List<Direction> { Direction.sw, Direction.se },
                Direction.e => new List<Direction> { Direction.ne, Direction.se },
                Direction.w => new List<Direction> { Direction.nw, Direction.sw },
                Direction.ne => new List<Direction> { Direction.n, Direction.e },
                Direction.nw => new List<Direction> { Direction.n, Direction.w },
                Direction.se => new List<Direction> { Direction.e, Direction.s },
                Direction.sw => new List<Direction> { Direction.w, Direction.s },
                _ => throw new ArgumentException("Invalid direction! No adjacent directions with diff type (cardinal / ordinal).")
            };
        }

        /*
         * Gets adjacent directions of the same type (cardinal / ordinal)
         */
        public static List<Direction> AdjacentDirectionsSameType(this Direction direction)
        {
            return direction switch
            {
                Direction.n => new List<Direction> { Direction.w, Direction.e },
                Direction.s => new List<Direction> { Direction.w, Direction.e },
                Direction.e => new List<Direction> { Direction.n, Direction.s },
                Direction.w => new List<Direction> { Direction.n, Direction.s },
                Direction.ne => new List<Direction> { Direction.nw, Direction.se },
                Direction.nw => new List<Direction> { Direction.ne, Direction.sw },
                Direction.se => new List<Direction> { Direction.ne, Direction.sw },
                Direction.sw => new List<Direction> { Direction.nw, Direction.se },
                _ => throw new ArgumentException("Invalid direction! No adjacent directions with same type (cardinal / ordinal).")
            };
        }

        public static Direction ApproxDirection(this Vector2 v)
        {
            Direction closestApprox = Direction.n;
            foreach (Direction direction in Enum.GetValues(typeof(Direction)))
            {
                if ((direction.ToVector2() - v).LengthSquared() < (closestApprox.ToVector2() - v).LengthSquared())
                    closestApprox = direction;
            }
            return closestApprox;
        }

        public static float ToRadians(this Direction direction)
        {
            double rad = direction switch
            {
                Direction.n => Math.PI / 2,
                Direction.s => -Math.PI / 2,
                Direction.e => 0,
                Direction.w => Math.PI,
                Direction.ne => Math.PI / 4,
                Direction.nw => Math.PI * 3 / 4,
                Direction.se => -Math.PI / 4,
                Direction.sw => -Math.PI * 3 / 4,
                _ => throw new ArgumentException("Invalid direction! Cannot convert to radians.")
            };
            return (float)rad;
        }
    }
}
