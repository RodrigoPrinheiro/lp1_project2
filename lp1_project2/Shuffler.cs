using System;
using System.Collections.Generic;
using System.Text;

namespace lp1_project2
{
    static class Shuffler
    {
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
