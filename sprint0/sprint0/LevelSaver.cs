using System;
using System.IO;
using System.Text;

namespace sprint0
{
    public static class LevelSaver
    {
        public static void SaveGame(Game1 game, string @folderPath)
        {
            CreateFolder(@folderPath);
            SaveRooms(game, folderPath);
        }

        private static void CreateFolder(string @folderPath)
        {
            try
            {
                if (Directory.Exists(@folderPath))
                {
                    Console.WriteLine("This folder already exists. Please use another path or folder name.");
                    return;
                }

                DirectoryInfo dirInfo = Directory.CreateDirectory(@folderPath);
            }
            catch (Exception e)
            {
                Console.WriteLine("Failed to save game: ", e.ToString());
            }
        }

        private static void SaveRooms(Game1 game, string @folderPath)
        {
            for (int i = 0; i < game.NumRooms; i++)
            {
                SaveRoom(game.Rooms[i], @folderPath);
            }
        }

        private static void SaveRoom(Room room, string @folderPath)
        {
            string path = folderPath + "/Room" + room.RoomIndex + ".xml";
            try
            {
                using FileStream fs = File.Create(path);
                byte[] info = new UTF8Encoding(true).GetBytes("This is some text in the file.");
                // Add some information to the file.
                fs.Write(info, 0, info.Length);
            }
            catch (Exception e)
            {
                Console.WriteLine("Failed to save game: " + e.ToString());
            }
        }
    }
}
