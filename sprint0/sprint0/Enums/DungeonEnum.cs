using System;
namespace sprint0
{
    public enum DungeonEnum
    {
        RoomFloor, RoomBorder, Darkness, DownWall, RightWall, LeftWall, UpWall, DownOpenDoor, RightOpenDoor, LeftOpenDoor, UpOpenDoor,
        DownLockedDoor, RightLockedDoor, LeftLockedDoor, UpLockedDoor, DownShutDoor, RightShutDoor, LeftShutDoor, UpShutDoor,
        DownBombedOpening, RightBombedOpening, LeftBombedOpening, UpBombedOpening
    }

    public static class DungeonEnumExtension
    {
        public static DungeonEnum ToDungeonEnum(this string dungeon)
             => (DungeonEnum)Enum.Parse(typeof(DungeonEnum), dungeon, true);

        public static string GetName(this DungeonEnum dungeon)
            => Enum.GetName(dungeon.GetType(), dungeon);

        public static DungeonEnum ToDungeonEnum(this ISprite dungeon)
        {
            if (DungeonEnum.DownWall.GetName().Contains(dungeon.GetType().Name))
                return GetWallEnum((Wall)dungeon);
            if (DungeonEnum.DownOpenDoor.GetName().Contains(dungeon.GetType().Name))
                return GetOpenDoorEnum((OpenDoor)dungeon);
            if (DungeonEnum.DownLockedDoor.GetName().Contains(dungeon.GetType().Name))
                return GetLockedDoorEnum((LockedDoor)dungeon);
            if (DungeonEnum.DownShutDoor.GetName().Contains(dungeon.GetType().Name))
                return GetShutDoorEnum((ShutDoor)dungeon);
            if (DungeonEnum.DownBombedOpening.GetName().Contains(dungeon.GetType().Name))
                return GetBombedOpeningEnum((BombedOpening)dungeon);
            return dungeon.GetType().Name.ToDungeonEnum();
        }

        public static DungeonEnum ToBombedOpening(this Wall border)
        {
            if (border.Side == Direction.North) return DungeonEnum.DownBombedOpening;
            if (border.Side == Direction.South) return DungeonEnum.UpBombedOpening;
            if (border.Side == Direction.East) return DungeonEnum.LeftBombedOpening;
            if (border.Side == Direction.West) return DungeonEnum.RightBombedOpening;
            throw new ArgumentException("Not a valid wall!");
        }

        private static DungeonEnum GetWallEnum(this Wall border)
        {
            if (border.Side == Direction.North) return DungeonEnum.DownWall;
            if (border.Side == Direction.South) return DungeonEnum.UpWall;
            if (border.Side == Direction.East) return DungeonEnum.LeftWall;
            if (border.Side == Direction.West) return DungeonEnum.RightWall;
            throw new ArgumentException("Not a valid wall!");
        }

        private static DungeonEnum GetOpenDoorEnum(this OpenDoor border)
        {
            if (border.Side == Direction.North) return DungeonEnum.DownOpenDoor;
            if (border.Side == Direction.South) return DungeonEnum.UpOpenDoor;
            if (border.Side == Direction.East) return DungeonEnum.LeftOpenDoor;
            if (border.Side == Direction.West) return DungeonEnum.RightOpenDoor;
            throw new ArgumentException("Not a valid open door!");
        }

        private static DungeonEnum GetLockedDoorEnum(this LockedDoor border)
        {
            if (border.Side == Direction.North) return DungeonEnum.DownLockedDoor;
            if (border.Side == Direction.South) return DungeonEnum.UpLockedDoor;
            if (border.Side == Direction.East) return DungeonEnum.LeftLockedDoor;
            if (border.Side == Direction.West) return DungeonEnum.RightLockedDoor;
            throw new ArgumentException("Not a valid locked door!");
        }

        private static DungeonEnum GetShutDoorEnum(this ShutDoor border)
        {
            if (border.Side == Direction.North) return DungeonEnum.DownShutDoor;
            if (border.Side == Direction.South) return DungeonEnum.UpShutDoor;
            if (border.Side == Direction.East) return DungeonEnum.LeftShutDoor;
            if (border.Side == Direction.West) return DungeonEnum.RightShutDoor;
            throw new ArgumentException("Not a valid shut door!");
        }

        private static DungeonEnum GetBombedOpeningEnum(this BombedOpening border)
        {
            if (border.Side == Direction.North) return DungeonEnum.DownBombedOpening;
            if (border.Side == Direction.South) return DungeonEnum.UpBombedOpening;
            if (border.Side == Direction.East) return DungeonEnum.LeftBombedOpening;
            if (border.Side == Direction.West) return DungeonEnum.RightBombedOpening;
            throw new ArgumentException("Not a valid bombed opening!");
        }
    }
}
