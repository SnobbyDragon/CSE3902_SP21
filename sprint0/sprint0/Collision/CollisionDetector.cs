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

        //TODO idk what im doing
        //public void DetectLinkEnemyCollisions(ISprite link, List<IEnemy> enemies)
        //{
        //    foreach (IEnemy enemy in enemies)
        //    {
        //        Collision side = DetectCollision(link, enemy);
        //        if (side != Collision.None)
        //        {

        //        }
        //    }
        //}

        /*
         * Returns where two collides with one (ex. top of one, left of one)
         */
        public Collision DetectCollision(ISprite one, ISprite two)
        {
            Rectangle intersection = Rectangle.Intersect(one.Location, two.Location);

            if (intersection.IsEmpty)
                return Collision.None;

            if (intersection.Bottom == one.Location.Bottom) // intersects at the bottom
            {
                // could be Left, Bottom, or Right
                return DetermineCollisionBottom(intersection, one);
            }
            else if (intersection.Top == one.Location.Top) // intersects at the top
            {
                // could be Left, Top, or Right
                return DetermineCollisionTop(intersection, one);
            }
            else if (intersection.Right == one.Location.Right)
            {
                // could be Top, Bottom, or Right
                return DetermineCollisionRight(intersection, one);
            }
            else if (intersection.Left == one.Location.Left)
            {
                // could be Top, Bottom, or Left
                return DetermineCollisionLeft(intersection, one);
            }
            else // somehow two is inside one
            {
                return Collision.Top; // arbitrarily chooses top TODO
            }
        }

        public Collision DetermineCollisionBottom(Rectangle intersection, ISprite one)
        {
            // check if could be Left
            if (intersection.Left > one.Location.Left)
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

        public Collision DetermineCollisionTop(Rectangle intersection, ISprite one)
        {
            // check if could be Left
            if (intersection.Left > one.Location.Left)
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

        public Collision DetermineCollisionRight(Rectangle intersection, ISprite one)
        {
            // check if could be Top
            if (intersection.Top > one.Location.Top)
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

        public Collision DetermineCollisionLeft(Rectangle intersection, ISprite one)
        {
            // check if could be Top
            if (intersection.Top > one.Location.Top)
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
