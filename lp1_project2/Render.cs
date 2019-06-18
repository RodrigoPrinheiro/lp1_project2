using System;
using System.Collections.Generic;
using System.Text;

namespace lp1_project2
{
    /// <summary>
    /// Renders the game board, it uses a Tile array board structure and the
    /// current agent that is being moved
    /// </summary>
    static class Render
    {
        /// <summary>
        /// Prints the whole game board
        /// </summary>
        /// <param name="board">
        /// Current Game Board.
        /// </param>
        /// <param name="currentAgent">
        /// Current agent moving.
        /// </param>
        public static void Board(Tile[,] board, Agent currentAgent = null)
        {
            // Get the rows and cols of the board
            int cols = board.GetLength(0);
            int rows = board.GetLength(1);

            const char emptyTileChar = '.';
            Console.Write("   ");
            // Print top of the board
            for (int i = 0; i < rows; i++)
                Console.Write($"{i + 1,-4}");
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
                Console.Write($"{i + 1,-2}: ");
                for (int j = 0; j < cols; j++)
                {
                    if (board[j, i].occupier != null)
                    {
                        if (board[j, i].occupier == currentAgent)
                            Console.BackgroundColor = ConsoleColor.DarkGray;
                        PickConsoleForeground(board[j, i].occupier);
                        Console.Write($"{board[j, i],-4}");
                        Console.ResetColor();
                    }
                    else
                        Console.Write($"{emptyTileChar,-4}");
                }

                // Next line
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Picks a foreground color determined by the tile occupier faction.
        /// </summary>
        /// <param name="occupier">
        /// Current Tile occupier.
        /// </param>
        private static void PickConsoleForeground(Agent occupier)
        {
            if (occupier.AgentFaction == Faction.Zombie)
                Console.ForegroundColor = ConsoleColor.Red;
            else
                Console.ForegroundColor = ConsoleColor.Cyan;

        }
    }
}
