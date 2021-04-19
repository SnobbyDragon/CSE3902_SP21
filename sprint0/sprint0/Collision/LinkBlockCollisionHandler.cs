﻿using System;
using Microsoft.Xna.Framework;

namespace sprint0
{
    public class LinkBlockCollisionHandler
    {
        private readonly Game1 game;
        private readonly int linkSize = (int)(16 * Game1.Scale);
        private readonly int offset = 4, stairsRoom = 1, basement = 0;
        public LinkBlockCollisionHandler(Game1 game) => this.game = game;
        public void HandleCollision(IPlayer link, IBlock block, Direction side)
        {
            if (block is SoundBlock) ((SoundBlock)block).MakeSound();
            if (!block.IsWalkable())
            {
                if (block.IsMovable()) HandleMovableBlock(link, block, side);
                else if (block is Water && link.CanPlaceLadder) HandleStepLadder(link, block);
                else HandleImmovableBlock(link, block, side);
            }
            else if (block is Stairs) HandleStairs(link, block);
            else if (block is Ladder) HandleLadder(link);
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
            switch (side)
            {
                case Direction.North:
                    block.Location = new Rectangle(block.Location.X, (int)link.Pos.Y - block.Location.Height, block.Location.Width, block.Location.Height);
                    break;
                case Direction.South:
                    block.Location = new Rectangle(block.Location.X, (int)link.Pos.Y + linkSize, block.Location.Width, block.Location.Height);
                    break;
                case Direction.East:
                    if (block is MovableBlock5)
                        block.Location = new Rectangle((int)link.Pos.X + block.Location.Width, block.Location.Y, block.Location.Width, block.Location.Height);
                    else
                        link.Pos += new Vector2(block.Location.Left - (link.Pos.X + linkSize - offset), 0);
                    break;
                case Direction.West:
                    if (block is MovableBlock5)
                        block.Location = new Rectangle((int)link.Pos.X - block.Location.Width, block.Location.Y, block.Location.Width, block.Location.Height);
                    else
                        link.Pos += new Vector2(block.Location.Right - (link.Pos.X + offset), 0);
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
