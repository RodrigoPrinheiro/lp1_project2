using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace lp1_project2
{
    /// <summary>
    /// Reads the current game state file and translates it into usable
    /// information in the correct variable types.
    /// </summary>
    class FileReader
    {
        // File path, doesn't need any more files
        private const string currentGame = @"CurrentGameSave.ini";

        /// <summary>
        /// Reads from the current game save file and returns the value of a
        /// key value passed in it's parameters.
        /// </summary>
        /// <param name="key">
        /// Character of the key in which the value you want to get from the
        /// 'ini' file is tagged.
        /// </param>
        /// <returns> Returns the value of the asked key tag.</returns>
        public static int ReadFromFile(char key)
        {
            // Variable to save the current line read from the file.
            string line;

            // Creates a StreamReader for the file using the safe space with
            // the keyword 'using'
            using (StreamReader file = new StreamReader(currentGame))
            {
                // Searches every line in the file
                while ((line = file.ReadLine()) != null)
                {
                    // If the line has the correct Key then return it's value
                    string keyValue;
                    if (line[0].Equals(key))
                    {
                        keyValue = line.Trim(new char[] {' ', '=', key});
                        return Convert.ToInt32(keyValue);
                    }
                }
            }

            return 0;
        }
    }
}
