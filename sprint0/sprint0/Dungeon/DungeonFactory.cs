using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace sprint0
{
    public enum DungeonEnum
    {
        RoomFloor, RoomBorder, Darkness, DownWall, RightWall, LeftWall, UpWall, DownOpenDoor, RightOpenDoor, LeftOpenDoor, UpOpenDoor,
        DownLockedDoor, RightLockedDoor, LeftLockedDoor, UpLockedDoor, DownShutDoor, RightShutDoor, LeftShutDoor, UpShutDoor,
        DownBombedOpening, RightBombedOpening, LeftBombedOpening, UpBombedOpening
    }

    public enum BlockEnum
    {
        Block, Tile, Gap, Water, Floor, Stairs, Ladder, Brick, LeftStatue, RightStatue, MovableBlock, MovableBlock5, MovableBlock20, InvisibleBlock, SoundBlock, StepLadder
    }
    public class DungeonFactory
    {
        private readonly Game1 game;
        private readonly Texture2D texture;
        private readonly int roomIndex;

        public DungeonFactory(Game1 game, int roomIndex)
        {
            this.game = game;
            this.roomIndex = roomIndex;
            texture = game.Content.Load<Texture2D>("Images/DungeonTileset");
        }
        public ISprite MakeSprite(DungeonEnum spriteType, Vector2 location, bool canBeBombed = false)
        {
            return spriteType switch
            {
                DungeonEnum.RoomFloor => new RoomFloor(texture, location),
                DungeonEnum.RoomBorder => new RoomBorder(texture, location),
                DungeonEnum.Darkness => new Darkness(texture, location),
                DungeonEnum.DownWall => new Wall(texture, location, Direction.North, game.Rooms[roomIndex], canBeBombed),
                DungeonEnum.RightWall => new Wall(texture, location, Direction.West, game.Rooms[roomIndex], canBeBombed),
                DungeonEnum.LeftWall => new Wall(texture, location, Direction.East, game.Rooms[roomIndex], canBeBombed),
                DungeonEnum.UpWall => new Wall(texture, location, Direction.South, game.Rooms[roomIndex], canBeBombed),
                DungeonEnum.DownOpenDoor => new OpenDoor(texture, location, Direction.North, game.Rooms[roomIndex]),
                DungeonEnum.RightOpenDoor => new OpenDoor(texture, location, Direction.West, game.Rooms[roomIndex]),
                DungeonEnum.LeftOpenDoor => new OpenDoor(texture, location, Direction.East, game.Rooms[roomIndex]),
                DungeonEnum.UpOpenDoor => new OpenDoor(texture, location, Direction.South, game.Rooms[roomIndex]),
                DungeonEnum.DownLockedDoor => new LockedDoor(texture, location, Direction.North, game.Rooms[roomIndex]),
                DungeonEnum.RightLockedDoor => new LockedDoor(texture, location, Direction.West, game.Rooms[roomIndex]),
                DungeonEnum.LeftLockedDoor => new LockedDoor(texture, location, Direction.East, game.Rooms[roomIndex]),
                DungeonEnum.UpLockedDoor => new LockedDoor(texture, location, Direction.South, game.Rooms[roomIndex]),
                DungeonEnum.DownShutDoor => new ShutDoor(texture, location, Direction.North, game.Rooms[roomIndex]),
                DungeonEnum.RightShutDoor => new ShutDoor(texture, location, Direction.West, game.Rooms[roomIndex]),
                DungeonEnum.LeftShutDoor => new ShutDoor(texture, location, Direction.East, game.Rooms[roomIndex]),
                DungeonEnum.UpShutDoor => new ShutDoor(texture, location, Direction.South, game.Rooms[roomIndex]),
                DungeonEnum.DownBombedOpening => new BombedOpening(texture, location, Direction.North, game.Rooms[roomIndex]),
                DungeonEnum.RightBombedOpening => new BombedOpening(texture, location, Direction.West, game.Rooms[roomIndex]),
                DungeonEnum.LeftBombedOpening => new BombedOpening(texture, location, Direction.East, game.Rooms[roomIndex]),
                DungeonEnum.UpBombedOpening => new BombedOpening(texture, location, Direction.South, game.Rooms[roomIndex]),
                _ => throw new ArgumentException("Invalid sprite! " + spriteType.ToString() + " Sprite factory failed."),
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
                BlockEnum.LeftStatue => new Statue(texture, location, Direction.East, game),
                BlockEnum.RightStatue => new Statue(texture, location, Direction.West, game),
                BlockEnum.MovableBlock => new MovableBlock1(texture, location),
                BlockEnum.MovableBlock5 => new MovableBlock5(texture, location),
                BlockEnum.InvisibleBlock => new InvisibleBlock(location, width, height),
                BlockEnum.StepLadder => new StepLadderBlock(texture, location, game.Room),
                _ => throw new ArgumentException("Invalid sprite! " + spriteType.ToString() + " Sprite factory failed."),
            };
        }
        public IBlock MakeBlock(BlockEnum spriteType, Vector2 location,int sound)
        {
            return spriteType switch
            {
                BlockEnum.SoundBlock => new SoundBlock(texture, location, game, sound),
                _ => throw new ArgumentException("Invalid sprite! " + spriteType.ToString() + " Sprite factory failed."),
            };
        }
        public IBlock MakeBlock(BlockEnum spriteType, Vector2 location, Direction dir)
        {
            return spriteType switch
            {
                BlockEnum.MovableBlock20 => new MovableBlock20(texture, location, dir),
                _ => throw new ArgumentException("Invalid sprite! " + spriteType.ToString() + " Sprite factory failed."),
            };
        }
    }
}
