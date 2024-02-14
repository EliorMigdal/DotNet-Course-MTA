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
            }
        }
    }

    public void PlayRound()
    {
        while (!r_GameEngine.HasGameConcluded())
        {
            int columnNum;
            string nextPlayer = r_GameEngine.GetNextPlayersName();

            r_OutputPrinter.PrintBoard(r_GameEngine.GameBoard);
            Console.WriteLine($"Now it is {nextPlayer}'s turn!");

            if (!nextPlayer.Equals("AI"))
            {
                r_InputReader.ReadMoveChoice(out string playerMove);

                while (!r_InputValidator.ValidateMoveInput(playerMove, out columnNum) ||
                    !r_GameEngine.ValidateMoveLogic(columnNum - 1))
                {
                    r_OutputPrinter.PrintError();
                    r_InputReader.ReadMoveChoice(out playerMove);
                }

                if (playerMove.Equals("Q"))
                {
                    r_GameEngine.ForfietPlayer();
                    break;
                }

                else
                {
                    r_GameEngine.InsertCoin(columnNum - 1);
                }
            }

            else
            {
                r_GameEngine.MakeAIMove();
            }

            Clear();
        }

        r_OutputPrinter.PrintBoard(r_GameEngine.GameBoard);
    }
}