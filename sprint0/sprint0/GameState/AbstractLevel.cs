using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace sprint0
{
    public abstract class AbstractLevel {

        protected int numberOfRooms = 20;
        protected string levelString = "Level1";
        protected int levelNumber = 1;
        protected int initialRoomIndex = 18;
        public abstract string GetLevelString();
        public abstract int GetNumberOfRooms();

        public abstract int GetLevelNumber();
        public abstract int GetInitialRoomIndex();
    }

    
        
}
