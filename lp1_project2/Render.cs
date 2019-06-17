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
            int cols = board.GetLength(0);
            int rows = board.GetLength(1);

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
                    if (board[j, i].occupier != null)
                    {
                        PickConsoleForeground(board[j, i].occupier);
                        Console.Write($"{board[j, i],-4}");
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
                Console.ForegroundColor = ConsoleColor.Cyan;

        }
    }
}
