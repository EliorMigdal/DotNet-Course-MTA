using System;
using System.Collections.Generic;
using System.Text;

public class OutputPrinter
{
    public void PrintBoard(GameBoard i_GameBoard)
    {
        Console.WriteLine("Current board's state: ");

        for (int i = 0; i < i_GameBoard.Board.GetLength(0); i++)
        {
            Console.Write($"   {i + 1}   ");
        }

        Console.WriteLine();

        for (int i = 0; i < i_GameBoard.Board.GetLength(1); i++)
        {
            Console.Write('|');
            for (int j = 0; j < i_GameBoard.Board.GetLength(0); j++)
            {
                Console.Write($"   {i_GameBoard.Board.GetValue(j, i)}   |");
            }

            Console.WriteLine();

            for (int k = 0; k < i_GameBoard.Board.GetLength(0); k++)
            {
                Console.Write("========");
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

    public void PrintError()
    {
        Console.WriteLine("Invalid input! Please try again!");
    }
}