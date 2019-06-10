using System;
using System.Collections.Generic;
using System.Text;

namespace lp1_project2
{
    static public class Render
    {
        public static void Board(Tile[,] board)
        {
            // Get the rows and cols of the board
            int rows = board.GetLength(0);
            int cols = board.GetLength(1);

            // Print top of the board
            for (int i = 0; i < rows; i++)
                Console.Write($"{i + 1, -4}");
            Console.WriteLine();
            for (int i = 0; i < rows; i++)
                Console.Write($"....");

            // Print the board
            for (int i = 0; i < rows; i++)
            {
                // Row number
                Console.Write($"{i + 1}:");
                for (int j = 0; j < cols; j++)
                {
                    Console.Write(board[i, j]);
                }

                // Next line
                Console.WriteLine();
            }
        }
    }
}
