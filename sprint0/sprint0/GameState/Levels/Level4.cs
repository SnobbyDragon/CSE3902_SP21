namespace sprint0
{
    using System.Collections.Generic;

    //Author: Jacob Urick
    // Last updated 4/22/2021 by urick.9
    public class Level3 : AbstractLevel
    {
        protected new readonly int numberOfRooms = 6;
        protected new readonly string levelString = "Level3";
        protected new int levelNumber = 2;
        protected new int initialRoomIndex = 0;
        protected new int totalNumberOfRooms = 6;
        protected new List<int> roomWithKey = new List<int> { 1,2,3,4,5,6};

        public Level3()
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

    }

}
