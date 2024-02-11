using System.Text;
using static System.Console;

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
            ReadInput(out string userInput);
            DisplayStatistics(userInput);
        }

        public static void ReadInput(out string o_UserInput)
        {
            string input = ReadLine();

            while (IsInputValid(input) == false)
            {
                HandleInvalidInput(ref input);
            }

            o_UserInput = input;
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

        public static void DisplayStatistics(string i_Input)
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine(string.Format("\nSome statistics regarding the number {0}:", i_Input));
            stringBuilder.AppendLine(string.Format("1. The largest digit in {0} is {1}", i_Input, ExtractMaxDigit(i_Input)));
            stringBuilder.AppendLine(string.Format("2. The smallest digit in {0} is {1}", i_Input, ExtractMinDigit(i_Input)));
            stringBuilder.AppendLine(string.Format("3. The number of digits in {0} that divide by 4 is {1}", i_Input, CountDividingByFour(i_Input)));
            stringBuilder.AppendLine(string.Format("4. The number of digits in {0} that are bigger than its unity digit, {1}, is {2}", i_Input, i_Input[i_Input.Length - 1], CountNumOfGreaterThanUnityDigit(i_Input)));
            stringBuilder.AppendLine(string.Format("5. The average of {0}'s digits is {1}", i_Input, CalculateDigitsAverage(i_Input)));

            Write(stringBuilder.ToString());
        }

        public static int ExtractMaxDigit(string i_Number)
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

        public static int ExtractMinDigit(string i_Number)
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

        public static int CountDividingByFour(string i_Number)
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

        public static int CountNumOfGreaterThanUnityDigit(string i_Number)
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

        public static float CalculateDigitsAverage(string i_Number)
        {
            return (float)((float)SumDigits(i_Number) / (float)i_Number.Length);
        }

        public static int SumDigits(string i_Number)
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
