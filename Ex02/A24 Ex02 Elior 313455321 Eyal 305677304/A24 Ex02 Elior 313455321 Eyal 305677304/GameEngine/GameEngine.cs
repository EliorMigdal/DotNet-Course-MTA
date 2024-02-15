using System;
using System.Collections.Generic;

public class GameEngine
{
    public GameBoard GameBoard { get; set; }
    public List<GameParticipant> GameParticipants {  get; set; }
    public BoardInspector BoardInspector { get; set; }
    public GameParticipant CurrentPlayer {  get; set; }
    public string LastRoundOutcome { get; set; }

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
        }

        else
        {
            GameParticipants.Add(new GameParticipant("P2", false, 'X'));
        }

        CurrentPlayer = GameParticipants[0];
    }

    public bool HasGameConcluded()
    {
        bool isThereAWinner = BoardInspector.IsThereAWinner(GameBoard);
        bool isThereADraw = BoardInspector.IsThereADraw(GameBoard);

        if (isThereAWinner)
        {
            CurrentPlayer.Score++;
            LastRoundOutcome = CurrentPlayer.Name;
        }

        else if (isThereADraw)
        {
            LastRoundOutcome = "Draw";
        }

        else if (!HasGameJustStarted())
        {
            UpdateTurn();
        }

        return isThereAWinner || isThereADraw;
    }

    public bool HasGameJustStarted()
    {
        return GameBoard.GetSymbol(GameBoard.LatestPointInserted).Equals(' ');
    }

    public string GetNextPlayersName()
    {
        return CurrentPlayer.Name;
    }

    public bool IsItAITurn()
    {
        return CurrentPlayer.IsAI;
    }

    public bool ValidateMoveLogic(int i_ColumnNum)
    {
        bool isValid = i_ColumnNum >= 0 && i_ColumnNum <= GameBoard.GetBoardWidth() - 1;

        return isValid && GameBoard.IsThereAFreeSpaceInColumn(i_ColumnNum);
    }

    public void ForfietPlayer()
    {
        UpdateTurn();
        CurrentPlayer.Score++;
        LastRoundOutcome = CurrentPlayer.Name;
    }

    public void ResetBoard()
    {
        GameBoard.InitializeBoard();
        CurrentPlayer = GameParticipants[0];
    }

    public void InsertCoin(int i_Column)
    {
        char coinSymbol = CurrentPlayer.Symbol;

        GameBoard.InsertToAColumn(i_Column, coinSymbol);
    }

    public void UpdateTurn()
    {
        int i = GameParticipants.FindIndex(p => p.Equals(CurrentPlayer));

        CurrentPlayer = GameParticipants[(i + 1) % GameParticipants.Count];
    }

    public void MakeAIMove()
    {
        int column = new Random().Next(0, GameBoard.GetBoardWidth());

        while (!GameBoard.IsThereAFreeSpaceInColumn(column))
        {
            column = new Random().Next(0, GameBoard.GetBoardWidth());
        }

        InsertCoin(column);
    }
}