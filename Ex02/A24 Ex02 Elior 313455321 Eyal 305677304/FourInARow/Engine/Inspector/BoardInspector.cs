using System;
using FourInARow.Engine.Board;

namespace FourInARow.Engine.Inspector
{
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

        private int maxSequenceInDirection(GameBoard i_GameBoard, int i_Row, int i_Column, char i_Symbol,
            int i_RowIncrement, int i_ColumnIncrement)
        {
            int currentStreak = 0, maxStreak = 0, currentRow = i_Row, currentColumn = i_Column;

            while (i_GameBoard.IsInBounds(currentRow, currentColumn))
            {
                if (i_Symbol.Equals(i_GameBoard.GetSymbol(currentRow, currentColumn)))
                {
                    currentStreak++;
                }

                else
                {
                    maxStreak = Math.Max(currentStreak, maxStreak);
                    currentStreak = 0;
                }

                currentRow += i_RowIncrement;
                currentColumn += i_ColumnIncrement;
            }

            return Math.Max(currentStreak, maxStreak);
        }

        private bool areThereFourInARow(GameBoard i_GameBoard, int i_Row, char i_Symbol)
        {
            return maxSequenceInDirection(i_GameBoard, i_Row, 0, i_Symbol, 0, 1) == 4;
        }

        private bool areThereFourInAColumn(GameBoard i_GameBoard, int i_Column, char i_Symbol)
        {
            return maxSequenceInDirection(i_GameBoard, 0, i_Column, i_Symbol, 1, 0) == 4;
        }

        private bool areThereFourInDiagonal(GameBoard i_GameBoard, char i_Symbol)
        {
            Point startOfLeftDiagonal = i_GameBoard.GetTopLeftPointInDiagonal(i_GameBoard.LatestPointInserted);
            Point startOfRightDiagonal = i_GameBoard.GetTopRightPointInDiagonal(i_GameBoard.LatestPointInserted);

            return maxSequenceInDirection(i_GameBoard, startOfLeftDiagonal.Row,
                   startOfLeftDiagonal.Column, i_Symbol, 1, 1) == 4 ||
                   maxSequenceInDirection(i_GameBoard, startOfRightDiagonal.Row,
                   startOfRightDiagonal.Column, i_Symbol, 1, -1) == 4;
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
}