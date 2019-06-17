﻿using System;
using System.Collections.Generic;
using System.Text;

namespace lp1_project2
{
    /// <summary>
    /// Represents a Zombie NPC and his respective movement behavior.
    /// </summary>
    class Zombie : Agent, IBoardActionable
    {
        public Zombie(byte tag, Position position, bool input) :
            base(tag, input, Faction.Zombie)
        {
            this.position = position;
        }

        /// <summary>
        /// Moves this agent in a certain direction by 1.
        /// </summary>
        /// <param name="t">
        /// tile array from Board representing game board.
        /// </param>
        /// <param name="newPos">
        /// The new position that this agent should move to.
        /// </param>
        /// <param name="gameBoard">
        /// Board 
        /// </param>
        public void Action(Tile[,] t, Position newPos, Board gameBoard)
        {
            if(t[position.X + newPos.X,position.Y + newPos.Y].occupier == null) 
            {
                t[position.X, position.Y].occupier = null;
                position += newPos;
                t[position.X, position.Y].occupier = this;
                
            }
            else if(t[position.X + newPos.X, position.Y + newPos.Y].occupier.AgentFaction 
                == Faction.Human) 
            {
                gameBoard.ConvertHuman(t[position.X + newPos.X, position.Y + newPos.Y].occupier as Human);
                
            }
        }

        public override string ToString()
        {
            return $"{Tag:X2}";
        }
    }
}
