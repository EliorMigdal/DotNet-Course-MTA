using System;

public class BoardInspector
{
    public bool IsThereAWinner(GameBoard i_GameBoard)
    {
        return isThereAnySequenceOfFour(i_GameBoard);
    }

    private bool isThereAnySequenceOfFour(GameBoard i_GameBoard)
    {
        char originalShape = i_GameBoard.GetSymbol(i_GameBoard.LatestPointInserted);
        bool anySequenceOfFour;

        if (originalShape.Equals(' '))
        {
            anySequenceOfFour = false;
        }

        else
        {
            anySequenceOfFour = areThereFourInARow(i_GameBoard, i_GameBoard.LatestPointInserted.Row, originalShape) ||
            areThereFourInAColumn(i_GameBoard, i_GameBoard.LatestPointInserted.Column, originalShape) ||
            areThereFourInDiagonal(i_GameBoard, originalShape);
        }

        return anySequenceOfFour;
    }

    private bool areThereFourInARow(GameBoard i_GameBoard, int i_Row, char i_Symbol)
    {
        return maxSequenceInARow(i_GameBoard, i_Row, i_Symbol) == 4;
    }

    private int maxSequenceInARow(GameBoard i_GameBoard, int i_Row, char i_Symbol)
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

        return Math.Max(currentStreak, maxStreak);
    }

    private bool areThereFourInAColumn(GameBoard i_GameBoard, int i_Column, char i_Symbol)
    {
        return maxSequenceInAColumn(i_GameBoard, i_Column, i_Symbol) == 4;
    }

    private int maxSequenceInAColumn(GameBoard i_GameBoard, int i_Column, char i_Symbol)
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

        return Math.Max(currentStreak, maxStreak);
    }

    public bool areThereFourInDiagonal(GameBoard i_GameBoard, char i_Symbol)
    {
        return maxSequenceInLeftDiagonal(i_GameBoard, i_Symbol) == 4 ||
            maxSequenceInRightDiagonal(i_GameBoard, i_Symbol) == 4;
    }

    private int maxSequenceInLeftDiagonal(GameBoard i_GameBoard, char i_Symbol)
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

        return Math.Max(currentSequence, maxSequence);
    }

    private int maxSequenceInRightDiagonal(GameBoard i_GameBoard, char i_Symbol)
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

        return Math.Max(currentSequence, maxSequence);
    }

    public bool IsThereADraw(GameBoard i_GameBoard)
    {
        return isBoardFull(i_GameBoard);
    }

    private bool isBoardFull(GameBoard i_GameBoard)
    {
        bool isBoardFull = true;

        for (int i = 0; i < i_GameBoard.GetBoardWidth(); i++)
        {
            if (i_GameBoard.IsThereAFreeSpaceInColumn(i))
            {
                isBoardFull = false;
                break;
            }
        }

        return isBoardFull;
    }
}