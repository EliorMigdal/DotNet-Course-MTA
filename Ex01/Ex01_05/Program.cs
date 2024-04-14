using System;
using System.Text;

namespace Ex01_05
{
    public class Program
    {
        public static void Main()
        {
            runProgram();
        }

        private static void runProgram()
        {
            Console.Write("Hi there! Please enter a 9-digit number: ");
            readInput(out string userInput);
            displayStatistics(userInput);
            Console.WriteLine("Enter 1 to exit...");
            Console.ReadLine();
        }

        private static void readInput(out string o_UserInput)
        {
            string input = Console.ReadLine();

            while (isInputValid(input) == false)
            {
                handleInvalidInput(ref input);
            }

            o_UserInput = input;
        }

        private static bool isInputValid(string i_Input)
        {
            bool isInputValid = i_Input.Length == 9;

            for (int i = 0; i < i_Input.Length && isInputValid == true; i++)
            {
                if (char.IsDigit(i_Input[i]) == false)
                {
                    isInputValid = false;
                }
            }

            return isInputValid;
        }

        private static void handleInvalidInput(ref string io_Input)
        {
            Console.Write($"{io_Input} is an invalid input! Please enter a 9-digit positive number: ");
            io_Input = Console.ReadLine();
        }

        private static void displayStatistics(string i_Input)
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine(string.Format(Environment.NewLine + "Some statistics regarding the number {0}:", i_Input));
            stringBuilder.AppendLine(string.Format("1. The largest digit in {0} is {1}",
                i_Input, extractMaxDigit(i_Input)));
            stringBuilder.AppendLine(string.Format("2. The smallest digit in {0} is {1}",
                i_Input, extractMinDigit(i_Input)));
            stringBuilder.AppendLine(string.Format("3. The number of digits in {0} that divide by 4 is {1}",
                i_Input, countDividingByFour(i_Input)));
            stringBuilder.AppendLine(string.Format("4. The number of digits in {0} that " +
                "are bigger than its unity digit, {1}, is {2}", i_Input, i_Input[i_Input.Length - 1], countNumOfGreaterThanUnityDigit(i_Input)));
            stringBuilder.AppendLine(string.Format("5. The average of {0}'s digits is {1}", i_Input,
                calculateDigitsAverage(i_Input)));

            Console.Write(stringBuilder.ToString());
        }

        private static int extractMaxDigit(string i_Number)
        {
            int maxDigit = int.MinValue;

            for (int i = 0; i < i_Number.Length; i++)
            {
                if (int.Parse(i_Number[i].ToString()) >= maxDigit)
                {
                    maxDigit = int.Parse(i_Number[i].ToString());
                }
            }

            return maxDigit;
        }

        private static int extractMinDigit(string i_Number)
        {
            int minDigit = int.MaxValue;

            for (int i = 0; i < i_Number.Length; i++)
            {
                if (int.Parse(i_Number[i].ToString()) <= minDigit)
                {
                    minDigit = int.Parse(i_Number[i].ToString());
                }
            }

            return minDigit;
        }

        private static int countDividingByFour(string i_Number)
        {
            int output = 0;

            for (int i = 0; i < i_Number.Length; i++)
            {
                if (int.Parse(i_Number[i].ToString()) % 4 == 0)
                {
                    output++;
                }
            }

            return output;
        }

        private static int countNumOfGreaterThanUnityDigit(string i_Number)
        {
            int output = 0, unityDigit = int.Parse(i_Number[i_Number.Length - 1].ToString());

            for (int i = 0; i < i_Number.Length - 1; i++)
            {
                if (int.Parse(i_Number[i].ToString()) > unityDigit)
                {
                    output++;
                }
            }

            return output;
        }

        private static float calculateDigitsAverage(string i_Number)
        {
            return (float)(sumDigits(i_Number) / (float)i_Number.Length);
        }

        private static int sumDigits(string i_Number)
        {
            int output = 0;

            for (int i = 0; i < i_Number.Length; i++)
            {
                output += int.Parse(i_Number[i].ToString());
            }

            return output;
        }
    }
}
