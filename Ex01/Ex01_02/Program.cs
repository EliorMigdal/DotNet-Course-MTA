using System;

namespace Ex01_02
{
    public class Program
    {
        public static void Main()
        {
            const int k_Height = 9;

            PrintDiamond(k_Height);
            Console.WriteLine("Enter 1 to exit...");
            Console.ReadLine();
        }

        public static void PrintDiamond(int i_Height)
        {
            printTriangleOfStars(i_Height, i_Height);
            printTriangleUpSideDown(i_Height - 2, i_Height);
        }

        private static void printTriangleOfStars(int i_Height, int i_OriginalHeight)
        {
            if (i_Height >= 1)
            {
                printTriangleOfStars(i_Height - 2, i_OriginalHeight);
                printRowOfStars(i_Height, i_OriginalHeight);
            }
        }

        private static void printTriangleUpSideDown(int i_Height, int i_OriginalHeight)
        {
            if (i_Height >= 1)
            {
                printRowOfStars(i_Height, i_OriginalHeight);
                printTriangleUpSideDown(i_Height - 2, i_OriginalHeight);
            }
        }

        private static void printRowOfStars(int i_CurrentRowLen, int i_LongestRowLen)
        {
            int spaces = (i_LongestRowLen - i_CurrentRowLen) / 2;

            Console.WriteLine(new string('*', i_CurrentRowLen).PadLeft(i_CurrentRowLen + spaces));
        }
    }
}