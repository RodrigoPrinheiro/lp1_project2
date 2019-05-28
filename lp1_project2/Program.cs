using System;

namespace lp1_project2
{
    class Program
    {
        static void Main(string[] args)
        {
            // This is a test
            SaveFileManager gameSaver;

            Console.WriteLine("Would you like to use the last saved game?" +
                " Y|N");
            gameSaver = new SaveFileManager
                (Console.ReadLine().Equals("Y") ? true : false);

            gameSaver.CreateGameSettingsFile(args);
            gameSaver.SaveGame();
            gameSaver.ClearCurrentGame();
        }
    }
}
