using static Ex01_02.Program;
using static System.Console;

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
        }

        public static void PrintWelcomeMessage()
        {
            WriteLine("Hi there, and welcome to our diamond printer!");
            Write("Please insert the height of the diamond you would want us to print: ");
        }

        public static void ReadInput(out int o_UserInput)
        {
            string input = ReadLine();
            bool successfullyParsed = int.TryParse(input, out o_UserInput);

            while (successfullyParsed == false || o_UserInput < 1)
            {
                string errorMessage = string.Format("{0} is an invalid input!\nWe only accept integers higher or equal to 1.\nPlease try again: ", input);
                Write(errorMessage);
                input = ReadLine();
                successfullyParsed = int.TryParse(input, out o_UserInput);
            }
        }
    }
}
