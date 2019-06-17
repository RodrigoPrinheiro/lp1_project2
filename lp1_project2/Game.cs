using System;
using System.Collections.Generic;
using System.Text;

namespace lp1_project2
{
    class Game
    {
        private Board board;
        private SaveFileManager gameSaver;
        private int turns;

        

        public Game(string[] args)
        {
            // Boot up the game save
            Console.WriteLine("Would you like to use the last saved game?" +
                " Y|N");

            gameSaver = new SaveFileManager
                (Console.ReadLine().Equals("Y") ? true : false);

            gameSaver.CreateGameSettingsFile(args);
            gameSaver.SaveGame();
            // Get all values from the current game file
            int width, height, nZ, nH, controllableZ, controllableH;
            width = FileReader.GetValue('x');
            height = FileReader.GetValue('y');
            nZ = FileReader.GetValue('z');
            nH = FileReader.GetValue('h');
            controllableZ = FileReader.GetValue('Z');
            controllableH = FileReader.GetValue('H');
            turns = FileReader.GetValue('t');
            
            // DEBUG
            Console.WriteLine($"{width}\n{height}\n{nZ}\n{nH}\n{controllableZ}\n{controllableH}");
            // DEBUG
            
            // Build the board
            board = new Board(width, height, nZ, nH, controllableZ, controllableH);
        }

        /// <summary>
        /// Function called on Program class in Main to run the game
        /// </summary>
        public void Run()
        {
            Render.Board(board.realBoard);
            // Deletes the current game file for another game, ends game
            gameSaver.ClearCurrentGame();
        }

        /// <summary>
        /// Main loop of the game
        /// </summary>
        private void GameLoop()
        {
            while (true)
            {
                // Shuffle the agent list
                Shuffle.ShuffleList<Agent>(board.agentsList);

                // go down the turn order
                foreach(Agent a in board.agentsList)
                {

                    if(a.InputControlled) 
                    {
                        Position newPosition = new Position();
                        ConsoleKeyInfo input = Console.ReadKey();

                        // WAXD for cardinal directions
                        // Q E and Z C for diagonals
                        switch(input.Key)
                        {
                            // Right
                            case ConsoleKey.D:
                            newPosition.X = 1;
                            break;
                            
                            // Left
                            case ConsoleKey.A:
                            newPosition.X = -1;
                            break;

                            // Down
                            case ConsoleKey.X:
                            newPosition.Y = -1;
                            break;

                            // Up
                            case ConsoleKey.W:
                            newPosition.Y = 1;
                            break;

                            // Top-Left
                            case ConsoleKey.Q:
                            newPosition.X = -1;
                            newPosition.Y = 1;
                            break;

                            // Top-Right
                            case ConsoleKey.E:
                            newPosition.X = 1;
                            newPosition.Y = 1;
                            break;

                            // Bottom-Left
                            case ConsoleKey.Z:
                            newPosition.X = -1;
                            newPosition.Y = -1;
                            break;

                            // Bottom-Right
                            case ConsoleKey.C:
                            newPosition.X = 1;
                            newPosition.Y = -1;
                            break;


                        }


                    }
                    else
                    {


                        
                    }

                }

                Continue();
                if (Console.ReadKey().Key == ConsoleKey.Escape) break;
            }
        }

        /// <summary>
        /// Quality of life method so Console.WriteLine isn't repeated multiple
        /// times
        /// </summary>
        private void Continue()
        {
            Console.WriteLine("Press <Enter> to continue...");
            Console.ReadKey();
        }
    }
}
