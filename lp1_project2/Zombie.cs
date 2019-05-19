using System;
using System.Collections.Generic;
using System.Text;

namespace lp1_project2
{
    class Zombie : Agent
    {
        public Zombie(byte tag, Position position, bool input) :
            base(tag, input)
        {
            this.position = position;
            Faction = ConsoleColor.Red;
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
