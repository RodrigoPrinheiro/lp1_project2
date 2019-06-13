using System;
using System.Collections.Generic;
using System.Text;

namespace lp1_project2
{
    class Human : Agent, IBoardActionable
    {

        public Human(byte tag, Position position, bool input) : 
            base(tag, input, Faction.Human)
        {
            this.position = position;
        }

        /// <summary>
        /// Runs away from the nearest enemy
        /// </summary>
        /// <param name="t">realBoard array from Board class</param>
        /// <param name="newPos"> NextStep given by pathfinder</param>
        public void Action(Tile t, Position newPos)
        {
            if(t.occupier == null) position -= newPos;

        }



        public override string ToString()
        {
            return $"{Tag:X2}";
        }
    }
}
