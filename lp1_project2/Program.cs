using System;

namespace lp1_project2
{
    class Program
    {
        static void Main(string[] args)
        {
            Board b = new Board(20, 30, 10, 12, 2, 0);

            // this prints out a bunch of 0,0 an di'm not sure why?
            foreach(Agent h in b.agentsList) {Console.WriteLine(h.position);}
            
          
            /* 
            // This is a test
            SaveFileManager gameSaver;

            // Asks if the player wants to load in a saved game
            Console.WriteLine("Would you like to use the last saved game?" +
                " Y|N");
            gameSaver = new SaveFileManager
                (Console.ReadLine().Equals("Y") ? true : false);

            // Create a settings file with the arguments passed
            gameSaver.CreateGameSettingsFile(args);

            // This method asks if the player wants to save the game and then
            // saves it if that's the case
            gameSaver.SaveGame();

            // Reads any value with a given char KEY from the current game state
            Console.WriteLine(FileReader.ReadFromFile('Z'));

            // Deletes the current game file for another game
            gameSaver.ClearCurrentGame();*/
        }
    }
}
