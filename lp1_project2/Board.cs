using System.Collections.Generic;
using System;

namespace lp1_project2
{
    /// <summary>
    /// Base class for the game board, controls the tiles and the place the
    /// pieces, making sure they have their correct positions considering the
    /// simulation
    /// </summary>
    class Board
    {
        public int Turns { get; set; }
        // Width and Height of the real board, shown on screen.
        public int Width {get; private set;}
        public int Height {get; private set;}
        public Tile[,] realBoard {get; private set;}

        // Dictionary that stores each agent on either faction as keys
        // and then its 5 positions (its real positions and 4 simulated ones)
        // as values for each agent

        List<Human> humansList;
        List<Zombie> zombiesList;
        public List<Agent> agentsList;

        /// <summary>
        /// Base class for the game board, controls the tiles and the place the
        /// pieces, making sure they have their correct positions 
        /// considering the simulation
        /// </summary>
        /// <param name="width"> Width of the map</param>
        /// <param name="height"> Height of the map</param>
        /// <param name="nZ"> Starting number of Zombie agents on the board
        /// </param>
        /// <param name="nH"> Starting number of Human agents on the board
        /// </param>
        /// <param name="controllableZ">
        /// Number of Zombies controllable by player input
        /// </param>
        /// <param name="controllableH"> 
        /// Number of Zombies controllable by player input 
        /// </param>
        public Board(int width, int height, int nZ, int nH, int controllableZ, int controllableH, int turns)
        {

            Width = width;
            Height = height;

            Turns = turns;

            humansList = new List<Human>();
            zombiesList = new List<Zombie>();
            agentsList = new List<Agent>();

            realBoard = new Tile[width, height];
            for(int x = 0; x < realBoard.GetLength(0); x++)
            {
                for(int y = 0; y < realBoard.GetLength(1); y++)
                {

                    realBoard[x,y] = new Tile(x,y);
                }     
            }
            // Make the agent list
            agentsList.AddRange(MakeAgentList<Zombie>(nZ, controllableZ));
            agentsList.AddRange(MakeAgentList<Human>(nH, controllableH));   

            // Populate the Tiles
            PopulateTiles();
        }

        /// <summary>
        /// Returns an IEnumerable of Agents with the specified faction with a random valid position 
        /// </summary>
        /// <param name="n"> Total number of agents</param>
        /// <param name="inputCtrl"> Number of agents controllable by player input</param>
        /// <param name="faction"> Are they human or zombie? </param>
        /// <returns></returns>
        IEnumerable<T> MakeAgentList<T>(int n, int inputCtrl) where T : Agent
        {
            Position newPos = new Position();
            Random rX = new Random();
            Random rY = new Random();

            int ctrlCounter = 0;
            int counter = 0;
            while(counter < n)
            {

                newPos.X = rX.Next(0,realBoard.GetLength(0));
                newPos.Y = rY.Next(0, realBoard.GetLength(1));

                if(realBoard[newPos.X, newPos.Y].occupier == null)
                {
                    if (typeof(T).Equals(typeof(Human))) 
                    {
                        yield return 
                            new Human(
                                (byte)rX.Next(), 
                                newPos,
                                ctrlCounter < inputCtrl) as T;
                    }

                    else if(typeof(T).Equals(typeof(Zombie)))
                    {
                        yield return 
                            new Zombie(
                                (byte)rX.Next(), 
                                newPos,
                                ctrlCounter < inputCtrl) as T;


                    }

                }

                ctrlCounter++;
                counter ++;

            }
        }

        /// <summary>
        ///  Usefull for the first run.
        /// </summary>
        public void PopulateTiles()
        {
            foreach(Agent a in agentsList)
            {
                //Place them on tiles on the real board
                realBoard[a.position.X,a.position.Y].occupier = a;
            }
        }

        /// <summary>
        ///  Replace Human with Zombie on board
        /// </summary>
        /// <param name="h">Human to zombify</param>
        public void ConvertHuman(Human h) 
        {
            agentsList.Remove(h);
            agentsList.Add(new Zombie(h.Tag, h.position, false));
        }

        public Position ConvertPositionToBoardCoord(ref Position pos)
        {
            if (pos.X > Width) pos.X = 0;
            if (pos.Y > Height) pos.Y = 0;

            return pos;
        }
    }

}