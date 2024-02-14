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
        return MaxSequenceInARow(i_GameBoard, i_Row, i_Symbol) == 4;
    }

    public int MaxSequenceInARow(GameBoard i_GameBoard, int i_Row, char i_Symbol)
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

        return maxStreak;
    }

    public bool AreThereFourInAColumn(GameBoard i_GameBoard, int i_Column, char i_Symbol)
    {
        return MaxSequenceInAColumn(i_GameBoard, i_Column, i_Symbol) == 4;
    }

    public int MaxSequenceInAColumn(GameBoard i_GameBoard, int i_Column, char i_Symbol)
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

        return maxStreak;
    }

    public bool AreThereFourInDiagonal(GameBoard i_GameBoard, char i_Symbol)
    {
        return MaxSequenceInLeftDiagonal(i_GameBoard, i_Symbol) == 4 ||
            MaxSequenceInRightDiagonal(i_GameBoard, i_Symbol) == 4;
    }

    public int MaxSequenceInLeftDiagonal(GameBoard i_GameBoard, char i_Symbol)
    {
        Point diagonalPoint = i_GameBoard.GetTopLeftPointInDiagonal(i_GameBoard.LatestPointInserted);
        int currentSequence = 0, maxSequence = 0;

        while (i_GameBoard.IsInBounds(diagonalPoint))
        {
            if (i_Symbol.Equals(i_GameBoard.GetSymbol(diagonalPoint)))
            {
                currentSequence++;
            }

            else
            {
                maxSequence = Math.Max(currentSequence, maxSequence);
                currentSequence = 0;
            }

            diagonalPoint++;
        }

        return maxSequence;
    }

    public int MaxSequenceInRightDiagonal(GameBoard i_GameBoard, char i_Symbol)
    {
        Point diagonalPoint = i_GameBoard.GetTopRightPointInDiagonal(i_GameBoard.LatestPointInserted);
        int currentSequence = 0, maxSequence = 0;

        while (i_GameBoard.IsInBounds(diagonalPoint))
        {
            if (i_Symbol.Equals(i_GameBoard.GetSymbol(diagonalPoint)))
            {
                currentSequence++;
            }

            else
            {
                maxSequence = Math.Max(currentSequence, maxSequence);
                currentSequence = 0;
            }

            diagonalPoint.Column--;
            diagonalPoint.Row++;
        }

        return maxSequence;
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