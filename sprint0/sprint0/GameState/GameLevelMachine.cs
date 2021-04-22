namespace sprint0
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;
    using System.Collections.Generic;
    using System.Linq;
    //Author: Jacob Urick
    // Last updated 4/22/2021 by urick.9
    public class GameLevelMachine
    {
        private int numberOfTotalRooms;
        private string levelString;
        private int levelNumber;
        private int numberOfRooms;
        private AbstractLevel level;
        public enum Level { Level2, Level1 }
        private Level levelState;
        public GameLevelMachine()
        {
            levelState = Level.Level2;
            level = new Level2();
            numberOfRooms = level.GetNumberOfRooms();
            levelNumber = level.GetLevelNumber();
            levelString = level.GetLevelString();
            numberOfTotalRooms = level.GetTotalNumberOfRooms();
        }

        public void SetLevel(Level state) {
            this.levelState = state;
            if (state == Level.Level1) {
                level = new Level1();

            }
            if (state == Level.Level2)
            {
                level = new Level2();
            }
            levelString = level.GetLevelString();
            levelNumber = level.GetLevelNumber();
            numberOfRooms = level.GetNumberOfRooms();
        }

        public string GetLevelString() {
            return levelString;
        }
        public int GetNumberOfRooms()
        {
            return numberOfRooms;

        }
        public int GetLevelNumber()
        {
            return levelNumber;
        }
        public int GetNumberOfTotalRooms()
        {
            return numberOfTotalRooms;
        }

        public int GetInitialRoomIndex() {
            return level.GetInitialRoomIndex();
        }

        public Dictionary<Direction, int> GetAdjacentRooms(int roomIndex) {
            if (levelState == Level.Level1)
            {
                return AdjacentRooms.ListOfAdjacentRooms(roomIndex);
            }
            else {
                return AdjacentRooms2.ListOfAdjacentRooms(roomIndex);
            }
        }

        public int GetAdjacentRoom(int roomIndex, Direction side)
        {
            if (levelState == Level.Level1)
            {
                return AdjacentRooms.GetAdjacentRoom(roomIndex, side);
            }
            else
            {
                return AdjacentRooms2.GetAdjacentRoom(roomIndex, side);
            }
        }
    }

}
