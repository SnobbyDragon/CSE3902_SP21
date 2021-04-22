namespace sprint0
{
    //Author: Jacob Urick
    // Last updated 4/22/2021 by urick.9
    public class Level2 : AbstractLevel
    {
        protected new readonly int numberOfRooms = 6;
        protected new readonly string levelString = "Level2";
        protected new int levelNumber = 2;
        protected new int initialRoomIndex = 1;
        protected int totalNumberOfRooms = 22;

        public Level2()
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
