namespace lp1_project2
{
    /// <summary>
    /// Absolute unit of the board.
    /// </summary>
    sealed class Tile
    {
        /// <summary>
        /// tile's position
        /// </summary>
        private Position boardPos {get;}

        /// <summary>
        /// Current agent that is on this tile.
        /// </summary>
        public Agent occupier;

        public Tile(int x, int y)
        {
            occupier = null;
            boardPos = new Position(x,y);
        }

        public override string ToString()
        {
            return occupier.ToString();
        }
    }
}