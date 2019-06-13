using System;
using System.Collections.Generic;
using System.Text;

namespace lp1_project2
{
    /// <summary>
    /// Shuffler class that contains generic static shuffle functions for 
    /// any required collection to shuffle.
    /// </summary>
    static class Shuffle
    {
        /// <summary>
        /// Shuffles the objects of a defined type T List-able.
        /// </summary>
        /// <typeparam name="T"> Type of the list to be shuffled</typeparam>
        /// <param name="list"> List to be shuffled</param>
        public static void ShuffleList<T>(IList<T> list)
        {
            Random r = new Random();
            int rndIndex = 0;

            // Verify if list can be shuffled
            if (list.Count > 1)
            {

                // Iterate over list and shuffle it
                for (int i = 0; i < list.Count; i++)
                {
                    // Helper T variable
                    T tempGeneric = list[i];
                    rndIndex = r.Next(list.Count);

                    // Swap the object
                    list[i] = list[rndIndex];
                    list[rndIndex] = tempGeneric;
                }
            }
        }

    }
}
