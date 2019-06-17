using System;
using System.Collections.Generic;
using System.Text;

namespace lp1_project2
{
    static class Render
    {
        public static void Board(Tile[,] board)
        {
            // Get the rows and cols of the board
            int rows = board.GetLength(0);
            int cols = board.GetLength(1);

            const char emptyTileChar = '.'; 
            Console.Write("   ");
            // Print top of the board
            for (int i = 0; i < rows; i++)
                Console.Write($"{i + 1, -4}");
            Console.WriteLine();
            Console.Write("   " +
                "");
            for (int i = 0; i < rows; i++)
                Console.Write($"....");

            Console.WriteLine();
            // Print the board
            for (int i = 0; i < rows; i++)
            {
                Console.WriteLine("  :");
                // Row number
                Console.Write($"{i + 1, -2}: ");
                for (int j = 0; j < cols; j++)
                {
                    if (board[i, j].occupier != null)
                    {
                        PickConsoleForeground(board[i, j].occupier);
                        Console.Write($"{board[i, j],-4}");
                        Console.ResetColor();
                    }
                    else
                        Console.Write($"{emptyTileChar, -4}");
                }

                // Next line
                Console.WriteLine();
            }
        }

        private static void PickConsoleForeground(Agent occupier)
        {
            if (occupier.AgentFaction == Faction.Zombie)
                Console.ForegroundColor = ConsoleColor.Red;
            else
                Console.ForegroundColor = ConsoleColor.Yellow;

        }
    }
}
