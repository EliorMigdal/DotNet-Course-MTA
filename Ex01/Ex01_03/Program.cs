using static Ex01_02.Program;
using System;

namespace Ex01_03
{
    public class Program
    {
        public static void Main()
        {
            RunProgram();
        }

        public static void RunProgram()
        {
            PrintWelcomeMessage();
            ReadInput(out int height);

            if (height % 2 == 0)
            {
                height += 1;
            }

            PrintDiamond(height);
            Console.WriteLine("Enter 1 to exit...");
            Console.ReadLine();
        }

        public static void PrintWelcomeMessage()
        {
            Console.WriteLine("Hi there, and welcome to our diamond printer!");
            Console.Write("Please insert the height of the diamond you would want us to print: ");
        }

        public static void ReadInput(out int o_UserInput)
        {
            string input = Console.ReadLine();
            bool successfullyParsed = int.TryParse(input, out o_UserInput);

            while (successfullyParsed == false || o_UserInput < 1)
            {
                string errorMessage = string.Format("{0} is an invalid input!" +
                    Environment.NewLine + "We only accept integers higher or equal to 1." +
                    Environment.NewLine + "Please try again: ", input);

                Console.Write(errorMessage);
                input = Console.ReadLine();
                successfullyParsed = int.TryParse(input, out o_UserInput);
            }
        }
    }
}