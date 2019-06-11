namespace lp1_project2
{
    sealed class Tile
    {
        Position boardPos {get; set;}
        public Agent occupier;

        public Tile(int x, int y)
        {
            occupier = null;
            boardPos = new Position(x,y);

        }

        
    }
}