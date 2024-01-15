using static System.Console;

namespace Ex01_01
{
    public class Program
    {
        public static void Main(string[] args)
        {
            RunProgram();
        }

        public static void RunProgram()
        {
            WriteLine($"Welcome to our program!\nPlease enter 3 9-digit positive binary numbers.");
            WriteLine("First number: ");
            int firstDecimal = ReadBinaryInputAndConvertToDecimal(out string firstInput);

            WriteLine("Second number: ");
            int secondDecimal = ReadBinaryInputAndConvertToDecimal(out string secondInput);

            WriteLine("Third number: ");
            int thirdDecimal = ReadBinaryInputAndConvertToDecimal(out string thirdInput);

            WriteLine("Some statistics about your input:");
            WriteLine($"The average number of zeroes in your input is {(float)((float)(NumOfZeroes(firstInput) + NumOfZeroes(secondInput) + NumOfZeroes(thirdInput)) / 3)}");
            WriteLine($"The average number of ones in your input is {(float) ((float) (NumOfOnes(firstInput) + NumOfOnes(secondInput) + NumOfOnes(thirdInput)) / 3)}");
            WriteLine($"You have entered {NumOfPowerOfTwo(firstDecimal, secondDecimal, thirdDecimal)} numbers that are power of 2.");
            WriteLine($"You have entered {NumOfAscendingSeries(firstDecimal, secondDecimal, thirdDecimal)} numbers that their digits are an ascending seris.");
            WriteLine($"The maximum of your inputs is: {Math.Max(Math.Max(firstDecimal, secondDecimal), thirdDecimal)}");
            WriteLine($"The minimum of your inputs is: {Math.Min(Math.Min(firstDecimal, secondDecimal), thirdDecimal)}");
        }

        public static int ReadBinaryInputAndConvertToDecimal(out string o_Input)
        {
            o_Input = ReadLine();

            while (isInputValid(o_Input) == false)
            {
                WriteLine($"{o_Input} is an invalid input! Please enter a 9-digit positive binary number.");
                o_Input = ReadLine();
            }

            return ConvertBinaryToDecimal(o_Input);
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
                    decimalNumber += (int) Math.Pow(2, i_Binary.Length - (i + 1));
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
            
            if (IsPowerOfTwo (i_FirstInput))
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
            return Math.Log2(i_Number) - (int) Math.Log2(i_Number) == 0;
        }

        public static short NumOfAscendingSeries(int i_FirstInput, int i_SecondInput, int i_ThirdInput)
        {
            short output = 0;

            if (IsAnAscendingSeries (i_FirstInput))
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
