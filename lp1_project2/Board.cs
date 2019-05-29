using System.Collections.Generic;
using System;

namespace lp1_project2
{
    class Board
    {

        public int Width {get; private set;}
        public int Height {get; private set;}

        Tile[,] realBoard;

        Dictionary<Human, Position[]> humanSimPositions;
        Dictionary<Zombie, Position[]> zombieSimPositions;

        public List<Human> humansList;
        public List<Zombie> zombiesList;

        public Board(int width, int height, int nZ, int nH, int controllableZ, int controllableH)
        {

            Width = width;
            Height = height;

            humansList = new List<Human>();
            zombiesList = new List<Zombie>();

            realBoard = new Tile[width, height];
            for(int x = 0; x < realBoard.GetLength(0); x++)
            {
                for(int y = 0; y < realBoard.GetLength(1); y++)
                {

                    realBoard[x,y] = new Tile(x,y);
                    
                }     

            }

            zombiesList = MakeAgentList(nZ, controllableZ, Faction.Zombie) as List<Zombie>;

            humansList = MakeAgentList(nH, controllableH, Faction.Human) as List<Human>;      

            UpdateSimPositionsDictionary(Faction.Human);
            UpdateSimPositionsDictionary(Faction.Zombie);


        }

        IEnumerable<Agent> MakeAgentList(int n, int inputCtrl, Faction faction)
        {
            Position newPos = new Position(0,0);
            Random rX = new Random();
            Random rY = new Random();

            int ctrlCounter = 0;
            int counter = 0;
            while(counter < n)
            {

                newPos.X = rX.Next(0,realBoard.GetLength(0));
                newPos.Y = rY.Next(0, realBoard.GetLength(1));

                if(realBoard[newPos.X, newPos.Y] == null)
                {
                    if (faction == Faction.Human) 
                    {
                        yield return 
                            new Human(
                                (byte)rX.Next(), 
                                newPos,
                                ctrlCounter < inputCtrl);
                    }

                    else if(faction == Faction.Zombie)
                    {
                        yield return 
                            new Zombie(
                                (byte)rX.Next(), 
                                newPos,
                                ctrlCounter < inputCtrl);


                    }

                }
                else continue;

                ctrlCounter++;
                counter ++;

            }


        }

        void UpdateSimPositionsDictionary(Faction faction)
        {
            Position[] simPos = new Position[5];

            if(faction == Faction.Human)
            {

                foreach (Human h in humansList)
                {
                    // In Clockwise order, starting at the center and going right
                    simPos[0] = h.position;
                    simPos[1] = 
                    new Position(h.position.X + Width, h.position.Y);
                    simPos[2] = 
                    new Position(h.position.X, h.position.Y - Height);
                    simPos[3] = 
                    new Position(h.position.X - Width, h.position.Y);
                    simPos[4] = 
                    new Position(h.position.X, h.position.Y + Height);

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
                    new Position(z.position.X, z.position.Y - Height);
                    simPos[3] = 
                    new Position(z.position.X - Width, z.position.Y);
                    simPos[4] = 
                    new Position(z.position.X, z.position.Y + Height);

                    zombieSimPositions.Add(z, simPos);

                }
            }



        }

    }
}