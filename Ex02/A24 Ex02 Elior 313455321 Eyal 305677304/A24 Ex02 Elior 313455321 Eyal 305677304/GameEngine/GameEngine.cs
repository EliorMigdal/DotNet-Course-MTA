using System;
using System.Collections.Generic;

public class GameEngine
{
    public GameBoard GameBoard { get; set; }
    public List<GameParticipant> GameParticipants {  get; set; }
    public BoardInspector BoardInspector { get; set; }
    public GameParticipant CurrentTurn {  get; set; }
    public string LastRoundOutcome { get; set; }
    public AIOpponent AI { get; set; }

    public void InitializeEngine(GameInfo i_GameInfo)
    {
        GameBoard = new GameBoard(i_GameInfo.Height, i_GameInfo.Width);
        BoardInspector = new BoardInspector();

        GameParticipants = new List<GameParticipant>
        {
            new GameParticipant("P1", false, 'O')
        };

        if (i_GameInfo.PlayTheAI)
        {
            GameParticipants.Add(new GameParticipant("AI", true, 'X'));
            AI = new AIOpponent();
        }

        else
        {
            GameParticipants.Add(new GameParticipant("P2", false, 'X'));
        }

        CurrentTurn = GameParticipants[0];
    }

    public bool HasGameConcluded()
    {
        bool isThereAWinner = BoardInspector.IsThereAWinner(GameBoard);
        bool isThereADraw = BoardInspector.IsThereADraw(GameBoard);

        if (isThereAWinner)
        {
            CurrentTurn.AddPoint();
            LastRoundOutcome = CurrentTurn.Name;
        }

        else if (isThereADraw)
        {
            LastRoundOutcome = "Draw";
        }

        else if (!GameBoard.GetSymbol(GameBoard.LatestPointInserted).Equals(' '))
        {
            UpdateTurn();
        }

        return isThereAWinner || isThereADraw;
    }

    public string GetNextPlayersName()
    {
        return CurrentTurn.Name;
    }

    public bool ValidateMoveLogic(int i_ColumnNum)
    {
        bool isValid = i_ColumnNum >= 0 && i_ColumnNum <= GameBoard.GetBoardWidth() - 1;

        return isValid && GameBoard.IsColumnVacant(i_ColumnNum);
    }

    public void ForfietPlayer()
    {
        UpdateTurn();
        CurrentTurn.AddPoint();
    }

    public void ResetBoard()
    {
        GameBoard.InitializeBoard();
        CurrentTurn = GameParticipants[0];
    }

    public void InsertCoin(int i_Column)
    {
        char coinSymbol = CurrentTurn.Symbol;

        GameBoard.InsertToAColumn(i_Column, coinSymbol);
    }

    public void UpdateTurn()
    {
        int i = GameParticipants.FindIndex(p => p.Equals(CurrentTurn));
        CurrentTurn = GameParticipants[(i+1) % GameParticipants.Count];
    }

    public void MakeAIMove()
    {
        int column = new Random().Next(0, GameBoard.GetBoardWidth());

        while (!GameBoard.IsColumnVacant(column))
        {
            column = new Random().Next(0, GameBoard.GetBoardWidth());
        }

        InsertCoin(column);
    }
}