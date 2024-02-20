using System;
using FourInARow.UI.Enums;

namespace FourInARow.UI.Reader
{
    public class InputReader
    {
        public void ReadBoardSize(out string o_Width, out string o_Height)
        {
            Console.WriteLine("Please enter your desired board's size.");
            Console.WriteLine($"Board size is ranged from {(int)eDimensions.MinValue}x{(int)eDimensions.MinValue} " +
                $"to {(int)eDimensions.MaxValue}x{(int)eDimensions.MaxValue}.");
            Console.Write("Please enter board width: ");
            o_Width = Console.ReadLine();
            Console.Write("Please enter board height: ");
            o_Height = Console.ReadLine();
        }

        public void ReadParticipantsChoice(out string o_UserChoice)
        {
            Console.WriteLine($"Please enter {(int)eUserChoice.PlayAI} to play against the AI, " +
                $"or {(int)eUserChoice.PlayAnotherPlayer} to play agains another player.");
            Console.Write("Enter your choice: ");
            o_UserChoice = Console.ReadLine();
        }

        public void ReadMoveChoice(out string o_MoveChoice)
        {
            Console.WriteLine("Please enter a column number to insert your shape,\n" +
                "or enter 'Q' if you would like to forfeit (Your opponent will get 1 point): ");
            o_MoveChoice = Console.ReadLine();
        }

        public void ReadRoundChoice(out string o_RoundChoice)
        {
            Console.Write("Would like to play another round? Enter Y/N: ");
            o_RoundChoice = Console.ReadLine();
        }
    }
}