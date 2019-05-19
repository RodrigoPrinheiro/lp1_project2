using System;
using System.Collections.Generic;
using System.Text;

namespace lp1_project2
{
    public abstract class Agent : ITaggable
    {
        // Tag in Hexadecimal
        public byte Tag { get;}

        // Color to be printed in the board for this agent
        protected ConsoleColor Faction { get; set; }

        // Position of the agent, x,y position
        protected Position position;

        // If they are controllable 
        protected bool InputControlled { get; }

        public Agent(byte tag, bool input)
        {
            Tag = tag;
            InputControlled = input;
        }

        // Path-finding, uses static Class Path-Finding

        // Movement, uses Path-Finding function
        public abstract Position Move();

        public override string ToString()
        {
            return $"Pos: {position} \n Controlled: {InputControlled}";
        }
    }
}
