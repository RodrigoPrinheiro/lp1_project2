namespace lp1_project2
{
    public sealed class Tile
    {
        private Position boardPos {get; set;}
        private Agent occupier;

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