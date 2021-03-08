using System;
using Microsoft.Xna.Framework;

namespace sprint0
{
    public class LinkBlockCollisionHandler
    {
        public LinkBlockCollisionHandler()
        {
        }

        public void HandleCollision(IPlayer link, IBlock block, Direction side) //TODO change to static obstacles
        {
            if (!block.IsWalkable()) // cannot walk on it
            {
                if (block.IsMovable()) // can push it
                {
                    HandleMovableBlock(link, block, side);
                }
                else // can neither walk on nor push it
                {
                    HandleImmovableBlock(link, block, side);
                }
            }
        }

        private void HandleMovableBlock(IPlayer link, IBlock block, Direction side)
        {
            switch (side)
            {
                case Direction.n: // if collide above, then push up
                    block.Location = new Rectangle(block.Location.X, (int)link.Pos.Y - block.Location.Height, block.Location.Width, block.Location.Height);
                    break;
                case Direction.s: // if collide below, then push down
                    block.Location = new Rectangle(block.Location.X, (int)link.Pos.Y + 16, block.Location.Width, block.Location.Height); // TODO change 16 to size
                    break;
                case Direction.e: // if collide right, then push right
                    block.Location = new Rectangle((int)link.Pos.X + 16, block.Location.Y, block.Location.Width, block.Location.Height); // TODO change 16 to size
                    break;
                case Direction.w: // if collide left, then push left
                    block.Location = new Rectangle((int)link.Pos.X - block.Location.Width, block.Location.Y, block.Location.Width, block.Location.Height);
                    break;
            }
        }

        private void HandleImmovableBlock(IPlayer link, IBlock block, Direction side)
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
