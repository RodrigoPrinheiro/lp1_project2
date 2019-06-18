using System;
using System.Collections.Generic;
using System.Threading;


namespace lp1_project2
{
    /// <summary>
    /// Contains the logic for the Game, this means menus, loop and StartUp.
    /// </summary>
    class Game
    {
        private Board board;
        private PathFinder bStar;
        private SaveFileManager gameSaver;
        private List<Agent> turnOrder;
        private int totalTurns;
        

        public Game(string[] args)
        {
            // Boot up the game save
            Console.WriteLine("Would you like to use the last saved game?" +
                " Y|N");

            gameSaver = new SaveFileManager
                (Console.ReadLine().Equals("Y") ? true : false);

            //gameSaver.ReadSave(saveBoard);
            if (!gameSaver.UsingSave)
            {
                BuildBoard(args);
                totalTurns = GetValueFromArgs(args, 't');
            }

            bStar = new PathFinder(board.Width, board.Height);
        }

        /// <summary>
        /// Builds the game board with the arguments passed in the console.
        /// </summary>
        /// <param name="args"></param>
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
            MainMenu.Menu();
            Continue();
            GameLoop();

            Console.ReadKey();
        }

        /// <summary>
        /// Main loop of the game
        /// </summary>
        private void GameLoop()
        {
            turnOrder = new List<Agent>();
            while (true)
            {
                // Shuffle the agent list

                // Use a local list to avoid changing it while we're iterating
                // trough it
                turnOrder.Clear();
                turnOrder.AddRange(board.agentsList);
                Shuffle.ShuffleList<Agent>(turnOrder);

                // go down the turn order
                foreach(Agent a in turnOrder)
                {
                    // No use searching for enemies if one side is all dead
                    if (board.GetHumanCount() == 0) break;
                  
                    Agent b = bStar.GetNearest(board.agentsList, a);



                    GameRender(a);
                    Position newPosition = new Position();
                    if(a.InputControlled) 
                    {
                        Console.WriteLine("Input Movement:");
                        ConsoleKeyInfo input = Console.ReadKey();
                        newPosition = InputCheck(input.Key);
                    
                    }
                    else
                    {
                        newPosition = 
                            bStar.GetNextStepTowards(a.position, b.position);
                    }

                    if(a as Human != null) 
                        (a as Human).Action(board.realBoard, newPosition);
                    else if (a as Zombie != null)
                        (a as Zombie).Action(board.realBoard, newPosition, board);

                    GameRender(a);
                    Console.WriteLine($"Closest NPC: {b}");
                    Thread.Sleep(500);
                }

                Console.WriteLine();
                Console.WriteLine("Press <escape> any time to leave...");

                if (Console.ReadKey().Key == ConsoleKey.Escape)
                {
                    Console.WriteLine("Left the game...");
                    break;
                }
                else if (board.Turns <= 0)
                {
                    Console.WriteLine("Humans Win!!");
                    break;
                }
                else if (board.GetHumanCount() == 0)
                {
                    Console.WriteLine($"Zombies Win!! Won in: " +
                        $"{totalTurns - board.Turns}");
                    break;
                }
                // Decrement turns and wait 1 second for next turn.
                board.Turns--;
                Thread.Sleep(1000);
            }
        }

        /// <summary>
        /// Renders the whole game calling Render class
        /// </summary>
        /// <param name="currentAgent"></param>
        private void GameRender(Agent currentAgent)
        {
            Console.Clear();
            Render.Board(board.realBoard, currentAgent);
            Console.WriteLine($"Current NPC moving: {currentAgent}");

            if (currentAgent.InputControlled)
            {
                Console.WriteLine("NPC is Controllable, " +
                    "Awaiting your Input Master!");
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

        /// <summary>
        /// Translates the player input into coordinates.
        /// </summary>
        /// <param name="input">
        /// Player input
        /// </param>
        /// <returns>
        /// Returns the position of the next step.
        /// </returns>
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
                p.Y = 1;
                break;

                // Up
                case ConsoleKey.W:
                p.Y = -1;
                break;

                // Top-Left
                case ConsoleKey.Q:
                p.X = -1;
                p.Y = -1;
                break;

                // Top-Right
                case ConsoleKey.E:
                p.X = 1;
                p.Y = -1;
                break;

                // Bottom-Left
                case ConsoleKey.Z:
                p.X = -1;
                p.Y = 1;
                break;

                // Bottom-Right
                case ConsoleKey.C:
                p.X = 1;
                p.Y = 1;
                break;

                default:
                Console.WriteLine("Invalid input");
                break;
            }

            Console.Write($"{input}, goes {p}");
            return p;

        }

        /// <summary>
        /// Searches for a specific key in arguments and gets its value. <br>
        /// Arguments can be in any order.
        /// </summary>
        /// <param name="args"></param>
        /// <param name="key"></param>
        /// <returns></returns>
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
