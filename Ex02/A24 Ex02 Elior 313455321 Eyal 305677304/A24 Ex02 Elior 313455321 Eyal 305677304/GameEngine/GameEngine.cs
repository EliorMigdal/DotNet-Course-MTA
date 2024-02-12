using System.Collections.Generic;

public class GameEngine
{
    public GameBoard GameBoard { get; set; }
    public List<GameParticipant> GameParticipants {  get; set; }

    public void InitializeEngine(GameInfo i_GameInfo)
    {
        GameBoard = new GameBoard();
        GameBoard.Board = new char[i_GameInfo.Width, i_GameInfo.Height];
        GameParticipants = new List<GameParticipant>
        {
            new GameParticipant("P1", false)
        };

        if (i_GameInfo.PlayTheAI)
        {
            GameParticipants.Add(new GameParticipant("AI", true));
        }

        else
        {
            GameParticipants.Add(new GameParticipant("P2", false));
        }

        GameBoard.InitializeBoard();
    }

    public bool HasGameConcluded()
    {
        return false;
    }

    public string GetNextPlayersName()
    {
        return "Eli";
    }

    public bool ValidateMoveLogic(int i_ColumnNum)
    {
        return GameBoard.IsColumnVacant(i_ColumnNum);
    }

    public void ForfietPlayer(string i_PlayerName)
    {

    }

    public void ResetBoard()
    {
       GameBoard.InitializeBoard();
    }
}