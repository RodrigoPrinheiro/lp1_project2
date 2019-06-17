using System;
using System.Collections.Generic;
using System.Threading;

namespace lp1_project2
{
    class Simulation
    {
        // Agent selectedAgent = null;
        Board gameBoard;

        List<Agent> orderedList = new List<Agent>();

       /* void Cycle()
        {
            // Shuffle the order of action for all agents

            // Run the pathfinder on the current agent
            foreach(Agent a in orderedList) 
            {
                // selectedAgent = a;

            
               Position nextStep = 
                PathFinder.GetNextStepTowards(a.position, nearestEnemy.Value);


                // The current agent acts according to what he got from     pathfinder
                Position convertedPos = 
                    gameBoard.ConvertToRealMapCoords(a.position);
                if(a.AgentFaction == Faction.Human)
                { 
                    (a as Human).Action(gameBoard.realBoard
                    [convertedPos.X,convertedPos.Y], nextStep);
                }
                else if(a.AgentFaction == Faction.Human)
                {
                    (a as Zombie).Action(gameBoard.realBoard
                    [convertedPos.X,convertedPos.Y], nextStep, gameBoard);
                }
                
                // Populate the tiles on board
                // gameBoard.PopulateTiles();


                //Code to wait
                Thread.Sleep(2000);

            }

        } */



    }
}