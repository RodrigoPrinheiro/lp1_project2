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
        private const string currentGame = @"CurrentGameSave.txt";

        public static int ReadFromFile(char key)
        {
            string line;
            using (StreamReader file = new StreamReader(currentGame))
            {
                while ((line = file.ReadLine()) != null)
                {
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
