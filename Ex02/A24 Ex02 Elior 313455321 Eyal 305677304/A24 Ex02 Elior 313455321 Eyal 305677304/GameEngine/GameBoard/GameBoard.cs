public class GameBoard
{
    public char[,] Board { get; set; }
    public Point LatestPointInserted { get; set; }

    public GameBoard(int i_Height, int i_Width)
    {
        Board = new char[i_Height, i_Width];
        InitializeBoard();
        LatestPointInserted = new Point();
    }

    public void InitializeBoard()
    {
        for (int i = 0; i < GetBoardHeight(); i++)
        {
            for (int j = 0; j < GetBoardWidth(); j++)
            {
                Board[i, j] = ' ';
            }
        }
    }

    public bool IsThereAFreeSpaceInColumn(int i_ColumnNum)
    {
        return Board[0, i_ColumnNum] == ' ';
    }

    public int GetBoardHeight()
    {
        return Board.GetLength(0);
    }

    public int GetBoardWidth()
    {
        return Board.GetLength(1);
    }

    public void InsertToAColumn(int i_Column, char i_Shape)
    {
        int firstVacancy = getLastFreeSpaceInColumn(i_Column);

        LatestPointInserted.Row = firstVacancy;
        LatestPointInserted.Column = i_Column;
        Board[firstVacancy, i_Column] = i_Shape;
    }

    public char GetSymbol(int i_Row, int i_Column)
    {
        return Board[i_Row, i_Column];
    }

    public char GetSymbol(Point i_Point)
    {
        return GetSymbol(i_Point.Row, i_Point.Column);
    }

    private int getLastFreeSpaceInColumn(int i_Column)
    {
        int lastVacancy = -1;

        for (int i = 0; i < GetBoardHeight(); i++)
        {
            if (Board[i, i_Column].Equals(' '))
            {
                lastVacancy = i;
            }

            else
            {
                break;
            }
        }

        return lastVacancy;
    }

    public Point GetTopLeftPointInDiagonal(Point i_Point)
    {
        int startPointRow = i_Point.Row, startPointColumn = i_Point.Column;

        while (IsInBounds(startPointRow, startPointColumn))
        {
            startPointRow--;
            startPointColumn--;
        }

        return new Point(startPointRow + 1, startPointColumn + 1);
    }

    public Point GetTopRightPointInDiagonal(Point i_Point)
    {
        int startPointRow = i_Point.Row, startPointColumn = i_Point.Column;

        while (IsInBounds(startPointRow, startPointColumn))
        {
            startPointRow--;
            startPointColumn++;
        }

        return new Point(startPointRow + 1, startPointColumn - 1);
    }

    public bool IsInBounds(int i_Row, int i_Column)
    {
        return i_Row >= 0 && i_Row < GetBoardHeight() &&
            i_Column >= 0 && i_Column < GetBoardWidth();
    }

    public bool IsInBounds(Point i_Point)
    {
        return IsInBounds(i_Point.Row, i_Point.Column);
    }
}
