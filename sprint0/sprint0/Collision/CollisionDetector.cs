using System;
using Microsoft.Xna.Framework;

namespace sprint0
{
    public static class CollisionDetector
    {
        public static Collision DetectCollision(ISprite one, Rectangle two) => DetectCollision(one.Location, two);
        public static Collision DetectCollision(Rectangle one, ISprite two) => DetectCollision(one, two.Location);
        public static Collision DetectCollision(ISprite one, ISprite two) => DetectCollision(one.Location, two.Location);
        public static Collision DetectCollision(Rectangle one, Rectangle two)
        {
            Rectangle intersection = Rectangle.Intersect(one, two);
            if (intersection.IsEmpty)
                return Collision.None;
            if (intersection.Bottom == one.Bottom)
                return DetermineCollisionBottom(intersection, one);
            else if (intersection.Top == one.Top)
                return DetermineCollisionTop(intersection, one);
            else if (intersection.Right == one.Right)
                return DetermineCollisionRight(intersection, one);
            else if (intersection.Left == one.Left)
                return DetermineCollisionLeft(intersection, one);
            else
                return DetermineCollisionBottom(intersection, one);
        }

        public static Collision DetermineCollisionBottom(Rectangle intersection, Rectangle one)
        {
            if (intersection.Left > one.Left)
            {
                if (intersection.Height > intersection.Width)
                    return Collision.Right;
                else
                    return Collision.Bottom;
            }
            else
            {
                if (intersection.Height > intersection.Width)
                    return Collision.Left;
                else
                    return Collision.Bottom;
            }
        }

        public static Collision DetermineCollisionTop(Rectangle intersection, Rectangle one)
        {
            if (intersection.Left > one.Left)
            {
                if (intersection.Height > intersection.Width)
                    return Collision.Right;
                else
                    return Collision.Top;
            }
            else
            {
                if (intersection.Height > intersection.Width)
                    return Collision.Left;
                else
                    return Collision.Top;
            }
        }

        public static Collision DetermineCollisionRight(Rectangle intersection, Rectangle one)
        {
            if (intersection.Top > one.Top)
            {
                if (intersection.Height > intersection.Width)
                    return Collision.Right;
                else
                    return Collision.Bottom;
            }
            else
            {
                if (intersection.Height > intersection.Width)
                    return Collision.Right;
                else
                    return Collision.Top;
            }
        }

        public static Collision DetermineCollisionLeft(Rectangle intersection, Rectangle one)
        {
            if (intersection.Top > one.Top)
            {
                if (intersection.Height > intersection.Width)
                    return Collision.Left;
                else
                    return Collision.Bottom;
            }
            else
            {
                if (intersection.Height > intersection.Width)
                    return Collision.Left;
                else
                    return Collision.Top;
            }
        }
    }
}
