public class GameBoard
{
    public char[,] Board { get; set; }

    public void InitializeBoard()
    {
        for (int i = 0; i < Board.GetLength(0); i++)
        {
            for (int j = 0; j < Board.GetLength(1); j++)
            {
                Board[i, j] = ' ';
            }
        }
    }

    public bool IsColumnVacant(int i_ColumnNum)
    {
        return Board[0, i_ColumnNum] == ' ';
    }
}
