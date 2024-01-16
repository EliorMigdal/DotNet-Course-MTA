using System.Text;
using static System.Console;
using static System.Math;

namespace Ex01_05
{
    public class Program
    {
        public static void Main()
        {
            RunProgram();
        }

        public static void RunProgram()
        {
            Write("Hi there! Please enter a 9-digit number: ");
            string input = ReadLine();

            while (IsInputValid(input) == false)
            {
                HandleInvalidInput(ref input);
            }

            int parsedInput = int.Parse(input);
            DisplayStatistics(parsedInput);
        }

        public static bool IsInputValid(string i_Input)
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

        public static void HandleInvalidInput(ref string io_Input)
        {
            Write($"{io_Input} is an invalid input! Please enter a 9-digit positive number: ");
            io_Input = ReadLine();
        }

        public static void DisplayStatistics(int i_Input)
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine(string.Format("\nSome statistics regarding the number {0}:", i_Input));
            stringBuilder.AppendLine(string.Format("1. The largest digit in {0} is {1}", i_Input, ExtractMaxDigit(i_Input)));
            stringBuilder.AppendLine(string.Format("2. The smallest digit in {0} is {1}", i_Input, ExtractMinDigit(i_Input)));
            stringBuilder.AppendLine(string.Format("3. The number of digits in {0} that divide by 4 is {1}", i_Input, CountDividingByFour(i_Input)));
            stringBuilder.AppendLine(string.Format("4. The number of digits in {0} that are bigger than its unity digit, {1}, is {2}", i_Input, i_Input % 10, CountNumOfGreaterThanUnityDigit(i_Input)));
            stringBuilder.AppendLine(string.Format("5. The average of {0}'s digits is {1}", i_Input, CalculateDigitsAverage(i_Input)));

            Write(stringBuilder.ToString());
        }

        public static int ExtractMaxDigit(int i_Number)
        {
            int maxDigit = int.MinValue;

            while (i_Number > 0)
            {
                maxDigit = Max(maxDigit, i_Number % 10);
                i_Number /= 10;
            }

            return maxDigit;
        }

        public static int ExtractMinDigit(int i_Number)
        {
            int minDigit = int.MaxValue;

            while (i_Number > 0)
            {
                minDigit = Min(minDigit, i_Number % 10);
                i_Number /= 10;
            }

            return minDigit;
        }

        public static int CountDividingByFour(int i_Number)
        {
            int output = 0;

            while (i_Number > 0)
            {
                if ((i_Number % 10) % 4 == 0)
                {
                    output++;
                }

                i_Number /= 10;
            }

            return output;
        }

        public static int CountNumOfGreaterThanUnityDigit(int i_Number)
        {
            int output = 0;
            int unityDigit = i_Number % 10;
            i_Number /= 10;

            while (i_Number > 0)
            {
                if (i_Number % 10 > unityDigit)
                {
                    output++;
                }

                i_Number /= 10;
            }

            return output;
        }

        public static float CalculateDigitsAverage(int i_Number)
        {
            return (float)((float)SumDigits(i_Number) / (float)CountNumOfDigits(i_Number));
        }

        public static int SumDigits(int i_Number)
        {
            int output = 0;

            while (i_Number > 0)
            {
                output += i_Number % 10;
                i_Number /= 10;
            }

            return output;
        }

        public static int CountNumOfDigits(int i_Number)
        {
            int output = 0;

            while (i_Number > 0)
            {
                output++;
                i_Number /= 10;
            }

            return output;
        }
    }
}
