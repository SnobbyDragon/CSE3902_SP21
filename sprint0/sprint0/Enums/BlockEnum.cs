using System;
using Microsoft.Xna.Framework;
namespace sprint0
{
    public enum BlockEnum
    {
        Block, Tile, Gap, Water, Floor, Stairs, Ladder, Brick, LeftStatue, RightStatue, MovableBlock, MovableBlock5, MovableBlock20, InvisibleBlock, SoundBlock, StepLadder
    }

    public static class BlockEnumExtension
    {
        public static BlockEnum ToBlockEnum(this string block)
             => (BlockEnum)Enum.Parse(typeof(BlockEnum), block, true);
        
        public static string GetName(this BlockEnum block)
            => Enum.GetName(block.GetType(), block);

        public static BlockEnum ToBlockEnum(this IBlock block)
        {
            if (block is StepLadderBlock) return BlockEnum.StepLadder;
            if (block is Statue statue) return GetStatueEnum(statue);
            return block.GetType().Name.ToBlockEnum();
        }

        private static BlockEnum GetStatueEnum(Statue statue)
        {
            if (statue.Dir == Direction.East) return BlockEnum.LeftStatue;
            if (statue.Dir == Direction.West) return BlockEnum.RightStatue;
            throw new ArgumentException("Not a valid statue!");
        }
    }
}
