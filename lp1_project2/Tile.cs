namespace lp1_project2
{
    sealed class Tile
    {
        Position boardPos {get; set;}

        public Tile(int x, int y)
        {

            boardPos = new Position(x,y);

        }

        
    }
}