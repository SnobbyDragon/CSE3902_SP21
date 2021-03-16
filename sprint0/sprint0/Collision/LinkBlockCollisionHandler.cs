using System;
using Microsoft.Xna.Framework;

namespace sprint0
{
    public class LinkBlockCollisionHandler
    {
        private readonly int linkSize = (int)(16 * Game1.Scale);

        public LinkBlockCollisionHandler()
        {
        }

        public void HandleCollision(IPlayer link, IBlock block, Direction side)
        {
            if (!block.IsWalkable())
            {
                if (block.IsMovable())
                {
                    HandleMovableBlock(link, block, side);
                }
                else
                {
                    HandleImmovableBlock(link, block, side);
                }
            }
        }

        private void HandleMovableBlock(IPlayer link, IBlock block, Direction side)
        {
            switch (side)
            {
                case Direction.n:
                    block.Location = new Rectangle(block.Location.X, (int)link.Pos.Y - block.Location.Height, block.Location.Width, block.Location.Height);
                    break;
                case Direction.s:
                    block.Location = new Rectangle(block.Location.X, (int)link.Pos.Y + linkSize, block.Location.Width, block.Location.Height);
                    break;
                case Direction.e:
                    block.Location = new Rectangle((int)link.Pos.X + linkSize, block.Location.Y, block.Location.Width, block.Location.Height);
                    break;
                case Direction.w:
                    block.Location = new Rectangle((int)link.Pos.X - block.Location.Width, block.Location.Y, block.Location.Width, block.Location.Height);
                    break;
            }
            block.SetIsMovable();

        }

        private void HandleImmovableBlock(IPlayer link, IBlock block, Direction side)
        {
            switch (side)
            {
                case Direction.n:
                    link.Pos += new Vector2(0, block.Location.Bottom - link.Pos.Y);
                    break;
                case Direction.s:
                    link.Pos += new Vector2(0, block.Location.Top - (link.Pos.Y + linkSize));
                    break;
                case Direction.e:
                    link.Pos += new Vector2(block.Location.Left - (link.Pos.X + linkSize), 0);
                    break;
                case Direction.w:
                    link.Pos += new Vector2(block.Location.Right - link.Pos.X, 0);
                    break;
            }
        }
    }
}
