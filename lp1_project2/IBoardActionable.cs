namespace lp1_project2
{
    interface IBoardActionable
    {
        void Action(Tile t, Position newPos, Board gameBoard = null);
    }
}