using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace sprint0
{
    public class BlockBlockCollisionHandler
    {

        private readonly List<IBlock> blocks;

        public BlockBlockCollisionHandler(List<IBlock> blocks) => this.blocks = blocks;

        public bool HandleCollision(IBlock pushedBlock, IBlock otherBlock, Direction side)
        {
            if (pushedBlock is SoundBlock block) block.MakeSound();
            if (otherBlock is SoundBlock _block) _block.MakeSound();

            bool canPush;
            if (otherBlock.IsMovable(side)) canPush = HandleMovableMovableBlock(pushedBlock, otherBlock, side);
            else
            {
                canPush = false;
                HandleMovableImmovableBlock(pushedBlock, otherBlock, side);
            }
            return canPush;
        }

        private bool HandleMovableMovableBlock(IBlock block1, IBlock block2, Direction side)
        {
            Vector2 originalLoc = block2.Location.Location.ToVector2();
            List<IBlock> tempBlocks = new List<IBlock>();
            tempBlocks.AddRange(blocks);
            tempBlocks.Remove(block1);
            switch (side)
            {
                case Direction.North:
                    block2.Location = new Rectangle(block2.Location.X, block1.Location.Top - block2.Location.Height, block2.Location.Width, block2.Location.Height);
                    break;
                case Direction.South:
                    block2.Location = new Rectangle(block2.Location.X, block1.Location.Top + block2.Location.Height, block2.Location.Width, block2.Location.Height);
                    break;
                case Direction.East:
                    block2.Location = new Rectangle(block1.Location.Left + block2.Location.Width, block2.Location.Y, block2.Location.Width, block2.Location.Height);
                    break;
                case Direction.West:
                    block2.Location = new Rectangle(block1.Location.Left - block2.Location.Width, block2.Location.Y, block2.Location.Width, block2.Location.Height);
                    break;
            }
            bool canPush = BlockBlockCollisionDetector.DetectCollisions(block2, tempBlocks);
            if (!canPush)
            {
                block2.Location = new Rectangle((int)originalLoc.X, (int)originalLoc.Y, block2.Location.Width, block2.Location.Height);
            }
            return canPush;
        }

        private void HandleMovableImmovableBlock(IBlock block1, IBlock block2, Direction side)
        {
            switch (side)
            {
                case Direction.North:
                    block1.Location = new Rectangle(block1.Location.X, block2.Location.Bottom, block1.Location.Width, block1.Location.Height);
                    break;
                case Direction.South:
                    block1.Location = new Rectangle(block1.Location.X, block2.Location.Top - block1.Location.Height, block1.Location.Width, block1.Location.Height);
                    break;
                case Direction.East:
                    block1.Location = new Rectangle(block2.Location.Left - block2.Location.Width, block1.Location.Y, block1.Location.Width, block1.Location.Height);
                    break;
                case Direction.West:
                    block1.Location = new Rectangle(block2.Location.Right, block1.Location.Y, block1.Location.Width, block1.Location.Height);
                    break;
            }
        }
    }
}
