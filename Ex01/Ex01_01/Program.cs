using System;
using System.Text;

namespace Ex01_01
{
    public class Program
    {
        public static void Main()
        {
            runProgram();
        }

        private static void runProgram()
        {
            string firstBinaryInput, secondBinaryInput, thirdBinaryInput;
            int firstDecimal, secondDecimal, thirdDecimal;

            Console.WriteLine($"Welcome to our program!\nPlease enter 3 9-digit positive binary numbers.");
            readInput(out firstBinaryInput, out secondBinaryInput, out thirdBinaryInput);
            firstDecimal = convertBinaryToDecimal(firstBinaryInput);
            secondDecimal = convertBinaryToDecimal(secondBinaryInput);
            thirdDecimal = convertBinaryToDecimal(thirdBinaryInput);
            displayConversionOutputSorted(firstDecimal, secondDecimal, thirdDecimal);
            Console.WriteLine("Some statistics about your input:");
            displayBinaryInputStatistics(firstBinaryInput, secondBinaryInput, thirdBinaryInput);
            displayDecimalInputStatistics(firstDecimal, secondDecimal, thirdDecimal);
            Console.WriteLine("Enter 1 to exit...");
            Console.ReadLine();
        }

        private static void readInput(out string o_FirstInput, out string o_SecondInput, out string o_ThirdInput)
        {
            o_FirstInput = readANumber();
            o_SecondInput = readANumber();
            o_ThirdInput = readANumber();
        }

        private static string readANumber()
        {
            string userInput;

            do
            {
                Console.Write("Please enter a number: ");
                userInput = Console.ReadLine();
            } while (!isInputValid(userInput));

            return userInput;
        }

        private static void handleInvalidInput(ref string io_Input)
        {
            Console.Write($"{io_Input} is an invalid input! Please enter a 9-digit positive binary number: ");
            io_Input = Console.ReadLine();
        }

        private static void displayConversionOutputSorted(int i_FirstDecimal, int i_SecondDecimal, int i_ThirdDecimal)
        {
            int maxOfThree = Math.Max(i_FirstDecimal, Math.Max(i_SecondDecimal, i_ThirdDecimal));
            int minOfThree = Math.Min(i_FirstDecimal, Math.Min(i_SecondDecimal, i_ThirdDecimal));
            int middleValue = i_FirstDecimal + i_SecondDecimal + i_ThirdDecimal - maxOfThree - minOfThree;

            Console.WriteLine($"You have entered the following numbers, sorted in ascending order: " +
                $"{minOfThree}, {middleValue}, {maxOfThree}.");
        }

        private static void displayBinaryInputStatistics(string i_FirstBinary, string i_SecondBinary, string i_ThirdBinary)
        {
            StringBuilder stringBuilder = new StringBuilder();
            string formattedString;

            stringBuilder.Append("The average number of zeroes in your input is ");
            formattedString = string.Format("{0} zeroes per number.", ((float)(countNumOfZeroes(i_FirstBinary)
                + countNumOfZeroes(i_SecondBinary) + countNumOfZeroes(i_ThirdBinary)) / 3));
            stringBuilder.AppendLine(formattedString);

            stringBuilder.Append("The average number of ones in your input is ");
            formattedString = string.Format("{0} ones per number.", ((float)(countNumOfOnes(i_FirstBinary)
                + countNumOfOnes(i_SecondBinary) + countNumOfOnes(i_ThirdBinary)) / 3));
            stringBuilder.AppendLine(formattedString);

            Console.Write(stringBuilder.ToString());         
        }

        private static void displayDecimalInputStatistics(int i_FirstDecimal, int i_SecondDecimal, int i_ThirdDecimal)
        {
            StringBuilder stringBuilder = new StringBuilder();
            string formattedString;

            stringBuilder.Append("You have entered ");
            formattedString = string.Format("{0} numbers that are power of 2, and {1} " +
                "numbers that their digits are an ascending seris.",
                countPowerOfTwo(i_FirstDecimal, i_SecondDecimal, i_ThirdDecimal),
                numOfAscendingSeries(i_FirstDecimal, i_SecondDecimal, i_ThirdDecimal));
            stringBuilder.AppendLine(formattedString);

            formattedString = string.Format("The maximum of your input is: {0}" + Environment.NewLine +
                "The minimum of your input is: {1}",
                Math.Max(Math.Max(i_FirstDecimal, i_SecondDecimal), i_ThirdDecimal),
                Math.Min(Math.Min(i_FirstDecimal, i_SecondDecimal), i_ThirdDecimal));
            stringBuilder.AppendLine(formattedString);

            Console.Write(stringBuilder.ToString());
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

        private static int convertBinaryToDecimal(string i_Binary)
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

        private static int countNumOfZeroes(string i_Binary)
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

        private static int countNumOfOnes(string i_Binary)
        {
            return 9 - countNumOfZeroes(i_Binary);
        }

        private static short countPowerOfTwo(int i_FirstInput, int i_SecondInput, int i_ThirdInput)
        {
            short output = 0;

            if (isPowerOfTwo(i_FirstInput))
            {
                output++;
            }

            if (isPowerOfTwo(i_SecondInput))
            {
                output++;
            }

            if (isPowerOfTwo(i_ThirdInput))
            {
                output++;
            }

            return output;
        }

        private static bool isPowerOfTwo(int i_Number)
        {
            return isPowerOfTwo((float) i_Number);
        }

        private static bool isPowerOfTwo(float i_Number)
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
                isPowerOfTwo = Program.isPowerOfTwo(i_Number / 2f);
            }

            return isPowerOfTwo;
        }

        private static short numOfAscendingSeries(int i_FirstInput, int i_SecondInput, int i_ThirdInput)
        {
            short output = 0;

            if (isAnAscendingSeries(i_FirstInput))
            {
                output++;
            }

            if (isAnAscendingSeries(i_SecondInput))
            {
                output++;
            }

            if (isAnAscendingSeries(i_ThirdInput))
            {
                output++;
            }

            return output;
        }

        private static bool isAnAscendingSeries(int i_Number)
        {
            bool isAscending = true;
            int currentDigit = i_Number % 10, previousDigit;

            i_Number /= 10;

            while (i_Number > 0 && isAscending)
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