using System;
using System.Collections.Generic;
using System.Text;

namespace lp1_project2
{
    class Game
    {
        private Board board;
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
        }

        /// <summary>
        /// Main loop of the game
        /// </summary>
        private void GameLoop()
        {
            while (true)
            {
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
