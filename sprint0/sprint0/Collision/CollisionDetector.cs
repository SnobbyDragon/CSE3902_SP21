using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace sprint0
{
    public class CollisionDetector
    {
        public CollisionDetector() { }

        public Collision DetectCollision(ISprite one, Rectangle two)
            => DetectCollision(one.Location, two);

        public Collision DetectCollision(Rectangle one, ISprite two)
            => DetectCollision(one, two.Location);

        public Collision DetectCollision(ISprite one, ISprite two)
            => DetectCollision(one.Location, two.Location);

        public Collision DetectCollision(Rectangle one, Rectangle two)
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

        public Collision DetermineCollisionBottom(Rectangle intersection, Rectangle one)
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

        public Collision DetermineCollisionTop(Rectangle intersection, Rectangle one)
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

        public Collision DetermineCollisionRight(Rectangle intersection, Rectangle one)
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

        public Collision DetermineCollisionLeft(Rectangle intersection, Rectangle one)
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
