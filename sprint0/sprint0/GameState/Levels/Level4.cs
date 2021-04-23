namespace sprint0
{
    using System.Collections.Generic;

    //Author: Jacob Urick
    // Last updated 4/22/2021 by urick.9
    public class Level4 : AbstractLevel
    {
        protected new readonly int numberOfRooms = 14;
        protected new readonly string levelString = "Level4";
        protected new int levelNumber = 2;
        protected new int initialRoomIndex = 13;
        protected new int totalNumberOfRooms = 14;
        protected new List<int> roomWithKey = new List<int> {3,4,5,6,7,8,9,10,11,12,13};

        public Level4()
        {

        }
        override public string GetLevelString()
        {
            return levelString;
        }
        override public int GetNumberOfRooms()
        {
            return numberOfRooms;
        }

        override public int GetTotalNumberOfRooms()
        {
            return numberOfRooms;
        }
        public override int GetLevelNumber()
        {
            return levelNumber;
        }

        public override int GetInitialRoomIndex()
        {
            return initialRoomIndex;
        }
        public override List<int> GetRoomsWithKeys()
        {
            return roomWithKey;
        }
    }

}
