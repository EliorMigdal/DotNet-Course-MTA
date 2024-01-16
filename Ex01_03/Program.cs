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
            string input = ReadLine();
            bool successfullyParsed = int.TryParse(input, out int height);

            while (successfullyParsed == false || height < 0)
            {
                string errorMessage = string.Format("{0} is an invalid input!\nWe only accept integers higher or equal to 0.\nPlease try again: ");
                Write(errorMessage);
                input = ReadLine();
                successfullyParsed = int.TryParse(input, out height);
            }

            PrintDiamond(height);
        }

        public static void PrintWelcomeMessage()
        {
            WriteLine("Hi there, and welcome to our diamond printer!");
            Write("Please insert the height of the diamond you would want us to print: ");
        }
    }
}
