namespace sprint0
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;
    using System.Collections.Generic;
    using System.Linq;
    //Author: Jacob Urick
    // Last updated 4/23/2021 by shah.1440
    public class GameLevelMachine
    {
        private int numberOfTotalRooms;
        private string levelString;
        private int levelNumber;
        private int numberOfRooms;
        private AbstractLevel level;
        public Level LevelState { get => levelState; }
        public enum Level { Level1, Level2, Level3, Level4 }
        public Level levelState;
        public GameLevelMachine()
        {
            levelState = Level.Level1;
            level = new Level1();
            numberOfRooms = level.GetNumberOfRooms();
            levelNumber = level.GetLevelNumber();
            levelString = level.GetLevelString();
            numberOfTotalRooms = level.GetTotalNumberOfRooms();
        }

        public List<int> GetRoomsWithKeys() => level.GetRoomsWithKeys();
        public string GetLevelString() => levelString;
        public int GetNumberOfRooms() => numberOfRooms;
        public int GetLevelNumber() => levelNumber;
        public int GetNumberOfTotalRooms() => numberOfTotalRooms;
        public int GetInitialRoomIndex() => level.GetInitialRoomIndex();

        public void SetLevel(Level state)
        {
            this.levelState = state;
            if (state == Level.Level1)
            {
                level = new Level1();
            }
            if (state == Level.Level2)
            {
                level = new Level2();
            }
            if (state == Level.Level3)
            {
                level = new Level3();
            }
            if (state == Level.Level4)
            {
                level = new Level4();
            }
            levelString = level.GetLevelString();
            levelNumber = level.GetLevelNumber();
            numberOfRooms = level.GetNumberOfRooms();
            numberOfTotalRooms = level.GetTotalNumberOfRooms();

        }

        public Dictionary<Direction, int> GetAdjacentRooms(int roomIndex)
        {
            if (levelState == Level.Level1)
            {
                return AdjacentRooms.ListOfAdjacentRooms(roomIndex);
            }
            else if (levelState == Level.Level2)
            {
                return AdjacentRooms2.ListOfAdjacentRooms(roomIndex);
            }
            else if (levelState == Level.Level3)
            {
                return AdjacentRooms3.ListOfAdjacentRooms(roomIndex);
            }
            else
            {
                return AdjacentRooms4.ListOfAdjacentRooms(roomIndex);
            }
        }

        public int GetAdjacentRoom(int roomIndex, Direction side)
        {
            if (levelState == Level.Level1)
            {
                return AdjacentRooms.GetAdjacentRoom(roomIndex, side);
            }
            else if (levelState == Level.Level2)
            {
                return AdjacentRooms2.GetAdjacentRoom(roomIndex, side);
            }
            else if (levelState == Level.Level3)
            {
                return AdjacentRooms3.GetAdjacentRoom(roomIndex, side);
            }
            else
            {
                return AdjacentRooms4.GetAdjacentRoom(roomIndex, side);
            }
        }
    }

}
