using System;

public class GameUI
{
    private readonly Reader m_InputReader = new Reader();
    private readonly Verifier m_InputVerifier = new Verifier();
    private readonly GameEngine m_GameEngine = new GameEngine();

    public void StartGame()
    {
        Console.WriteLine("Welcome to our 4-in-a-row game!");
        GameInfo gameInfo = ReadGameInfo();
    }

    public GameInfo ReadGameInfo()
    {
        GameInfo gameInfo = new GameInfo();

        m_InputReader.ReadBoardSize(out string width, out string height);
        while (!m_InputVerifier.VerifyBoardSize(width, height, ref gameInfo)) 
        {
            Console.WriteLine("Invalid input!");
            m_InputReader.ReadBoardSize(out width, out height);
        }

        m_InputReader.ReadParticipantsChoice(out string participantsChoice);
        while (!m_InputVerifier.VerifyParticipantsChoice(participantsChoice, ref gameInfo))
        {
            Console.WriteLine("Invalid input!");
            m_InputReader.ReadParticipantsChoice(out participantsChoice);
        }

        return gameInfo;
    }
}