using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace sprint0
{
    public abstract class AbstractLevel {

        protected int numberOfRooms = 20;
        protected string levelString = "Level1";
        protected int levelNumber = 1;
        protected int initialRoomIndex = 18;
        protected int totalNumberOfRooms = 22;
        protected List<int> roomWithKey = new List<int> { 1, 2, 3, 4, 5, 6 };

        public abstract string GetLevelString();
        public abstract int GetNumberOfRooms();

        public abstract int GetLevelNumber();
        public abstract int GetInitialRoomIndex();

        public abstract int GetTotalNumberOfRooms();

        public List<int> GetRoomsWithKeys()
        {
            return roomWithKey;
        }
    }

    
        
}
