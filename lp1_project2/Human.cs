using System;
using System.Collections.Generic;
using System.Text;

namespace lp1_project2
{
    public class Human : Agent
    {

        public Human(byte tag, Position position, bool input) : 
            base(tag, input)
        {
            this.position = position;
            Faction = ConsoleColor.Cyan;
        }

        public override Position Move()
        {
            
        }

        public override string ToString()
        {
            return $"{Tag}";
        }
    }
}
