using System;
using Microsoft.Xna.Framework;

namespace sprint0
{
    public class BlockBlockCollisionHandler
    {

        private readonly int base_size = 16;
        public BlockBlockCollisionHandler()
        {
        }

        public void HandleCollision(IBlock block1, IBlock block2, Direction side) 
        {
            if (!block2.IsWalkable()) // cannot walk on it
            {
                if (block2.IsMovable()) // can push it
                {
                    HandleMovableBlock(block1, block2, side);
                }
                else // can neither walk on nor push it
                {
                    HandleImmovableBlock(block1, block2, side);
                }
            }
        }

        private void HandleMovableBlock(IBlock block1, IBlock block2, Direction side)
        {
            switch (side)
            {
                case Direction.n: // if collide above, then push up
                    block2.Location = new Rectangle(block2.Location.X, block1.Location.Top - block2.Location.Height, block2.Location.Width, block2.Location.Height);
                    break;
                case Direction.s: // if collide below, then push down
                    block2.Location = new Rectangle(block2.Location.X, block1.Location.Top + (int)(base_size*Game1.Scale), block2.Location.Width, block2.Location.Height); 
                    break;
                case Direction.e: // if collide right, then push right
                    block2.Location = new Rectangle(block1.Location.Left + (int)(base_size * Game1.Scale), block2.Location.Y, block2.Location.Width, block2.Location.Height); 
                    break;
                case Direction.w: // if collide left, then push left
                    block2.Location = new Rectangle(block1.Location.Left - block2.Location.Width, block2.Location.Y, block2.Location.Width, block2.Location.Height);
                    break;
            }
        }

        private void HandleImmovableBlock(IBlock block1, IBlock block2, Direction side)
        {
            switch (side)
            {
                case Direction.n: // if collide above, then move down
                    block1.Location = new Rectangle(block1.Location.X, block2.Location.Bottom - block1.Location.Top, block2.Location.Width, block2.Location.Height);
                    break;
                case Direction.s: // if collide below, then move up
                    block1.Location = new Rectangle(block1.Location.X, block2.Location.Top - (block1.Location.Top + (int)(base_size * Game1.Scale)), block2.Location.Width, block2.Location.Height);
                    break;
                case Direction.e: // if collide right, then move left
                    block1.Location = new Rectangle(block2.Location.Left - (block1.Location.Left + (int)(base_size * Game1.Scale)), block1.Location.Y, block2.Location.Width, block2.Location.Height);
                    break;
                case Direction.w: // if collide left, then move right
                    block1.Location = new Rectangle(block2.Location.Right - block1.Location.Left, block1.Location.Y, block2.Location.Width, block2.Location.Height);
                    break;
            }
        }
    }
}
