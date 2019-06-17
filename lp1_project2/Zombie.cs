using System;
using System.Collections.Generic;
using System.Text;

namespace lp1_project2
{
    class Zombie : Agent, IBoardActionable
    {
        public Zombie(byte tag, Position position, bool input) :
            base(tag, input, Faction.Zombie)
        {
            this.position = position;
        }


        public void Action(Tile t, Position newPos, Board gameBoard)
        {
            if(t.occupier == null) 
            {
                gameBoard.realBoard[position.X, position.Y].occupier = null;
                position += newPos;
                gameBoard.realBoard[position.X, position.Y].occupier = this;
                
            }
            else if(t.occupier.AgentFaction == Faction.Human) 
            {
                gameBoard.ConvertHuman(t.occupier as Human);
                
            }
                


        }

        public override string ToString()
        {
            return $"{Tag:X2}";
        }
    }
}
