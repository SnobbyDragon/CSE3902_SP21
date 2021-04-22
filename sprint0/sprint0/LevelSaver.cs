using System;
using System.IO;
namespace sprint0
{
    public static class LevelSaver
    {
        public static void SaveGame(Game1 game, string @folderPath)
        {
            CreateFolder(@folderPath);
        }

        private static void CreateFolder(string @folderPath)
        {
            try
            {
                if (Directory.Exists(@folderPath))
                {
                    throw new ArgumentException("This folder already exists.");
                }

                DirectoryInfo dirInfo = Directory.CreateDirectory(@folderPath);
            }
            catch (Exception e)
            {
                Console.WriteLine("Failed to save game: ", e.ToString());
            }
        }
    }
}
