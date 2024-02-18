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
        initializeGame();
        runGame();
        exitGame();
    }

    private void initializeGame()
    {
        Console.WriteLine("Welcome to our 4-in-a-row game!");
        GameInfo gameInfo = readGameInfo();
        r_GameEngine.InitializeEngine(gameInfo);
    }

    private GameInfo readGameInfo()
    {
        GameInfo gameInfo = new GameInfo();

        r_InputReader.ReadBoardSize(out string width, out string height);

        while (!r_InputValidator.ValidateBoardSize(width, height, ref gameInfo)) 
        {
            r_OutputPrinter.PrintError("Invalid board size!");
            r_InputReader.ReadBoardSize(out width, out height);
        }

        r_InputReader.ReadParticipantsChoice(out string participantsChoice);

        while (!r_InputValidator.ValidateParticipantsChoice(participantsChoice, ref gameInfo))
        {
            r_OutputPrinter.PrintError("Invalid participants choice!");
            r_InputReader.ReadParticipantsChoice(out participantsChoice);
        }

        return gameInfo;
    }

    private void runGame()
    {
        bool playAnotherRound = true;

        while (playAnotherRound)
        {
            playRound();
            finishRound();
            playAnotherRound = playAgainChoice();

            if (playAnotherRound)
            {
                resetGame();
            }
        }

        Console.WriteLine("Farewell!");
    }

    private void playRound()
    {
        Console.WriteLine("Round is starting!");

        while (!r_GameEngine.HasGameConcluded())
        {
            r_OutputPrinter.PrintBoard(r_GameEngine.GameBoard);
            Console.WriteLine($"Now it is {r_GameEngine.GetNextPlayersName()}'s turn!");

            if (r_GameEngine.IsItAITurn())
            {
                handleAIMove();
            }

            else
            {
                handlePlayerMove();
            }

            Clear();
        }

        r_OutputPrinter.PrintBoard(r_GameEngine.GameBoard);
    }

    private void handlePlayerMove()
    {
        int columnNum;

        r_InputReader.ReadMoveChoice(out string playerMove);

        while (!isMoveValid(playerMove, out columnNum))
        {
            r_OutputPrinter.PrintError("Invalid column choice!\nColumn is full or out of range.");
            r_InputReader.ReadMoveChoice(out playerMove);
        }

        if (playerMove.Equals("Q"))
        {
            r_GameEngine.ForfietPlayer();
        }

        else
        {
            r_GameEngine.InsertCoin(columnNum - 1);
        }
    }
    
    private bool isMoveValid(string i_PlayerMove, out int o_Column)
    {
        bool isMoveValid = r_InputValidator.ValidateMoveInput(i_PlayerMove, out o_Column);

        if (!i_PlayerMove.Equals("Q"))
        {
            isMoveValid &= r_GameEngine.ValidateMoveLogic(o_Column - 1);
        }

        return isMoveValid;
    }

    private void handleAIMove()
    {
        r_GameEngine.MakeAIMove();
    }

    private void finishRound()
    {
        r_OutputPrinter.PrintRoundOutcome(r_GameEngine.RoundResult);
        r_OutputPrinter.PrintScore(r_GameEngine.GameParticipants);
    }

    private bool playAgainChoice()
    {
        bool playAgain;

        r_InputReader.ReadRoundChoice(out string choice);

        while (!r_InputValidator.ValidateRoundInput(choice, out playAgain))
        {
            r_OutputPrinter.PrintError("Invalid choice!");
            r_InputReader.ReadRoundChoice(out choice);
        }

        return playAgain;
    }

    private void resetGame()
    {
        r_GameEngine.ResetEngineData();
        Clear();
    }

    private void exitGame()
    {
        Console.WriteLine("Press Enter to exit...");
        Console.ReadLine();
    }
}