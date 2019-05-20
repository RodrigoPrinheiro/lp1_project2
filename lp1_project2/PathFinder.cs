using System;

namespace lp1_project2
{
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
                float delta = MathF.Sqrt(
                MathF.Pow(p.X - originPoint.X, 2) + 
                MathF.Pow(p.Y - originPoint.Y, 2) );

                if (delta < distanceToNearest) 
                {
                    NearestEnemy = p;
                    distanceToNearest = delta;
                }

            }

            return NearestEnemy;

        }

    }
}