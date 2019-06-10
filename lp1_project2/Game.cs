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

            GameSaverStartUp(args);

            // Get all values from the current game file
            int width, height, nZ, nH, controllableZ, controllableH;
            width = FileReader.GetValue('x');
            height = FileReader.GetValue('y');
            nZ = FileReader.GetValue('z');
            nH = FileReader.GetValue('h');
            controllableZ = FileReader.GetValue('Z');
            controllableH = FileReader.GetValue('H');
            turns = FileReader.GetValue('t');

            // Build the board
            board = new Board(width, height, nZ, nH, controllableZ, controllableH);
        }
        private void GameSaverStartUp(string[] args)
        {
            Render.Board(board.realBoard);
            // This method asks if the player wants to save the game and then
            // saves it if that's the case
            gameSaver.SaveGame();
        }

        public void Run()
        {
            // Reads any value with a given char KEY from the current game state
            Console.WriteLine(FileReader.GetValue('Z'));

            // Deletes the current game file for another game, ends game
            gameSaver.ClearCurrentGame();
        }
    }
}
