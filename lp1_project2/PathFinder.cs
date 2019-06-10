using System;

namespace lp1_project2
{
    /// <summary>
    /// Pathfinder class uses a position and searches for the closest path in
    /// a list of zombies, humans, or positions
    /// </summary>
    static class PathFinder
    {
        
        /// <summary>
        /// Go trough the positions of all the enemies. And return the nearest to the origin point.
        /// This should use the big simulation map
        /// </summary>
        /// <param name="originPoint"> The starting point of the search</param>
        /// <param name="opponentsList"> The list with all the positions that are potential targets.</param>
        /// <returns></returns>
        public static Position FindNearest(Position originPoint, Position[] opponentsList)       
        {
            Position  NearestEnemy = new Position();

            // Make sure delta'll always be smaller
            float distanceToNearest = float.MaxValue;

            foreach (Position p in opponentsList)
            {   

                // Distance between 2 points:
                // x^2 + y^2 = d^2
                float delta = MathF.Sqrt(
                MathF.Pow(p.X - originPoint.X, 2) + 
                MathF.Pow(p.Y - originPoint.Y, 2) );

                // Update the variables to always reflect who's closest
                // to the origin
                if (delta < distanceToNearest) 
                {
                    NearestEnemy = p;
                    distanceToNearest = delta;
                }

            }

            return NearestEnemy;

        }

        /// <summary>
        /// Evaluate the diferences in coordinates between the origin and the target on each individual axis, and return position diference between the origin and its next logical location.
        /// </summary>
        /// <param name="origin">The starting position</param>
        /// <param name="target">The position of what we want to compare against </param>
        /// <param name="approach">Whether the agent in the origin wants to approach or run away from the agent in the target position</param>
        /// <returns></returns>
        public static Position GetNextStep(Position origin, Position target, bool approach)
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
            if(approach) return nextStep;
            else return new Position(-nextStep.X, -nextStep.Y);

        }

        // TODO: possible issue if human runs away next to another zombie? 
        // Not sure if we want to avoid this beahviour
        // I dont think we do since the agent that will move is picked randomly
        // and if you pick the closest one then he behaves accordingly for that one
        // if he ends up closer to a new zombie then fuck it, he put himself in that situation.

    }
}