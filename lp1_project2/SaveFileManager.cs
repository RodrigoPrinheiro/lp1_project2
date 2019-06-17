using System;
using System.IO;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.Text;

namespace lp1_project2
{
    // http://www.jonasjohn.de/snippets/csharp/xmlserializer-example.htm
    // https://weblogs.asp.net/wim/213700

    /// <summary>
    /// Reads and translates the arguments given from the console.<br>
    /// Creates a GameSettings file to save the values passed in console.
    /// </summary>
    class SaveFileManager
    {
        // File paths for the current project folder
        private const string saveFile = @"GameSave.txt";
        private XmlSerializer serializedObj;

        /// <summary>
        /// Dictates if the player is using a save file or not
        /// </summary>
        public bool UsingSave { get; }

        // Constructor that gets the UsingSave property
        public SaveFileManager(bool useSave)
        {
            UsingSave = useSave;
            // serializedObj = new XmlSerializer(typeof(Board));
        }

        /// <summary>
        /// Checks if the save file exists, creates one and copies the current
        /// game state to the save file
        /// </summary>
        public void SaveGame(Board boardToSave)
        {
            bool shouldSaveGame;

            Console.WriteLine("Would you like to save current game State?" +
                " Y|N");
            shouldSaveGame = Console.ReadLine().Equals("Y") ? true : false;

            // If it should save the game check if there is a file to save to.
            if (shouldSaveGame)
            {
                TextWriter file = new StreamWriter(saveFile);
                serializedObj.Serialize(file, boardToSave);

                file.Close();
            }
        }

        public void ReadSave(Board gameBoard)
        {
            FileStream readFile = new FileStream
                (saveFile, FileMode.Open, FileAccess.Read, FileShare.Read);

            gameBoard = (Board)serializedObj.Deserialize(readFile);
        }
    }
}
