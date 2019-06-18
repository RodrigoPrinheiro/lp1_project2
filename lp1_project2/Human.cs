using System;
using System.Collections.Generic;
using System.Text;

namespace lp1_project2
{
    /// <summary>
    /// Represents a Human NPC and his respective movement behavior.
    /// </summary>
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
        /// <param name="t">tile that it is going to move to</param>
        /// <param name="newPos"> NextStep given by pathfinder</param>
        public void Action(Tile[,] t, Position newPos, Board gameB = null)
        {

            int upperX = t.GetLength(0) - 1;
            int upperY = t.GetLength(1) - 1;

            if (InputControlled)
            {
                if (position.X + newPos.X > upperX) newPos.X = -(upperX);
                else if (position.X + newPos.X < 0) newPos.X = upperX;

                if (position.Y + newPos.Y > upperY) newPos.Y = -(upperY);
                else if (position.Y + newPos.Y < 0) newPos.Y = upperY;



                if (t[position.X + newPos.X, position.Y + newPos.Y].occupier == null)
                {
                    t[position.X, position.Y].occupier = null;
                    position += newPos;
                    t[position.X, position.Y].occupier = this;

                }

            }
            else if (!InputControlled)
            {
                // Check bounds, send the agent around if bounds are going to be
                // crossed
                if (position.X - newPos.X > upperX) newPos.X = (upperX);
                else if (position.X - newPos.X < 0) newPos.X = -upperX;

                if (position.Y - newPos.Y > upperY) newPos.Y = (upperY);
                else if (position.Y - newPos.Y < 0) newPos.Y = -upperY;


                if (t[position.X - newPos.X, position.Y - newPos.Y].occupier == null)
                {
                    t[position.X, position.Y].occupier = null;
                    position -= newPos;
                    t[position.X, position.Y].occupier = this;
                }

            }


        }

        public override string ToString()
        {
            return $"{Tag:X2}";
        }
    }
}
