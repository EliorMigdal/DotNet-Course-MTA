using System;

public class Reader
{
    public void ReadBoardSize(out string o_Width, out string o_Height)
    {
        Console.WriteLine("Please enter your desired board's size.");
        Console.WriteLine($"Board size is ranged from {eDimensions.MinValue}x{eDimensions.MinValue} to {eDimensions.MaxValue}x{eDimensions.MaxValue}.");

        Console.Write("Please enter board width: ");
        o_Width = Console.ReadLine();

        Console.WriteLine("Please enter board height: ");
        o_Height = Console.ReadLine();
    }

    public void ReadParticipantsChoice(out string o_UserChoice)
    {
        Console.WriteLine($"Please enter {eUserChoice.PLAY_AI} to play against the AI, or {eUserChoice.PLAY_PLAYER} to play agains another player.");
        Console.Write("Enter your choice: ");
        o_UserChoice = Console.ReadLine();
    }
}