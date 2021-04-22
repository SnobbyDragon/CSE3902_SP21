namespace sprint0
{
    //Author: Jacob Urick
    // Last updated 4/22/2021 by urick.9
    public class Level1 : AbstractLevel
    {
        protected new int numberOfRooms = 20;
        protected new string levelString = "Level1";
        protected new int levelNumber = 1;
        protected new int initialRoomIndex = 18;
        protected new int totalNumberOfRooms = 22;

        public Level1()
        {
            
        }
        override public int GetTotalNumberOfRooms()
        {
            return numberOfRooms;
        }
        override public string GetLevelString()
        {
            return levelString;
        }
        override public int GetNumberOfRooms()
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
