using System;

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

    public bool IsColumnVacant(int i_ColumnNum)
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
        int firstVacancy = GetFirstVacancy(i_Column);

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

    public int GetFirstVacancy(int i_Column)
    {
        int firstVacancy = -1;

        for (int i = 0; i < GetBoardWidth(); i++)
        {
            if (Board[i, i_Column].Equals(' '))
            {
                firstVacancy = i;
            }
        }

        return firstVacancy;
    }

    public Point GetTopLeftPointInDiagonal(Point i_Point)
    {
        int maxAxisValue = Math.Max(i_Point.Row, i_Point.Column);
        return new Point(i_Point.Row - maxAxisValue, i_Point.Column - maxAxisValue);
    }

    public Point GetTopRightPointInDiagonal(Point i_Point)
    {
        int startPointRow = i_Point.Row, startPointColumn = i_Point.Column;

        while (IsInBounds(startPointRow, startPointColumn))
        {
            startPointRow--;
            startPointColumn++;
        }

        if (startPointRow < 0)
        {
            startPointRow++;
        }

        else
        {
            startPointColumn--;
        }

        return new Point(startPointRow, startPointColumn);

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
