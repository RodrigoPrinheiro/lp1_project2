using System;
using System.Collections.Generic;
using System.Text;

namespace lp1_project2
{
    class Human : Agent
    {

        public Human(byte tag, Position position, bool input) : 
            base(tag, input, Faction.Human)
        {
            this.position = position;
        }

        public override string ToString()
        {
            return $"{Tag}";
        }
    }
}
