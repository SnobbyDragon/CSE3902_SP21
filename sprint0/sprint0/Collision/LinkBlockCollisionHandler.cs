﻿using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace sprint0
{
    public class LinkBlockCollisionHandler
    {
        private readonly Game1 game;
        private readonly List<IBlock> blocks;
        private readonly int linkSize = (int)(16 * Game1.Scale);
        private readonly int offset = 4, stairsRoom = 1, basement = 0;

        public LinkBlockCollisionHandler(Game1 game, List<IBlock> blocks)
        {
            this.game = game;
            this.blocks = blocks;
        }

        public void HandleCollision(IPlayer link, IBlock block, Direction side)
        {
            if (!link.IsJumping())
            {
                if (block is SoundBlock block1) block1.MakeSound();
                if (!block.IsWalkable())
                {
                    if (block.IsMovable(side)) HandleMovableBlock(link, block, side);
                    else if (block is Water && link.CanPlaceLadder) HandleStepLadder(link, block);
                    else HandleImmovableBlock(link, block, side);
                }
                else if (block is Stairs) HandleStairs(link, block);
                else if (block is Ladder) HandleLadder(link);
            }
        }
        private void HandleStairs(IPlayer link, IBlock block)
        {
            if (block.Location.Contains(new Rectangle((int)link.Pos.X + offset, (int)link.Pos.Y + offset, linkSize - offset * 2, linkSize - offset * 2)))
            {
                game.stateMachine.HandleSnapRoomChange(basement);
                link.Direction = Direction.South;
                link.State = new DownIdleState(link);
            }
        }
        private void HandleLadder(IPlayer link)
        {
            if (link.Pos.Y < Game1.HUDHeight * Game1.Scale)
            {
                game.stateMachine.HandleSnapRoomChange(stairsRoom);
                link.Pos = new Vector2(280, 340);
                link.Direction = Direction.East;
                link.State = new LeftIdleState(link);
            }
        }

        private void HandleMovableBlock(IPlayer link, IBlock block, Direction side)
        {
            bool canPush;
            Vector2 originalLoc = block.Location.Location.ToVector2();
            switch (side)
            {
                case Direction.North:
                    if (block is MovableBlock20 bN && bN.Direction != Direction.North)
                        link.Pos += new Vector2(0, block.Location.Bottom - (link.Pos.Y + offset));
                    else
                    {
                        block.Location = new Rectangle(block.Location.X, (int)link.Pos.Y - block.Location.Height, block.Location.Width, block.Location.Height);
                        canPush = BlockBlockCollisionDetector.DetectCollisions(block, blocks);
                        if (!canPush)
                        {
                            block.Location = new Rectangle((int)originalLoc.X, (int)originalLoc.Y, block.Location.Width, block.Location.Height);
                            link.Pos += new Vector2(0, block.Location.Bottom - (link.Pos.Y + offset));
                        }
                    }
                    break;
                case Direction.South:
                    if (block is MovableBlock20 bS && bS.Direction != Direction.South)
                        link.Pos += new Vector2(0, block.Location.Top - (link.Pos.Y + linkSize - offset));
                    else
                    {
                        block.Location = new Rectangle(block.Location.X, (int)link.Pos.Y + linkSize, block.Location.Width, block.Location.Height);
                        canPush = BlockBlockCollisionDetector.DetectCollisions(block, blocks);
                        if (!canPush)
                        {
                            block.Location = new Rectangle((int)originalLoc.X, (int)originalLoc.Y, block.Location.Width, block.Location.Height);
                            link.Pos += new Vector2(0, block.Location.Top - (link.Pos.Y + linkSize - offset));
                        }
                    }
                    break;
                case Direction.East:
                    if (block is MovableBlock1 || (block is MovableBlock20 bE && bE.Direction != Direction.East))
                        link.Pos += new Vector2(block.Location.Left - (link.Pos.X + linkSize - offset), 0);
                    else
                    {
                        block.Location = new Rectangle((int)link.Pos.X + block.Location.Width, block.Location.Y, block.Location.Width, block.Location.Height);
                        canPush = BlockBlockCollisionDetector.DetectCollisions(block, blocks);
                        if (!canPush)
                        {
                            block.Location = new Rectangle((int)originalLoc.X, (int)originalLoc.Y, block.Location.Width, block.Location.Height);
                            link.Pos += new Vector2(block.Location.Left - (link.Pos.X + linkSize - offset), 0);
                        }
                    }
                    break;
                case Direction.West:
                    if (block is MovableBlock1 || (block is MovableBlock20 bW && bW.Direction != Direction.West))
                        link.Pos += new Vector2(block.Location.Right - (link.Pos.X + offset), 0);
                    else
                    {
                        block.Location = new Rectangle((int)link.Pos.X - block.Location.Width, block.Location.Y, block.Location.Width, block.Location.Height);
                        canPush = BlockBlockCollisionDetector.DetectCollisions(block, blocks);
                        if (!canPush)
                        {
                            block.Location = new Rectangle((int)originalLoc.X, (int)originalLoc.Y, block.Location.Width, block.Location.Height);
                            link.Pos += new Vector2(block.Location.Right - (link.Pos.X + offset), 0);
                        }
                    }
                    break;
            }
            block.SetIsMovable();
        }

        private void HandleImmovableBlock(IPlayer link, IBlock block, Direction side)
        {
            switch (side)
            {
                case Direction.North:
                    link.Pos += new Vector2(0, block.Location.Bottom - (link.Pos.Y + offset));
                    break;
                case Direction.South:
                    link.Pos += new Vector2(0, block.Location.Top - (link.Pos.Y + linkSize - offset));
                    break;
                case Direction.East:
                    link.Pos += new Vector2(block.Location.Left - (link.Pos.X + linkSize - offset), 0);
                    break;
                case Direction.West:
                    link.Pos += new Vector2(block.Location.Right - (link.Pos.X + offset), 0);
                    break;
            }
        }
        private void HandleStepLadder(IPlayer link, IBlock water)
        {
            link.CanPlaceLadder = false;
            Vector2 ladderLoc = new Vector2(water.Location.X, water.Location.Y);
            game.Room.LoadLevel.RoomBlocks.RemoveBlock(water);
            game.Room.LoadLevel.RoomBlocks.AddBlock(ladderLoc, BlockEnum.StepLadder);
        }
    }
}
