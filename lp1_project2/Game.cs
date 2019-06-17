using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace lp1_project2
{
    class Game
    {
        private Board board;
        private PathFinder bStar;
        private SaveFileManager gameSaver;

        

        public Game(string[] args)
        {
            // Boot up the game save
            Console.WriteLine("Would you like to use the last saved game?" +
                " Y|N");

            gameSaver = new SaveFileManager
                (Console.ReadLine().Equals("Y") ? true : false);

            foreach (string s in args)
            {
                Console.WriteLine($"{s} ");
            }

            //gameSaver.ReadSave(saveBoard);
            if (!gameSaver.UsingSave)
            {
                BuildBoard(args);

            }
            //else
            //{
            //    if (saveBoard.GameBoard != null)
            //        board = saveBoard.GameBoard;
            //    else
            //        BuildBoard(args);
            //}

            bStar = new PathFinder(board.Width, board.Height);
        }

        private void BuildBoard(string[] args)
        {
            // Get all values from the current game file
            int width, height, nZ, nH, controllableZ, controllableH, turns;
            width = GetValueFromArgs(args, 'x');
            height = GetValueFromArgs(args, 'y');
            nZ = GetValueFromArgs(args, 'z');
            nH = GetValueFromArgs(args, 'h');
            controllableZ = GetValueFromArgs(args, 'Z');
            controllableH = GetValueFromArgs(args, 'H');
            turns = GetValueFromArgs(args, 't');

            board = new Board(width, height, nZ, nH, controllableZ, controllableH, turns);
        }

        /// <summary>
        /// Function called on Program class in Main to run the game
        /// </summary>
        public void Run()
        {
            Render.Board(board.realBoard);
            Continue();
            GameLoop();
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
                    Position newPosition = new Position();
                    if(a.InputControlled) 
                    {
                        
                        ConsoleKeyInfo input = Console.ReadKey();
                        newPosition = InputCheck(input.Key);
                    
                    }
                    else
                    {
                        Agent b = bStar.GetNearest(board.agentsList, a);
                        newPosition = 
                            bStar.GetNextStepTowards(a.position, b.position);
                        
                    }

                    if(a as Human != null) 
                        (a as Human).Action(board.realBoard, newPosition);
                    else if (a as Zombie != null)
                        (a as Zombie).Action(board.realBoard, newPosition, board);

                    Render.Board(board.realBoard);
                    // controls the speed at which agents do their thing
                    Thread.Sleep(2000);
                }

                board.Turns--;
                // Isn't the program supposed to go automaticly if there are no
                // no controllable agents ?
                Continue();
                if (Console.ReadKey().Key == ConsoleKey.Escape) break;
                else if (board.Turns <= 0) break;
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

        private Position InputCheck(ConsoleKey input)
        {
            Position p = new Position();

            // WAXD for cardinal directions
            // Q E and Z C for diagonals
            switch(input)
            {
                // Right
                case ConsoleKey.D:
                p.X = 1;
                break;
                            
                // Left
                case ConsoleKey.A:
                p.X = -1;
                break;

                // Down
                case ConsoleKey.X:
                p.Y = -1;
                break;

                // Up
                case ConsoleKey.W:
                p.Y = 1;
                break;

                // Top-Left
                case ConsoleKey.Q:
                p.X = -1;
                p.Y = 1;
                break;

                // Top-Right
                case ConsoleKey.E:
                p.X = 1;
                p.Y = 1;
                break;

                // Bottom-Left
                case ConsoleKey.Z:
                p.X = -1;
                p.Y = -1;
                break;

                // Bottom-Right
                case ConsoleKey.C:
                p.X = 1;
                p.Y = -1;
                break;

                default:
                Console.WriteLine("Invalid input");
                break;
            }            

            return p;

        }

        private int GetValueFromArgs(string[] args, char key)
        {
            for (int i = 0; i < args.Length; i++)
            {
                if (args[i].Contains(key))
                {
                    return Convert.ToInt32(args[i + 1]);
                }
            }

            return 0;
        }
    }
}
