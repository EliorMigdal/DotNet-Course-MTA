using System;
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
            int input = ReadInputAndParse();

            Console.WriteLine($"Some statistics regarding the number {input}:");
            Console.WriteLine($"1. The largest digit in {input} is {ExtractMaxDigit(input)}");
            Console.WriteLine($"2. The smallest digit in {input} is {ExtractMinDigit(input)}");
            Console.WriteLine($"3. The number of digits in {input} that divide by 4 is {CountDividingByFour(input)}");
            Console.WriteLine($"4. The number of digits in {input} that are bigger than its unity digit, {input % 10}, is {CountNumOfGreaterThanUnityDigit(input)}");
            Console.WriteLine($"5. The average of {input}'s digits is {CalculateDigitsAverage(input)}");
        }

        public static int ReadInputAndParse()
        {
            WriteLine("Hi there! Please enter a 9-digit number:");
            string input = ReadLine();

            return int.Parse(input);
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
