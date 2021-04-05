﻿using System;
using Microsoft.Xna.Framework;

namespace sprint0
{
    public class LinkBlockCollisionHandler
    {
        private readonly Game1 game;
        private readonly int linkSize = (int)(16 * Game1.Scale);
        private readonly int offset = 4, stairsRoom = 1, basement = 0;

        public LinkBlockCollisionHandler(Game1 game)
        {
            this.game = game;
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
            else if (block is Stairs)
            {
                HandleStairs(link, block);
            }
            else if (block is Ladder)
            {
                HandleLadder(link);
            }
        }
        private void HandleStairs(IPlayer link, IBlock block)
        {
            if (block.Location.Contains(new Rectangle((int)link.Pos.X + offset, (int)link.Pos.Y + offset, linkSize - offset * 2, linkSize - offset * 2)))
            {
                game.stateMachine.HandleSnapRoomChange(basement);

                link.Direction = Direction.s;
                link.State = new DownIdleState(link);
            }
        }
        private void HandleLadder(IPlayer link)
        {
            if (link.Pos.Y < Game1.HUDHeight * Game1.Scale)
            {
                game.stateMachine.HandleSnapRoomChange(stairsRoom);
                link.Pos = new Vector2(200,200);
                link.Direction = Direction.e;
                link.State = new LeftIdleState(link);
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
                    if (block is MovableBlock5)
                    {
                        block.Location = new Rectangle((int)link.Pos.X + block.Location.Width, block.Location.Y, block.Location.Width, block.Location.Height);
                    }
                    else
                    {
                        link.Pos += new Vector2(block.Location.Left - (link.Pos.X + linkSize - offset), 0);
                    }
                    break;
                case Direction.w:
                    if (block is MovableBlock5)
                    {
                        block.Location = new Rectangle((int)link.Pos.X - block.Location.Width, block.Location.Y, block.Location.Width, block.Location.Height);
                    }
                    else
                    {
                        link.Pos += new Vector2(block.Location.Right - (link.Pos.X + offset), 0);
                    }
                    break;
            }
            block.SetIsMovable();
        }
        private void HandleImmovableBlock(IPlayer link, IBlock block, Direction side)
        {
            switch (side)
            {
                case Direction.n:
                    link.Pos += new Vector2(0, block.Location.Bottom - (link.Pos.Y + offset));
                    break;
                case Direction.s:
                    link.Pos += new Vector2(0, block.Location.Top - (link.Pos.Y + linkSize - offset));
                    break;
                case Direction.e:
                    link.Pos += new Vector2(block.Location.Left - (link.Pos.X + linkSize - offset), 0);
                    break;
                case Direction.w:
                    link.Pos += new Vector2(block.Location.Right - (link.Pos.X + offset), 0);
                    break;
            }
        }
    }
}
