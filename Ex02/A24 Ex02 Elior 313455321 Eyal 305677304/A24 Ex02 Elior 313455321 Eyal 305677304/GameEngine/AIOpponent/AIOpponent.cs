using System;

public class AIOpponent
{
    private readonly GainStrategist r_GainStrategist = new GainStrategist();
    private readonly BlockStrategist r_BloackStrategist = new BlockStrategist();

    public void MakeMove(GameBoard i_Board, char i_AIShape, char i_OpponentShape, BoardInspector i_BoardInspector)
    {
        int opponentMaxSequence = GetOpponentMaxSequence(i_Board, i_OpponentShape, i_BoardInspector);

        if (opponentMaxSequence == 3)
        {
            BlockOpponent();
        }

        else
        {

        }
    }

    public void BlockOpponent()
    {

    }

    public int GetOpponentMaxSequence(GameBoard i_Board, char i_OpponentShape, BoardInspector i_BoardInspector)
    {
        return 0;
    }

    public int GetOpponentMaxRowSequence(GameBoard i_Board, char i_OpponentShape, BoardInspector i_BoardInspector)
    {
        int maxSequence = 0, currentRowSequence;

        for (int i = 0; i < i_Board.GetBoardHeight(); i++) 
        {
            currentRowSequence = i_BoardInspector.MaxSequenceInARow(i_Board, i, i_OpponentShape);
            maxSequence = Math.Max(maxSequence, currentRowSequence);
        }

        return maxSequence;
    }

    public int GetOpponentMaxColumnSequence(GameBoard i_Board, char i_OpponentShape, BoardInspector i_BoardInspector)
    {
        int maxSequence = 0, currentRowSequence;

        for (int i = 0; i < i_Board.GetBoardWidth(); i++)
        {
            currentRowSequence = i_BoardInspector.MaxSequenceInAColumn(i_Board, i, i_OpponentShape);
            maxSequence = Math.Max(maxSequence, currentRowSequence);
        }

        return maxSequence;
    }
}