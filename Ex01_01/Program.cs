using static System.Console;

namespace Ex01_01
{
    public class Program
    {
        public static void Main(string[] args)
        {
            runProgram();
        }

        public static void runProgram()
        {
            WriteLine($"Welcome to our program!\nPlease enter 3 9-digit positive binary numbers.");
            WriteLine("First number: ");
            int firstDecimal = readInputAndConvertToDecimal();

            WriteLine("Second number: ");
            int secondDecimal = readInputAndConvertToDecimal();

            WriteLine("Third number: ");
            int thirdDecimal = readInputAndConvertToDecimal();
        }

        public static int readInputAndConvertToDecimal()
        {
            string input = ReadLine();

            while (isInputValid(input) == false)
            {
                WriteLine($"{input} is an invalid input! Please enter a 9-digit positive binary number.");
                input = ReadLine();
            }

            return convertBinaryToDecimal(input);
        }

        public static bool isInputValid(string i_Input)
        {
            bool isInputValid = true;

            for (int i = 0; i < i_Input.Length && isInputValid == true; i++)
            {
                if (i_Input[i] != '0' && i_Input[i] != '1')
                {
                    isInputValid = false;
                }
            }

            return isInputValid;
        }

        public static int convertBinaryToDecimal(string i_Binary)
        {
            int decimalNumber = 0;

            for (int i = 0; i < i_Binary.Length; i++)
            {
                if (i_Binary[i] == '1')
                {
                    decimalNumber += (int) Math.Pow(2, i_Binary.Length - i);
                }
            }

            return decimalNumber;
        }
    }
}
