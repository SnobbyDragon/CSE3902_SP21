using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

//Author: Hannah Johnson and co

namespace sprint0
{
    public enum DungeonEnum
    {
        RoomFloor, RoomBorder, Darkness,
        DownWall, RightWall, LeftWall, UpWall,
        DownOpenDoor, RightOpenDoor, LeftOpenDoor, UpOpenDoor,
        DownLockedDoor, RightLockedDoor, LeftLockedDoor, UpLockedDoor,
        DownShutDoor, RightShutDoor, LeftShutDoor, UpShutDoor,
        DownBombedOpening, RightBombedOpening, LeftBombedOpening, UpBombedOpening
    }

    public enum BlockEnum
    {
        Block, Tile, Gap, Water, Floor, Stairs, Ladder, Brick, LeftStatue, RightStatue, MovableBlock, MovableBlock5, InvisibleBlock
    }
    public class DungeonFactory
    {
        private readonly Game1 game;
        private readonly Texture2D texture;

        public DungeonFactory(Game1 game)
        {
            this.game = game;
            texture = game.Content.Load<Texture2D>("Images/DungeonTileset");
        }

        public ISprite MakeSprite(DungeonEnum spriteType, Vector2 location, bool canBeBombed = false)
        {
            return spriteType switch
            {
                DungeonEnum.RoomFloor => new RoomFloor(texture, location),
                DungeonEnum.RoomBorder => new RoomBorder(texture, location),
                DungeonEnum.Darkness => new Darkness(texture, location),
                DungeonEnum.DownWall => new Wall(texture, location, Direction.n, game, canBeBombed),
                DungeonEnum.RightWall => new Wall(texture, location, Direction.w, game, canBeBombed),
                DungeonEnum.LeftWall => new Wall(texture, location, Direction.e, game, canBeBombed),
                DungeonEnum.UpWall => new Wall(texture, location, Direction.s, game, canBeBombed),
                DungeonEnum.DownOpenDoor => new OpenDoor(texture, location, Direction.n, game),
                DungeonEnum.RightOpenDoor => new OpenDoor(texture, location, Direction.w, game),
                DungeonEnum.LeftOpenDoor => new OpenDoor(texture, location, Direction.e, game),
                DungeonEnum.UpOpenDoor => new OpenDoor(texture, location, Direction.s, game),
                DungeonEnum.DownLockedDoor => new LockedDoor(texture, location, Direction.n, game),
                DungeonEnum.RightLockedDoor => new LockedDoor(texture, location, Direction.w, game),
                DungeonEnum.LeftLockedDoor => new LockedDoor(texture, location, Direction.e, game),
                DungeonEnum.UpLockedDoor => new LockedDoor(texture, location, Direction.s, game),
                DungeonEnum.DownShutDoor => new ShutDoor(texture, location, Direction.n, game),
                DungeonEnum.RightShutDoor => new ShutDoor(texture, location, Direction.w, game),
                DungeonEnum.LeftShutDoor => new ShutDoor(texture, location, Direction.e, game),
                DungeonEnum.UpShutDoor => new ShutDoor(texture, location, Direction.s, game),
                DungeonEnum.DownBombedOpening => new BombedOpening(texture, location, Direction.n, game),
                DungeonEnum.RightBombedOpening => new BombedOpening(texture, location, Direction.w, game),
                DungeonEnum.LeftBombedOpening => new BombedOpening(texture, location, Direction.e, game),
                DungeonEnum.UpBombedOpening => new BombedOpening(texture, location, Direction.s, game),
                _ => throw new ArgumentException("Invalid sprite! " + spriteType + " Sprite factory failed."),
            };
        }

        public IBlock MakeBlock(BlockEnum spriteType, Vector2 location, int width = InvisibleBlock.DefaultSize, int height = InvisibleBlock.DefaultSize)
        {
            return spriteType switch
            {
                BlockEnum.Block => new Block(texture, location),
                BlockEnum.Tile => new Tile(texture, location),
                BlockEnum.Gap => new Gap(texture, location),
                BlockEnum.Water => new Water(texture, location),
                BlockEnum.Floor => new Floor(texture, location),
                BlockEnum.Stairs => new Stairs(texture, location),
                BlockEnum.Ladder => new Ladder(texture, location),
                BlockEnum.Brick => new Brick(texture, location),
                BlockEnum.LeftStatue => new Statue(texture, location, Direction.e, game),
                BlockEnum.RightStatue => new Statue(texture, location, Direction.w, game),
                BlockEnum.MovableBlock => new MovableBlock1(texture, location),
                BlockEnum.MovableBlock5 => new MovableBlock5(texture, location),
                BlockEnum.InvisibleBlock => new InvisibleBlock(location, width, height),
                _ => throw new ArgumentException("Invalid sprite! " + spriteType + " Sprite factory failed."),
            };
        }
    }
}
