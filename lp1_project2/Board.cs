using System.Collections.Generic;
using System;

namespace lp1_project2
{
    class Board
    {

        public int RealWidth {get; private set;}
        public int RealHeight {get; private set;}

        Tile[,] realBoard;

        Position[][] humanSimPositions;
        Position[][] zombieSimPositions;

        List<Human> humansList;
        List<Zombie> zombiesList;

        public Board(int width, int height, int nZ, int nH, int controllableZ, int controllableH)
        {

            RealWidth = width;
            RealHeight = height;

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

    }
}