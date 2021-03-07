using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace sprint0
{
    public class CollisionDetector
    {

        public CollisionDetector()
        {
        }

        // overload with different parameters
        public Collision DetectCollision(ISprite one, Rectangle two)
        {
            return DetectCollision(one.Location, two);
        }

        // overload with different parameters
        public Collision DetectCollision(Rectangle one, ISprite two)
        {
            return DetectCollision(one, two.Location);
        }

        // overload with different parameters
        public Collision DetectCollision(ISprite one, ISprite two)
        {
            return DetectCollision(one.Location, two.Location);
        }

        /*
         * Returns where two collides with one (ex. top of one, left of one)
         */
        public Collision DetectCollision(Rectangle one, Rectangle two)
        {
            Rectangle intersection = Rectangle.Intersect(one, two);

            if (intersection.IsEmpty)
                return Collision.None;

            if (intersection.Bottom == one.Bottom) // intersects at the bottom
            {
                // could be Left, Bottom, or Right
                return DetermineCollisionBottom(intersection, one);
            }
            else if (intersection.Top == one.Top) // intersects at the top
            {
                // could be Left, Top, or Right
                return DetermineCollisionTop(intersection, one);
            }
            else if (intersection.Right == one.Right)
            {
                // could be Top, Bottom, or Right
                return DetermineCollisionRight(intersection, one);
            }
            else if (intersection.Left == one.Left)
            {
                // could be Top, Bottom, or Left
                return DetermineCollisionLeft(intersection, one);
            }
            else // somehow two is inside one
            {
                return Collision.None; // TODO is just none for now; should make it go towards the nearest edge?
            }
        }

        public Collision DetermineCollisionBottom(Rectangle intersection, Rectangle one)
        {
            // check if could be Left
            if (intersection.Left > one.Left)
            {
                // cannot be Left, so check if intersects Bottom or Right more
                if (intersection.Height > intersection.Width)
                {
                    // intersects Right side more than Bottom
                    return Collision.Right;
                }
                else
                {
                    // intersects Bottom more
                    return Collision.Bottom;
                }
            }
            else
            {
                // is Left, so check if intersects Bottom or Left more
                if (intersection.Height > intersection.Width)
                {
                    // intersects Left side more than Bottom
                    return Collision.Left;
                }
                else
                {
                    // intersects Bottom more
                    return Collision.Bottom;
                }
            }
        }

        public Collision DetermineCollisionTop(Rectangle intersection, Rectangle one)
        {
            // check if could be Left
            if (intersection.Left > one.Left)
            {
                // cannot be Left, so check if intersects Top or Right more
                if (intersection.Height > intersection.Width)
                {
                    // intersects Right side more than Top
                    return Collision.Right;
                }
                else
                {
                    // intersects Top more
                    return Collision.Top;
                }
            }
            else
            {
                // is Left, so check if intersects Top or Left more
                if (intersection.Height > intersection.Width)
                {
                    // intersects Left side more than Top
                    return Collision.Left;
                }
                else
                {
                    // intersects Top more
                    return Collision.Top;
                }
            }
        }

        public Collision DetermineCollisionRight(Rectangle intersection, Rectangle one)
        {
            // check if could be Top
            if (intersection.Top > one.Top)
            {
                // cannot be Top, so check if intersects Bottom or Right more
                if (intersection.Height > intersection.Width)
                {
                    // intersects Right side more than Top
                    return Collision.Right;
                }
                else
                {
                    // intersects Bottom more
                    return Collision.Bottom;
                }
            }
            else
            {
                // is Top, so check if intersects Bottom or Right more
                if (intersection.Height > intersection.Width)
                {
                    // intersects Right side more than Top
                    return Collision.Right;
                }
                else
                {
                    // intersects Top more
                    return Collision.Top;
                }
            }
        }

        public Collision DetermineCollisionLeft(Rectangle intersection, Rectangle one)
        {
            // check if could be Top
            if (intersection.Top > one.Top)
            {
                // cannot be Top, so check if intersects Bottom or Right more
                if (intersection.Height > intersection.Width)
                {
                    // intersects Left side more than Top
                    return Collision.Left;
                }
                else
                {
                    // intersects Bottom more
                    return Collision.Bottom;
                }
            }
            else
            {
                // is Top, so check if intersects Bottom or Right more
                if (intersection.Height > intersection.Width)
                {
                    // intersects Left side more than Top
                    return Collision.Left;
                }
                else
                {
                    // intersects Top more
                    return Collision.Top;
                }
            }
        }
    }
}
