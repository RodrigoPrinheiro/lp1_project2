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


            /*
                ====THE ANCIENT 4-WAY MAP POSITION SIMULATION TECHNIQUE=====

                Each agent has it's own position, but the board gives it 4 more.
                That's the positions corresponding to an entire new board,
                exactly one board of distance away, 
                in each of the cardinal directions.

                We essentially get the positions of 1 agent in 5 different
                spots, all with a strict relation to each other.

                The agents and board will use all these locations for 
                their AI but on-screen it will be presented the real board
                with the size specified by the user and all agents will be
                (after every simulation cycle) put into the right 
                corresponding tile on the real map (that is if they left at all.

                !   The conversion might not be strictly necessary, by just
                    using positions like we've done bellow and in pathfidner.cs
                    this method theoretically  creates and "infinite" simulation
                    space and kinda doesn't need to be put in the original map.

                    Dunno how the renderer would deal with that tough.
                    So maybe converting would be best anyway.

                                    ¯\_(ツ)_/¯

                ==================ITS JUST WORKS=========================              
             */




        // Width and Height of the real board, shown on screen.
        public int Width {get; private set;}
        public int Height {get; private set;}
        public Tile[,] realBoard {get; private set;}

        // Dictionary that stores each agent on either faction as keys
        // and then its 5 positions (its real positions and 4 simulated ones)
        // as values for each agent
        public Dictionary<Human, Position[]> humanSimPositions;
        public Dictionary<Zombie, Position[]> zombieSimPositions;

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
        public Board(int width, int height, int nZ, int nH, int controllableZ, int controllableH)
        {

            Width = width;
            Height = height;

            humansList = new List<Human>();
            zombiesList = new List<Zombie>();
            agentsList = new List<Agent>();

            humanSimPositions = new Dictionary<Human, Position[]>();
            zombieSimPositions = new Dictionary<Zombie, Position[]>();

            realBoard = new Tile[width, height];
            for(int x = 0; x < realBoard.GetLength(0); x++)
            {
                for(int y = 0; y < realBoard.GetLength(1); y++)
                {

                    realBoard[x,y] = new Tile(x,y);
                    
                }     

            }


            // Make the seperate zombie and human lists
            zombiesList.AddRange(MakeAgentList<Zombie>(nZ, controllableZ));
            humansList.AddRange(MakeAgentList<Human>(nH, controllableH));

            // join them in one big list for the simulator to use in turn order
            agentsList.AddRange(zombiesList);
            agentsList.AddRange(humansList);   

            // Populate the Tiles
            PopulateTiles();


            // Update all the positions to be useable by the simulation 
            UpdateSimPositionsDictionary(Faction.Human);
            UpdateSimPositionsDictionary(Faction.Zombie);

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
        /// Fill in the dictionary with each agent and their corresponding 5 positions
        /// /(their position on the real board and the 4 simulated for pathfinding)
        /// </summary>
        /// <param name="faction"> Fill in the zombie or human Dictionary? </param>
        public void UpdateSimPositionsDictionary(Faction faction)
        {


            Position[] simPos = new Position[9];

            if(faction == Faction.Human)
            {

                foreach (Human h in humansList)
                {
                    // In Clockwise order, starting at the center and going right
                    simPos[0] = h.position;
                    simPos[1] = 
                    new Position(h.position.X + Width, h.position.Y);
                    simPos[2] = 
                    new Position(h.position.X + Width, h.position.Y - Height);
                    simPos[3] = 
                    new Position(h.position.X, h.position.Y - Height);
                    simPos[4] = 
                    new Position(h.position.X - Width, h.position.Y - Height);
                    simPos[5] =
                    new Position(h.position.X - Width, h.position.Y);
                    simPos[6] =
                    new Position(h.position.X - Width, h.position.Y + Height);
                    simPos[7] =
                    new Position(h.position.X, h.position.Y + Height);
                    simPos[8] =
                    new Position(h.position.X + Width, h.position.Y + Height);

                    humanSimPositions.Add(h, simPos);

                }
            }

            else if(faction == Faction.Zombie)
            {

                foreach (Zombie z in zombiesList)
                {
                    // In Clockwise order, starting at the center and going right
                    simPos[0] = z.position;
                    simPos[1] = 
                    new Position(z.position.X + Width, z.position.Y);
                    simPos[2] = 
                    new Position(z.position.X + Width, z.position.Y - Height);
                    simPos[3] = 
                    new Position(z.position.X, z.position.Y - Height);
                    simPos[4] = 
                    new Position(z.position.X - Width, z.position.Y - Height);
                    simPos[5] =
                    new Position(z.position.X - Width, z.position.Y);
                    simPos[6] =
                    new Position(z.position.X - Width, z.position.Y + Height);
                    simPos[7] =
                    new Position(z.position.X, z.position.Y + Height);
                    simPos[8] =
                    new Position(z.position.X + Width, z.position.Y + Height);

                    zombieSimPositions.Add(z, simPos);

                }
            }

        }

        /// <summary>
        ///  Convert all agent coords to valid ones, then set the occupiers on
        ///  all tiles
        /// </summary>
        public void PopulateTiles()
        {
        
            foreach(Agent a in agentsList)
            {

                a.position = ConvertToRealMapCoords(a.position);
                //Place them on tiles on the real board
                realBoard[a.position.X,a.position.Y].occupier = a;
            }


        }

        /// <summary>
        ///  Converts a Position to coordinates inside the real Board
        /// \
        ///  Thus making it fit inside the RealBoard Array of tiles.
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public Position ConvertToRealMapCoords(Position p)
        {
            Position newPos = p;
            int x = p.X;
            int y = p.Y;
                
            // Validate all positions
            if(x < 0) newPos.X = -x;
            if(y < 0) newPos.Y = -y;

            if(x > Width) newPos.X = x - Width;
            if(y > Height) newPos.Y = y -Height;

            realBoard[x, y].occupier = a;
            return newPos;

        }

        /// <summary>
        ///  Replace Human with Zombie on board
        /// </summary>
        /// <param name="h">Human to zombify</param>
        public void ConvertHuman(Human h) 
        {
            humansList.Remove(h);
            zombiesList.Add(new Zombie(h.Tag, h.position, false));
        }
    }

}