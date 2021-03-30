using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace sprint0
{
    public class RoomBlocks
    {
        private readonly DungeonFactory dungeonFactory;
        public List<IBlock> Blocks { get => blocks; set => blocks = value; }
        private List<IBlock> blocks;
        private readonly List<IBlock> blocksToRemove, blocksToAdd;

        public RoomBlocks(Game1 game)
        {
            dungeonFactory = new DungeonFactory(game);
            blocks = new List<IBlock>();
            blocksToRemove = new List<IBlock>();
            blocksToAdd = new List<IBlock>();
        }

        public IBlock AddBlock(Vector2 location, string block, int width = InvisibleBlock.DefaultSize, int height = InvisibleBlock.DefaultSize)
        {
            IBlock newBlock = dungeonFactory.MakeBlock(block, location, width, height);
            blocksToAdd.Add(newBlock);
            return newBlock;
        }

        public void RemoveBlock(IBlock block) => blocksToRemove.Add(block);

        public void AddNew()
        {
            if (blocksToAdd.Count > 0)
            {
                blocks.AddRange(blocksToAdd);
                blocksToAdd.Clear();
            }
        }

        public void RemoveDestroyed()
        {
            foreach (IBlock enemy in blocksToRemove)
            {
                blocks.Remove(enemy);
            }
        }

        public void Update()
        {
            foreach (IBlock block in blocks)
                block.Update();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (IBlock block in blocks)
                block.Draw(spriteBatch);
        }
    }
}
