using System;
using System.Collections.Generic;
using System.Text;

namespace lp1_project2
{
    /// <summary>
    /// Structure for a basic x,y position
    /// </summary>
    public struct Position
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Position(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public override string ToString() => $"Position: ({this.X},{this.Y})";
 
        public static Position operator +(Position p1, Position p2)
        {
            Position temp = new Position();
            temp.X = p1.X + p2.X;
            temp.Y = p1.Y + p2.Y;

            return temp;

        }

        public static Position operator -(Position p1, Position p2)
        {
            Position temp = new Position();
            temp.X = p1.X - p2.X;
            temp.Y = p1.Y - p2.Y;

            return temp;

        }

    }
}
