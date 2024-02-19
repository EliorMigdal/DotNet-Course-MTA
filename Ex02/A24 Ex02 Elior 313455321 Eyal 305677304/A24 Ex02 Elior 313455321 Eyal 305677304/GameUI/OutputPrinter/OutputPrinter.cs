using System;
using System.Collections.Generic;
using System.Text;

public class OutputPrinter
{
    public void PrintBoard(GameBoard i_GameBoard)
    {
        Console.WriteLine("Current board's state: ");
        Console.Write(" ");

        for (int i = 0; i < i_GameBoard.GetBoardWidth(); i++)
        {
            Console.Write($" {i + 1}  ");
        }

        Console.WriteLine();

        for (int i = 0; i < i_GameBoard.GetBoardHeight(); i++)
        {
            Console.Write("|");

            for (int j = 0; j < i_GameBoard.GetBoardWidth(); j++)
            {
                Console.Write($" {i_GameBoard.GetSymbol(i,j)} |");
            }

            Console.WriteLine();

            for (int k = 0; k < i_GameBoard.GetBoardWidth(); k++)
            {
                Console.Write("====");
            }

            Console.WriteLine();
        }
    }

    public void PrintScore(List<GameParticipant> i_GameParticipants)
    {
        StringBuilder stringBuilder = new StringBuilder();
        stringBuilder.AppendLine("The score is: ");

        foreach (GameParticipant participant in i_GameParticipants)
        {
            stringBuilder.AppendLine($"{participant.Name}: {participant.Score}");
        }

        Console.WriteLine(stringBuilder.ToString());
    }

    public void PrintRoundOutcome(RoundResult i_RoundResult)
    {
        Console.WriteLine("Round has finished!");
        Console.Write("Round outcome: ");

        switch (i_RoundResult.RoundOutcome)
        {
            case eRoundOutcome.Draw:
                Console.WriteLine("Draw.");
                break;

            case eRoundOutcome.Conclusion:
                Console.WriteLine($"{i_RoundResult.RoundWinner} wins!");
                break;

            default:
                break;
        }
    }

    public void PrintMessage(string i_Message)
    {
        Console.WriteLine($"{i_Message}");
    }

    public void PrintError(string i_Error)
    {
        Console.WriteLine($"Error: {i_Error}");
    }
}