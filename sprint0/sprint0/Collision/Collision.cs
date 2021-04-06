using System;
namespace sprint0
{
    public enum Collision { Left, Right, Top, Bottom, None };

    public static class CollisionMethods
    {
        public static Direction ToDirection(this Collision collision)
        {
            return collision switch
            {
                Collision.Left => Direction.West,
                Collision.Right => Direction.East,
                Collision.Top => Direction.North,
                Collision.Bottom => Direction.South,
                _ => throw new ArgumentException("Invalid collision! Has no corresponding direction!")
            };
        }
    }
}
