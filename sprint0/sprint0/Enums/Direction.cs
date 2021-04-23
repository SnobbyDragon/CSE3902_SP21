using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace sprint0
{
    public enum Direction { North, South, East, West, NorthEast, NorthWest, SouthEast, SouthWest };

    public static class DirectionExtension
    {
        public static Direction ToDirection(this string dir)
            => (Direction)Enum.Parse(typeof(Direction), dir, true);

        public static Direction OppositeDirection(this Direction direction)
        {
            return direction switch
            {
                Direction.North => Direction.South,
                Direction.South => Direction.North,
                Direction.East => Direction.West,
                Direction.West => Direction.East,
                Direction.NorthEast => Direction.SouthWest,
                Direction.NorthWest => Direction.SouthEast,
                Direction.SouthEast => Direction.NorthWest,
                Direction.SouthWest => Direction.NorthEast,
                _ => throw new ArgumentException("Invalid direction! No opposite direction.")
            };
        }
        public static Vector2 ToVector2(this Direction direction)
        {
            return direction switch
            {
                Direction.North => new Vector2(0, -1),
                Direction.South => new Vector2(0, 1),
                Direction.East => new Vector2(1, 0),
                Direction.West => new Vector2(-1, 0),
                Direction.NorthEast => ToVector2(Direction.North) + ToVector2(Direction.East),
                Direction.NorthWest => ToVector2(Direction.North) + ToVector2(Direction.West),
                Direction.SouthEast => ToVector2(Direction.South) + ToVector2(Direction.East),
                Direction.SouthWest => ToVector2(Direction.South) + ToVector2(Direction.West),
                _ => throw new ArgumentException("Invalid direction! No opposite direction.")
            };
        }
        public static List<Direction> AdjacentDirectionsDiffType(this Direction direction)
        {
            return direction switch
            {
                Direction.North => new List<Direction> { Direction.NorthWest, Direction.NorthEast },
                Direction.South => new List<Direction> { Direction.SouthWest, Direction.SouthEast },
                Direction.East => new List<Direction> { Direction.NorthEast, Direction.SouthEast },
                Direction.West => new List<Direction> { Direction.NorthWest, Direction.SouthWest },
                Direction.NorthEast => new List<Direction> { Direction.North, Direction.East },
                Direction.NorthWest => new List<Direction> { Direction.North, Direction.West },
                Direction.SouthEast => new List<Direction> { Direction.East, Direction.South },
                Direction.SouthWest => new List<Direction> { Direction.West, Direction.South },
                _ => throw new ArgumentException("Invalid direction! No adjacent directions with diff type (cardinal / ordinal).")
            };
        }
        public static List<Direction> AdjacentDirectionsSameType(this Direction direction)
        {
            return direction switch
            {
                Direction.North => new List<Direction> { Direction.West, Direction.East },
                Direction.South => new List<Direction> { Direction.West, Direction.East },
                Direction.East => new List<Direction> { Direction.North, Direction.South },
                Direction.West => new List<Direction> { Direction.North, Direction.South },
                Direction.NorthEast => new List<Direction> { Direction.NorthWest, Direction.SouthEast },
                Direction.NorthWest => new List<Direction> { Direction.NorthEast, Direction.SouthWest },
                Direction.SouthEast => new List<Direction> { Direction.NorthEast, Direction.SouthWest },
                Direction.SouthWest => new List<Direction> { Direction.NorthWest, Direction.SouthEast },
                _ => throw new ArgumentException("Invalid direction! No adjacent directions with same type (cardinal / ordinal).")
            };
        }
        public static Direction ApproxDirection(this Vector2 v)
        {
            Direction closestApprox = Direction.North;
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
                Direction.North => Math.PI / 2,
                Direction.South => -Math.PI / 2,
                Direction.East => 0,
                Direction.West => Math.PI,
                Direction.NorthEast => Math.PI / 4,
                Direction.NorthWest => Math.PI * 3 / 4,
                Direction.SouthEast => -Math.PI / 4,
                Direction.SouthWest => -Math.PI * 3 / 4,
                _ => throw new ArgumentException("Invalid direction! Cannot convert to radians.")
            };
            return (float)rad;
        }
    }
}
