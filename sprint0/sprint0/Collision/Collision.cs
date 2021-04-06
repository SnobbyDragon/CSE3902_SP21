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
                Collision.Left => Direction.w,
                Collision.Right => Direction.e,
                Collision.Top => Direction.n,
                Collision.Bottom => Direction.s,
                _ => throw new ArgumentException("Invalid collision! Has no corresponding direction!")
            };
        }
    }
}
