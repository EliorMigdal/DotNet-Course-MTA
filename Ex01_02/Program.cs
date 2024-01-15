using static System.Console;

namespace Ex01_02
{
    public class Program
    {
        public static void Main(string[] args)
        {
            const int HEIGHT = 9;

            PrintDiamond(HEIGHT);
        }

        public static void PrintDiamond(int i_Height)
        {
            printTriangle(i_Height, i_Height);
            printTriangleUpSideDown(i_Height - 2, i_Height);
        }

        public static void printTriangle(int i_RecursionHeight, int i_OriginalHeight)
        {
            if (i_RecursionHeight >= 1)
            {
                printTriangle(i_RecursionHeight - 2, i_OriginalHeight);
                printRowOfStars(i_RecursionHeight, i_OriginalHeight);
            }
        }

        public static void printTriangleUpSideDown(int i_RecursionHeight, int i_OriginalHeight)
        {
            if (i_RecursionHeight >= 1)
            {
                printRowOfStars(i_RecursionHeight, i_OriginalHeight);
                printTriangleUpSideDown(i_RecursionHeight - 2, i_OriginalHeight);
            }
        }

        public static void printRowOfStars(int i_CurrentRowLen, int i_LongestRowLen)
        {
            int spaces = (i_LongestRowLen - i_CurrentRowLen) / 2;

            WriteLine(new string('*', i_CurrentRowLen).PadLeft(i_CurrentRowLen + spaces));
        }
    }
}
