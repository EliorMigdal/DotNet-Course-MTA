using System;
using System.Text;
using static System.Console;

namespace Ex01_01
{
    public class Program
    {
        public static void Main()
        {
            RunProgram();
        }

        public static void RunProgram()
        {
            string firstBinaryInput, secondBinaryInput, thirdBinaryInput;
            int firstDecimal, secondDecimal, thirdDecimal;

            WriteLine($"Welcome to our program!\nPlease enter 3 9-digit positive binary numbers.");
            ReadInput(out firstBinaryInput, out secondBinaryInput, out thirdBinaryInput);
            firstDecimal = ConvertBinaryToDecimal(firstBinaryInput);
            secondDecimal = ConvertBinaryToDecimal(secondBinaryInput);
            thirdDecimal = ConvertBinaryToDecimal(thirdBinaryInput);
            DisplayConversionOutputSorted(firstDecimal, secondDecimal, thirdDecimal);
            WriteLine("Some statistics about your input:");
            DisplayBinaryInputStatistics(firstBinaryInput, secondBinaryInput, thirdBinaryInput);
            DisplayDecimalInputStatistics(firstDecimal, secondDecimal, thirdDecimal);
        }

        public static void ReadInput(out string o_FirstInput, out string o_SecondInput, out string o_ThirdInput)
        {
            Write("First number: ");
            o_FirstInput = ReadLine();

            while (isInputValid(o_FirstInput) == false)
            {
                HandleInvalidInput(ref o_FirstInput);
            }

            Write("Second number: ");
            o_SecondInput = ReadLine();

            while (isInputValid(o_SecondInput) == false)
            {
                HandleInvalidInput(ref o_SecondInput);
            }

            Write("Third number: ");
            o_ThirdInput = ReadLine();

            while (isInputValid(o_ThirdInput) == false)
            {
                HandleInvalidInput (ref o_ThirdInput);
            }
        }

        public static void HandleInvalidInput(ref string io_Input)
        {
            Write($"{io_Input} is an invalid input! Please enter a 9-digit positive binary number: ");
            io_Input = ReadLine();
        }

        public static void DisplayConversionOutputSorted(int i_FirstDecimal, int i_SecondDecimal, int i_ThirdDecimal)
        {
            int maxOfThree = Math.Max(i_FirstDecimal, Math.Max(i_SecondDecimal, i_ThirdDecimal));
            int minOfThree = Math.Min(i_FirstDecimal, Math.Min(i_SecondDecimal, i_ThirdDecimal));
            int middleValue = i_FirstDecimal + i_SecondDecimal + i_ThirdDecimal - maxOfThree - minOfThree;

            WriteLine($"You have entered the following numbers, sorted in ascending order: {minOfThree}, {middleValue}, {maxOfThree}.");
        }

        public static void DisplayBinaryInputStatistics(string i_FirstBinary, string i_SecondBinary, string i_ThirdBinary)
        {
            StringBuilder stringBuilder = new StringBuilder();
            string formattedString;

            stringBuilder.Append("The average number of zeroes in your input is ");
            formattedString = string.Format("{0} zeroes per number.\n", ((float)(NumOfZeroes(i_FirstBinary) + NumOfZeroes(i_SecondBinary) + NumOfZeroes(i_ThirdBinary)) / 3));
            stringBuilder.Append(formattedString);

            stringBuilder.Append("The average number of ones in your input is ");
            formattedString = string.Format("{0} ones per number.\n", ((float)(NumOfOnes(i_FirstBinary) + NumOfOnes(i_SecondBinary) + NumOfOnes(i_ThirdBinary)) / 3));
            stringBuilder.Append(formattedString);

            Write(stringBuilder.ToString());         
        }

        public static void DisplayDecimalInputStatistics(int i_FirstDecimal, int i_SecondDecimal, int i_ThirdDecimal)
        {
            StringBuilder stringBuilder = new StringBuilder();
            string formattedString;

            stringBuilder.Append("You have entered ");
            formattedString = string.Format("{0} numbers that are power of 2, and {1} numbers that their digits are an ascending seris.\n",
                NumOfPowerOfTwo(i_FirstDecimal, i_SecondDecimal, i_ThirdDecimal), NumOfAscendingSeries(i_FirstDecimal, i_SecondDecimal, i_ThirdDecimal));
            stringBuilder.Append(formattedString);

            formattedString = string.Format("The maximum of your input is: {0}\nThe minimum of your input is: {1}\n",
                Math.Max(Math.Max(i_FirstDecimal, i_SecondDecimal), i_ThirdDecimal), Math.Min(Math.Min(i_FirstDecimal, i_SecondDecimal), i_ThirdDecimal));
            stringBuilder.Append(formattedString);

            Write(stringBuilder.ToString());
        }

        private static bool isInputValid(string i_Input)
        {
            bool isInputValid = i_Input.Length == 9;

            for (int i = 0; i < i_Input.Length && isInputValid == true; i++)
            {
                if (i_Input[i] != '0' && i_Input[i] != '1')
                {
                    isInputValid = false;
                }
            }

            return isInputValid;
        }

        public static int ConvertBinaryToDecimal(string i_Binary)
        {
            int decimalNumber = 0;

            for (int i = 0; i < i_Binary.Length; i++)
            {
                if (i_Binary[i] == '1')
                {
                    decimalNumber += (int)Math.Pow(2, i_Binary.Length - (i + 1));
                }
            }

            return decimalNumber;
        }

        public static int NumOfZeroes(string i_Binary)
        {
            int numOfZeroes = 0;

            for (int i = 0; i < i_Binary.Length; i++)
            {
                if (i_Binary[i] == '0')
                {
                    numOfZeroes++;
                }
            }

            return numOfZeroes;
        }

        public static int NumOfOnes(string i_Binary)
        {
            return 9 - NumOfZeroes(i_Binary);
        }

        public static short NumOfPowerOfTwo(int i_FirstInput, int i_SecondInput, int i_ThirdInput)
        {
            short output = 0;

            if (IsPowerOfTwo(i_FirstInput))
            {
                output++;
            }

            if (IsPowerOfTwo(i_SecondInput))
            {
                output++;
            }

            if (IsPowerOfTwo(i_ThirdInput))
            {
                output++;
            }

            return output;
        }

        public static bool IsPowerOfTwo(int i_Number)
        {
            return IsPowerOfTwo((float) i_Number);
        }

        public static bool IsPowerOfTwo(float i_Number)
        {
            bool isPowerOfTwo;

            if (i_Number == 0f)
            {
                isPowerOfTwo = false;
            }

            else if (i_Number == 1f || i_Number == 2f)
            {
                isPowerOfTwo = true;
            }

            else
            {
                isPowerOfTwo = IsPowerOfTwo(i_Number / 2f);
            }

            return isPowerOfTwo;
        }

        public static short NumOfAscendingSeries(int i_FirstInput, int i_SecondInput, int i_ThirdInput)
        {
            short output = 0;

            if (IsAnAscendingSeries(i_FirstInput))
            {
                output++;
            }

            if (IsAnAscendingSeries(i_SecondInput))
            {
                output++;
            }

            if (IsAnAscendingSeries(i_ThirdInput))
            {
                output++;
            }

            return output;

        }

        public static bool IsAnAscendingSeries(int i_Number)
        {
            bool isAscending = true;
            int currentDigit = i_Number % 10, previousDigit;
            i_Number /= 10;

            while (i_Number > 0 && isAscending == true)
            {
                previousDigit = currentDigit;
                currentDigit = i_Number % 10;

                if (previousDigit <= currentDigit)
                {
                    isAscending = false;
                }

                i_Number /= 10;
            }

            return isAscending;
        }
    }
}
