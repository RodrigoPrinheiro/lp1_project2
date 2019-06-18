namespace lp1_project2
{
    /// <summary>
    /// Absolute unit of the board.
    /// </summary>
    sealed class Tile
    {

        /// <summary>
        /// Current agent that is on this tile.
        /// </summary>
        public Agent occupier;

        public Tile()
        {
            occupier = null;
        }

        public override string ToString()
        {
            return occupier.ToString();
        }
    }
}