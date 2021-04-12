using System;
using Microsoft.Xna.Framework;

namespace sprint0
{
    public class BlockBlockCollisionHandler
    {
        private readonly int base_size = 16;

        public BlockBlockCollisionHandler() { }

        public void HandleCollision(IBlock block1, IBlock block2, Direction side)
        {
            if (!block2.IsWalkable())
            {
                if (block2.IsMovable()) HandleMovableBlock(block1, block2, side);
                else if (block1.IsMovable()) HandleImmovableBlock(block1, block2, side);
            }
        }

        private void HandleMovableBlock(IBlock block1, IBlock block2, Direction side)
        {
            switch (side)
            {
                case Direction.North:
                    block2.Location = new Rectangle(block2.Location.X, block1.Location.Top - block2.Location.Height, block2.Location.Width, block2.Location.Height);
                    break;
                case Direction.South:
                    block2.Location = new Rectangle(block2.Location.X, block1.Location.Top + (int)(base_size * Game1.Scale), block2.Location.Width, block2.Location.Height);
                    break;
                case Direction.East:
                    block2.Location = new Rectangle(block1.Location.Left + (int)(base_size * Game1.Scale), block2.Location.Y, block2.Location.Width, block2.Location.Height);
                    break;
                case Direction.West:
                    block2.Location = new Rectangle(block1.Location.Left - block2.Location.Width, block2.Location.Y, block2.Location.Width, block2.Location.Height);
                    break;
            }
        }

        private void HandleImmovableBlock(IBlock block1, IBlock block2, Direction side)
        {
            switch (side)
            {
                case Direction.North:
                    block1.Location = new Rectangle(block1.Location.X, block2.Location.Bottom - block1.Location.Top, block2.Location.Width, block2.Location.Height);
                    break;
                case Direction.South:
                    block1.Location = new Rectangle(block1.Location.X, block2.Location.Top - (block1.Location.Top + (int)(base_size * Game1.Scale)), block2.Location.Width, block2.Location.Height);
                    break;
                case Direction.East:
                    block1.Location = new Rectangle(block2.Location.Left - (block1.Location.Left + (int)(base_size * Game1.Scale)), block1.Location.Y, block2.Location.Width, block2.Location.Height);
                    break;
                case Direction.West:
                    block1.Location = new Rectangle(block2.Location.Right - block1.Location.Left, block1.Location.Y, block2.Location.Width, block2.Location.Height);
                    break;
            }
        }
    }
}
