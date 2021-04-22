using System;
using System.IO;
using System.Text;

namespace sprint0
{
    public static class LevelSaver
    {
        public static string SavedGamePath { get; } = "../../../SavedGame/";

        public static void SaveGame(Game1 game)
        {
            SaveRooms(game);
            SaveLink(game);
        }

        private static void SaveRooms(Game1 game)
        {
            foreach (Room room in game.Rooms.Values)
                SaveRoom(room);
        }

        private static void SaveRoom(Room room)
        {
            string filePath = SavedGamePath + "/Room" + room.RoomIndex + ".xml";
            try
            {
                using FileStream fs = File.Create(filePath);
                byte[] info = new UTF8Encoding(true).GetBytes("This is some text in the file.");
                // Add some information to the file.
                fs.Write(info, 0, info.Length);
            }
            catch (Exception e)
            {
                Console.WriteLine("Failed to save game: " + e.ToString());
            }
        }

        private static void SaveLink(Game1 game)
        {

        }
    }
}
