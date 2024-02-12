using System;

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

            Console.WriteLine("Round has finished!");
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
            r_OutputPrinter.PrintBoard(r_GameEngine.GameBoard);

            string nextPlayer = r_GameEngine.GetNextPlayersName();
            Console.WriteLine($"Now it is {nextPlayer}'s turn!");

            if (!nextPlayer.Equals("AI"))
            {
                r_InputReader.ReadMoveChoice(out string playerMove);

                if (playerMove.Equals("Q"))
                {
                    r_GameEngine.ForfietPlayer(nextPlayer);
                    break;
                }

                while (!r_InputValidator.ValidateMoveInput(playerMove, out int columnNum) ||
                    !r_GameEngine.ValidateMoveLogic(columnNum))
                {
                    r_OutputPrinter.PrintError();
                    r_InputReader.ReadMoveChoice(out playerMove);
                }
            }
        }
    }
}