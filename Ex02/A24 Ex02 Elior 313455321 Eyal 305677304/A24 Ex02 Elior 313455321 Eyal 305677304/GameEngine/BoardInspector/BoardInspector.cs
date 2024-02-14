using System;

public class BoardInspector
{
    public bool HasGameConcluded(GameBoard i_GameBoard)
    {
        return IsThereAWinner(i_GameBoard) || IsThereADraw(i_GameBoard);
    }

    public bool IsThereAWinner(GameBoard i_GameBoard)
    {
        return IsThereAnySequenceOfFour(i_GameBoard);
    }

    public bool IsThereAnySequenceOfFour(GameBoard i_GameBoard)
    {
        char originalShape = i_GameBoard.GetSymbol(i_GameBoard.LatestPointInserted);

        return AreThereFourInARow(i_GameBoard, i_GameBoard.LatestPointInserted.Row, originalShape) ||
            AreThereFourInAColumn(i_GameBoard, i_GameBoard.LatestPointInserted.Column, originalShape) ||
            AreThereFourInDiagonal(i_GameBoard, originalShape);

    }

    public bool AreThereFourInARow(GameBoard i_GameBoard, int i_Row, char i_Symbol)
    {
        int currentStreak = 0, maxStreak = 0;

        for (int i = 0; i < i_GameBoard.GetBoardWidth(); i++)
        {
            if (i_Symbol.Equals(i_GameBoard.GetSymbol(i_Row, i)))
            {
                currentStreak++;
            }

            else
            {
                maxStreak = Math.Max(currentStreak, maxStreak);
                currentStreak = 0;
            }
        }

        return maxStreak == 4;
    }

    public bool AreThereFourInAColumn(GameBoard i_GameBoard, int i_Column, char i_Symbol)
    {
        int currentStreak = 0, maxStreak = 0;

        for (int i = 0; i < i_GameBoard.GetBoardHeight(); i++)
        {
            if (i_Symbol.Equals(i_GameBoard.GetSymbol(i, i_Column)))
            {
                currentStreak++;
            }

            else
            {
                maxStreak = Math.Max(currentStreak, maxStreak);
                currentStreak = 0;
            }
        }

        return maxStreak == 4;
    }

    public bool AreThereFourInDiagonal(GameBoard i_GameBoard, char i_Symbol)
    {
        return false;
    }

    public bool IsThereADraw(GameBoard i_GameBoard)
    {
        bool isBoardFull = true;

        for (int i = 0; i < i_GameBoard.Board.GetLength(1); i++)
        {
            if (i_GameBoard.IsColumnVacant(i))
            {
                isBoardFull = false;
                break;
            }
        }

        return isBoardFull;
    }
}