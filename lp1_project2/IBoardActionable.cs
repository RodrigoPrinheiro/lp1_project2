namespace lp1_project2
{
    /// <summary>
    /// Determines that said class has an action.
    /// </summary>
    interface IBoardActionable
    {
        void Action(Tile[,] t, Position newPos, Board gameBoard = null);
    }
}