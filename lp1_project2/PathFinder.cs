using System;
using System.Collections.Generic;

namespace lp1_project2
{
    /// <summary>
    /// Pathfinder class uses a position and searches for the closest path in
    /// a list of zombies, humans, or positions
    /// </summary>
    class PathFinder
    {
        private int mapYSize;
        private int mapXSize;

        public PathFinder(int x, int y)
        {
            mapXSize = x;
            mapYSize = y;
        }

        /// <summary>
        /// Gets the nearest Agent from an original one
        /// </summary>
        /// <param name="agentList">
        /// List of agents where to search the nearest
        /// </param>
        /// <param name="currentAgent"> Origin agent</param>
        /// <returns> Returns the reference to the closest Agent</returns>
        public Agent GetNearest(IEnumerable<Agent> agentList, Agent currentAgent)
        {
            Agent closestAgent = null;
            double distance;
            double closestDistance = 0;

            foreach (Agent a in agentList)
            {
                if (a != currentAgent)
                {
                    distance = GetToroidalDistance(currentAgent.position, a.position);

                    if (closestDistance > distance)
                    {
                        closestDistance = distance;
                        closestAgent = a;
                    }
                }
            }

            return closestAgent;
        }

        /// <summary>
        /// Evaluate the diferences in coordinates between the origin
        /// and the target on each individual axis, 
        /// and return position diference between the origin
        /// and its next logical location.
        /// </summary>
        /// <param name="origin">The starting position</param>
        /// <param name="target">The position of what we want to compare against </param>
        /// <param name="approach">Whether the agent in the origin wants to approach or run away from the agent in the target position</param>
        /// <returns></returns>
        public static Position GetNextStepTowards(Position origin, Position target)
        {

            // Will be used as the return. 
            // Adding the x and y of this to the origin should work to get
            // movement
            Position nextStep = new Position(0,0);

            int deltaX = target.X - origin.X;
            int deltaY = target.Y - origin.Y;

            // First verify whether the difference in positions is 
            // greater on the X or Y axis.
            // Then check if the target is lower/higher/forwards/backwards
            if (MathF.Pow(deltaX, 2) > MathF.Pow(deltaY, 2))
            {
                if (deltaX > 0) nextStep.X = 1;
                else if (deltaX < 0) nextStep.X = -1;
            }
            else if (MathF.Pow(deltaY, 2) > MathF.Pow(deltaX, 2))
            {
                if (deltaY > 0) nextStep.Y = 1;
                else if (deltaY < 0) nextStep.Y = -1;
            }

           // If the difference in the X and Y axis are the same, 
           // move diagonaly
           // use CompareTo do decide what direction in specific.
           else if ((int)MathF.Pow(deltaX, 2) == (int)MathF.Pow(deltaY, 2))
           {
               nextStep.X = 1 * target.X.CompareTo(origin.X);
               nextStep.Y = 1 * target.Y.CompareTo(origin.Y);
           }

            // Oh? You approaching me?
            // Instead of running away you're coming right towards me?
            return nextStep;

        }

        /// <summary>
        /// Get's the distance between 2 agents in a toroidal map
        /// </summary>
        /// <param name="a1"> Position of the first Agent</param>
        /// <param name="a2"> Position of the second Agent</param>
        /// <param name="mapXSize"> Size X of the current map</param>
        /// <param name="mapYSize"> Size Y of the current map</param>
        /// <returns> Returns the distance between the 2 Agents</returns>
        private double GetToroidalDistance
            (Position a1, Position a2)
        {
            float dx = MathF.Abs(a2.X - a1.X);
            float dy = MathF.Abs(a2.Y - a1.Y);

            if (dx > mapXSize / 2) dx = mapXSize - dx;
            if (dy > mapYSize / 2) dy = mapXSize - dy;

            return Math.Sqrt(dx * dx + dy * dy);
        }
    }
}