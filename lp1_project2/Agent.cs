using System;
using System.Collections.Generic;
using System.Text;

namespace lp1_project2
{
    /// <summary>
    /// Agent class is the general idea for a basic unit in the game.
    /// </summary>
    abstract class Agent : ITaggable
    {
        // Tag in Hexadecimal. Aka the name of said agent
        public byte Tag { get; }

        /// <summary>
        /// Dictates if this Agent is a Zombie or a Human.
        /// </summary>
        public Faction AgentFaction { get; }

        // Position of the agent, x,y position
        public Position position { get; set; }

        /// <summary>
        /// Read only property that determines if the Agent is controllable.
        /// </summary>
        public bool InputControlled { get; private set; }

        public Agent(byte tag, bool input, Faction faction)
        {
            Tag = tag;
            InputControlled = input;
            AgentFaction = faction;
        }

        public override string ToString()
        {
            return $"{Tag:X2}";
        }
    }
}
