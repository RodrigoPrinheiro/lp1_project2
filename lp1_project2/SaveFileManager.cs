using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace lp1_project2
{
    /// <summary>
    /// Reads and translates the arguments given from the console.<br>
    /// Creates a GameSettings file to save the values passed in console.
    /// </summary>
    class SaveFileManager
    {
        // File paths for the current project folder
        private const string saveFile = @"GameSave.txt";
        private const string currentGame = @"CurrentGameSave.txt";

        /// <summary>
        /// Dictates if the player is using a save file or not
        /// </summary>
        public bool UsingSave { get; }

        // Constructor that gets the UsingSave property
        public SaveFileManager(bool useSave)
        {
            UsingSave = useSave;
        }

        /// <summary>
        /// Creates the current game save file, if the player picked to use
        /// the save file then copy the save file to the current game file
        /// </summary>
        /// <param name="args">
        /// Arguments passed in console to be copied to the save file
        /// </param>
        public void CreateGameSettingsFile(string[] args)
        {
            // Try/Catch block to debug and save use of files
            try
            {
                if (File.Exists(currentGame) && !UsingSave)
                {
                    File.Delete(currentGame);
                }
                else if (UsingSave)
                {
                    File.Copy(saveFile, currentGame, true);
                }

                using (StreamWriter fs = File.CreateText(currentGame))
                {
                    foreach (string s in args)
                    {
                        WriteLineToFile(fs, s);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        /// <summary>
        /// Checks if the save file exists, creates one and copies the current
        /// game state to the save file
        /// </summary>
        public void SaveGame()
        {
            bool shouldSaveGame;

            Console.WriteLine("Would you like to save current game State?" +
                " Y|N");
            shouldSaveGame = Console.ReadLine().Equals("Y") ? true : false;

            // If it should save the game check if there is a file to save to.
            if (shouldSaveGame)
            {
                if (File.Exists(currentGame) && !File.Exists(saveFile))
                {
                    File.Create(saveFile);
                }

                File.Copy(currentGame, saveFile, true);
            }
        }

        /// <summary>
        /// Cleans the current game file.<br>Called when the program exits.
        /// </summary>
        public void ClearCurrentGame()
        {
            if (File.Exists(currentGame))
                File.Delete(currentGame);
        }

        /// <summary>
        /// Simple File writer that excludes some characters of a given string
        /// before writing to the file.<br> This is only called inside the
        /// CreateGameSettingsFile() method, so no need to worry about the file
        /// variable type.
        /// </summary>
        /// <param name="file">
        /// File of type StreamWriter on where to write the given string.
        /// </param>
        /// <param name="str">
        /// String to be written to the file in a new line.
        /// </param>
        private void WriteLineToFile(StreamWriter file, string str)
        {
            string cleanString;
            cleanString = str.Trim(new Char[] { ' ', '-' });
            if (IsStringDigit(cleanString))
                file.WriteLine(cleanString);
            else
                file.Write(cleanString + " = ");

        }

        private bool IsStringDigit(string str)
        {
            for (int i = 0; i < str.Length; i++)
            {
                if (char.IsDigit(str[i]))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
