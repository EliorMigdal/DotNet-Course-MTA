using System;
/* using static Ex02.ConsoleUtils.Screen; //External DLL supplied in the assignment. */
using FourInARow.UI.Printer;
using FourInARow.Engine;
using FourInARow.DTO;
using FourInARow.UI.Enums;

namespace FourInARow.UI
{
    public class GameUI
    {
        private readonly OutputPrinter r_OutputPrinter = new OutputPrinter();
        private readonly GameEngine r_GameEngine = new GameEngine();
        private readonly GameInfo m_GameInfo = new GameInfo();

        public void StartGame()
        {
            initializeGame();
            runGame();
            exitGame();
        }

        private void initializeGame()
        {
            r_OutputPrinter.PrintMessage("Welcome to our 4-in-a-row game!");
            readGameInfo();
            r_GameEngine.InitializeEngine(m_GameInfo);
        }

        private void readGameInfo()
        {
            handleBoardSizeInput();
            handleSecondParticipantInput();
        }

        private void handleBoardSizeInput()
        {
            string boardWidthInput, boardHeightInput;

            do
            {
                readBoardSize(out boardWidthInput, out boardHeightInput);
            } while (!validateBoardSize(boardWidthInput, boardHeightInput));
        }

        private void readBoardSize(out string o_BoardWidthInput, out string o_BoardHeightInput)
        {
            r_GameEngine.GetBoardDimensions(out int minDimension, out int maxDimension);
            Console.WriteLine("Please enter your desired board's size.");
            Console.WriteLine($"Board size is ranged from {minDimension}x{minDimension} " +
                $"to {maxDimension}x{maxDimension}.");
            Console.Write("Please enter board width: ");
            o_BoardWidthInput = Console.ReadLine();
            Console.Write("Please enter board height: ");
            o_BoardHeightInput = Console.ReadLine();
        }

        private bool validateBoardSize(string i_BoardWidthInput, string i_BoardHeightInput)
        {
            return validateBoardSizeInput(i_BoardWidthInput, i_BoardHeightInput)
                && validateBoardSizeLogic(m_GameInfo.Width, m_GameInfo.Height);
        }

        private bool validateBoardSizeInput(string i_BoardWidthInput, string i_BoardHeightInput)
        {
            bool isWidthValid = tryParsingToInt(i_BoardWidthInput, out int width);
            bool isHeightValid = tryParsingToInt(i_BoardHeightInput, out int height);

            m_GameInfo.Width = width;
            m_GameInfo.Height = height;

            return isWidthValid && isHeightValid;
        }

        private bool validateBoardSizeLogic(int i_BoardWidth, int i_BoardHeight)
        {
            bool isSizeInRange = r_GameEngine.ValidateBoardSize(i_BoardWidth, i_BoardHeight);

            if (!isSizeInRange)
            {
                Console.WriteLine($"Error: {i_BoardWidth}x{i_BoardHeight} is out of board's dimensions range!");
            }

            return isSizeInRange;
        }

        private bool tryParsingToInt(string i_Input, out int o_Value)
        {
            bool isParsable = int.TryParse(i_Input, out o_Value);

            if (!isParsable)
            {
                Console.WriteLine($"Error: {i_Input} cannot be parsed as an integer!");
            }

            return isParsable;
        }

        private void handleSecondParticipantInput()
        {
            string secondParticipantInput;

            do
            {
                readSecondParticipantInput(out secondParticipantInput);
            } while (!validateParticipantChoice(secondParticipantInput));
        }

        private void readSecondParticipantInput(out string o_Input)
        {
            Console.WriteLine($"Please enter {(int)eUserChoice.PlayAI} to play against the AI, " +
            $"or {(int)eUserChoice.PlayAnotherPlayer} to play agains another player.");
            Console.Write("Enter your choice: ");
            o_Input = Console.ReadLine();
        }

        private bool validateParticipantChoice(string i_Input)
        {
            bool isParsable = Enum.TryParse(i_Input, true, out eUserChoice userChoice);

            if (isParsable)
            {
                m_GameInfo.PlayTheAI = userChoice.Equals(eUserChoice.PlayAI);
            }

            else
            {
                Console.WriteLine($"Error: {i_Input} isn't a valid choice!");
            }

            return isParsable;
        }

        private void runGame()
        {
            bool playAnotherRound;

            do
            {
                resetGame();
                playRound();
                finishRound();
                playAnotherRound = playAgainChoice();
            } while (playAnotherRound);

            r_OutputPrinter.PrintMessage("Farewell!");
        }

        private void playRound()
        {
            r_OutputPrinter.PrintMessage("Round is starting!");

            do
            {
                if (r_GameEngine.IsItAITurn())
                {
                    handleAIMove();
                }

                else
                {
                    handlePlayerMove();
                }

                Console.Clear();

            } while (!r_GameEngine.HasGameConcluded());

            r_OutputPrinter.PrintBoard(r_GameEngine.GameBoard);
        }

        private void handlePlayerMove()
        {
            int columnNum;
            string playerMove;

            r_OutputPrinter.PrintBoard(r_GameEngine.GameBoard);
            r_OutputPrinter.PrintMessage($"Now it is {r_GameEngine.GetNextPlayersName()}'s turn!");

            do
            {
                readPlayerMove(out playerMove);
            } while (!isMoveValid(playerMove, out columnNum));

            r_GameEngine.InsertCoin(columnNum - 1);
        }

        private void readPlayerMove(out string o_PlayerMove)
        {
            Console.WriteLine("Please enter a column number to insert your shape," + Environment.NewLine +
            "or enter 'Q' if you would like to forfeit (Your opponent will get 1 point): ");
            o_PlayerMove = Console.ReadLine();
        }

        private bool isMoveValid(string i_PlayerMove, out int o_Column)
        {
            bool isParsable = validateMoveInput(i_PlayerMove, out o_Column);
            bool isValidLogically = r_GameEngine.ValidateMoveLogic(o_Column);

            if (isParsable && !isValidLogically)
            {
                Console.WriteLine($"Error: {i_PlayerMove} is out of board's range!");
            }

            return isParsable && isValidLogically;
        }

        private bool validateMoveInput(string i_PlayerMove, out int o_Column)
        {
            bool isQuitting = false;

            if (i_PlayerMove.Equals("Q"))
            {
                isQuitting = true;
                r_GameEngine.ForfietPlayer();
            }

            return tryParsingToInt(i_PlayerMove, out o_Column) || isQuitting;
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
            string roundInput;
            bool playAgain;

            do
            {
                readRoundChoice(out roundInput);
            } while (!validateRoundChoice(roundInput, out playAgain));

            return playAgain;
        }

        private void readRoundChoice(out string o_RoundChoice)
        {
            Console.Write("Would like to play another round? Enter Y/N: ");
            o_RoundChoice = Console.ReadLine();
        }

        private bool validateRoundChoice(string i_RoundChoice, out bool o_ParsedChoice)
        {
            bool isInputValid = i_RoundChoice.Equals("Y") || i_RoundChoice.Equals("N");

            if (!isInputValid)
            {
                Console.WriteLine($"Error: {i_RoundChoice} cannot be parsed as a boolean (True/False)!");
            }

            o_ParsedChoice = i_RoundChoice.Equals("Y");

            return isInputValid;
        }

        private void resetGame()
        {
            r_GameEngine.ResetEngineData();
            Console.Clear();
        }

        private void exitGame()
        {
            r_OutputPrinter.PrintMessage("Press Enter to exit...");
            Console.ReadLine();
        }
    }
}