using System;

public class AIOpponent
{
    private readonly GainStrategist r_GainStrategist = new GainStrategist();
    private readonly BlockStrategist r_BlockStrategist = new BlockStrategist();

    public void MakeMove(GameBoard i_Board, char i_AIShape, char i_OpponentShape, BoardInspector i_BoardInspector)
    {
        int myMaxSequence = GetMaxSequence(i_Board, i_AIShape, i_BoardInspector);
        int opponentMaxSequence = GetMaxSequence(i_Board, i_OpponentShape, i_BoardInspector);
    }

    public int GetMaxSequence(GameBoard i_Board, char i_Shape, BoardInspector i_BoardInspector)
    {
        int maxRowSequence = GetMaxRowSequence(i_Board, i_Shape, i_BoardInspector);
        int maxColumnSequence = GetMaxColumnSequence(i_Board,i_Shape, i_BoardInspector);
        int maxDiagonalSequence = GetMaxDiagonalSequence(i_Board, i_Shape, i_BoardInspector);

        return Math.Max(maxRowSequence, Math.Max(maxColumnSequence, maxDiagonalSequence));
    }

    public int GetMaxRowSequence(GameBoard i_Board, char i_Shape, BoardInspector i_BoardInspector)
    {
        int maxSequence = 0, currentRowSequence;

        for (int i = 0; i < i_Board.GetBoardHeight(); i++) 
        {
            currentRowSequence = i_BoardInspector.MaxSequenceInARow(i_Board, i, i_Shape);
            maxSequence = Math.Max(maxSequence, currentRowSequence);
        }

        return maxSequence;
    }

    public int GetMaxColumnSequence(GameBoard i_Board, char i_Shape, BoardInspector i_BoardInspector)
    {
        int maxSequence = 0, currentRowSequence;

        for (int i = 0; i < i_Board.GetBoardWidth(); i++)
        {
            currentRowSequence = i_BoardInspector.MaxSequenceInAColumn(i_Board, i, i_Shape);
            maxSequence = Math.Max(maxSequence, currentRowSequence);
        }

        return maxSequence;
    }

    public int GetMaxDiagonalSequence(GameBoard i_Board, char i_Shape, BoardInspector i_BoardInspector)
    {
        return Math.Max(i_BoardInspector.MaxSequenceInLeftDiagonal(i_Board, i_Shape),
            i_BoardInspector.MaxSequenceInRightDiagonal(i_Board, i_Shape));
    }
}