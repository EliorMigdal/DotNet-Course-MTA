using System.Security.Cryptography;

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
}
