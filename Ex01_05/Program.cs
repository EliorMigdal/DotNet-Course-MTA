using static System.Console;
using static System.Math;

namespace Ex01_05
{
    public class Program
    {
        public static void Main(string[] args)
        {
            runProgram();
        }

        public static void runProgram()
        {
            int input = readInputAndParse();

            Console.WriteLine($"Some statistics regarding the number {input}:");
            Console.WriteLine($"1. The largest digit in {input} is {extractMaxDigit(input)}");
            Console.WriteLine($"2. The smallest digit in {input} is {extractMinDigit(input)}");
            Console.WriteLine($"3. The number of digits in {input} that divide by 4 is {countDividingByFour(input)}");
            Console.WriteLine($"4. The number of digits in {input} that are bigger than its unity digit, {input % 10}, is {countNumOfGreaterThanUnityDigit(input)}");
            Console.WriteLine($"5. The average of {input}'s digits is {calculateDigitsAverage(input)}");
        }

        public static int readInputAndParse()
        {
            WriteLine("Hi there! Please enter a 9-digit number:");
            string input = ReadLine();

            return int.Parse(input);
        }

        public static int extractMaxDigit(int i_Number)
        {
            int maxDigit = int.MinValue;

            while (i_Number > 0) 
            {
                maxDigit = Max(maxDigit, i_Number % 10);
                i_Number /= 10;
            }

            return maxDigit;
        }

        public static int extractMinDigit(int i_Number)
        {
            int minDigit = int.MaxValue;

            while (i_Number > 0)
            {
                minDigit = Min(minDigit, i_Number % 10);
                i_Number /= 10;
            }

            return minDigit;
        }

        public static int countDividingByFour(int i_Number)
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

        public static int countNumOfGreaterThanUnityDigit(int i_Number)
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

        public static float calculateDigitsAverage(int i_Number)
        {
            return (float) ((float) sumDigits(i_Number) / (float) countNumOfDigits(i_Number));
        }

        public static int sumDigits(int i_Number)
        {
            int output = 0;

            while (i_Number > 0)
            {
                output += i_Number % 10;
                i_Number /= 10;
            }

            return output;
        }

        public static int countNumOfDigits(int i_Number)
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
