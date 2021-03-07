using System;
using Microsoft.Xna.Framework;

namespace sprint0
{
    public class LinkBlockCollisionHandler
    {
        public LinkBlockCollisionHandler()
        {
        }

        public void HandleCollision(IPlayer link, ISprite block, Direction side) //TODO change to static obstacles
        {   
            switch (side)
            {
                case Direction.n: // if collide above, then move down
                    link.Pos += new Vector2(0, block.Location.Bottom - link.Pos.Y);
                    break;
                case Direction.s: // if collide below, then move up
                    link.Pos += new Vector2(0, block.Location.Top - (link.Pos.Y + 16)); // TODO change 16 to size
                    break;
                case Direction.e: // if collide right, then move left
                    link.Pos += new Vector2(block.Location.Left - (link.Pos.X + 16), 0); // TODO change 16 to size
                    break;
                case Direction.w: // if collide left, then move right
                    link.Pos += new Vector2(block.Location.Right - link.Pos.X, 0);
                    break;
            }
        }
    }
}
