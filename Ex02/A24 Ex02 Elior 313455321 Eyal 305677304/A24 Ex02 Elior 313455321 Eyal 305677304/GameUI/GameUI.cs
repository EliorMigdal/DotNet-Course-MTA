using System;
using static Ex02.ConsoleUtils.Screen;

public class GameUI
{
    private readonly InputReader r_InputReader = new InputReader();
    private readonly InputValidator r_InputValidator = new InputValidator();
    private readonly OutputPrinter r_OutputPrinter = new OutputPrinter();
    private readonly GameEngine r_GameEngine = new GameEngine();

    public void StartGame()
    {
        Console.WriteLine("Welcome to our 4-in-a-row game!");
        GameInfo gameInfo = ReadGameInfo();
        r_GameEngine.InitializeEngine(gameInfo);
        RunGame();
        ExitGame();
    }

    public GameInfo ReadGameInfo()
    {
        GameInfo gameInfo = new GameInfo();

        r_InputReader.ReadBoardSize(out string width, out string height);

        while (!r_InputValidator.ValidateBoardSize(width, height, ref gameInfo)) 
        {
            Console.WriteLine("Invalid input!");
            r_InputReader.ReadBoardSize(out width, out height);
        }

        r_InputReader.ReadParticipantsChoice(out string participantsChoice);

        while (!r_InputValidator.ValidateParticipantsChoice(participantsChoice, ref gameInfo))
        {
            r_OutputPrinter.PrintError();
            r_InputReader.ReadParticipantsChoice(out participantsChoice);
        }

        return gameInfo;
    }

    public void RunGame()
    {
        bool playAnotherRound = true;

        while (playAnotherRound)
        {
            PlayRound();

            r_OutputPrinter.PrintRoundOutcome(r_GameEngine.LastRoundOutcome);
            r_OutputPrinter.PrintScore(r_GameEngine.GameParticipants);
            r_InputReader.ReadRoundChoice(out string choice);

            while (!r_InputValidator.ValidateRoundInput(choice, out playAnotherRound))
            {
                r_OutputPrinter.PrintError();
                r_InputReader.ReadRoundChoice(out choice);
            }

            if (playAnotherRound)
            {
                Console.WriteLine("Starting another round!");
                r_GameEngine.ResetBoard();
                Clear();
            }

            else
            {
                Console.WriteLine("Farewell!");
            }
        }
    }

    public void PlayRound()
    {
        while (!r_GameEngine.HasGameConcluded())
        {
            r_OutputPrinter.PrintBoard(r_GameEngine.GameBoard);
            Console.WriteLine($"Now it is {r_GameEngine.GetNextPlayersName()}'s turn!");

            if (!r_GameEngine.IsItAITurn())
            {
                if (HandlePlayerMove().Equals("Q"))
                {
                    Clear();
                    break;
                }
            }

            else
            {
                HandleAIMove();
            }

            Clear();
        }

        r_OutputPrinter.PrintBoard(r_GameEngine.GameBoard);
    }

    public string HandlePlayerMove()
    {
        int columnNum;
        r_InputReader.ReadMoveChoice(out string playerMove);

        while (!IsMoveValid(playerMove, out columnNum))
        {
            if (playerMove.Equals("Q"))
            {
                r_GameEngine.ForfietPlayer();
                break;
            }

            r_OutputPrinter.PrintError();
            r_InputReader.ReadMoveChoice(out playerMove);
        }

        if (!playerMove.Equals("Q"))
        {
            r_GameEngine.InsertCoin(columnNum - 1);
        }

        return playerMove;
    }

    public bool IsMoveValid(string i_PlayerMove, out int o_Column)
    {
        return r_InputValidator.ValidateMoveInput(i_PlayerMove, out o_Column) &&
            r_GameEngine.ValidateMoveLogic(o_Column - 1);
    }

    public void HandleAIMove()
    {
        r_GameEngine.MakeAIMove();
    }

    public void ExitGame()
    {
        Console.WriteLine("Press Enter to exit...");
        Console.ReadLine();
    }
}