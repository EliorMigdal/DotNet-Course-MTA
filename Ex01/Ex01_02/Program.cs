using static System.Console;

namespace Ex01_02
{
    public class Program
    {
        public static void Main()
        {
            const int k_Height = 9;

            PrintDiamond(k_Height);
        }

        public static void PrintDiamond(int i_Height)
        {
            PrintTriangleOfStars(i_Height, i_Height);
            PrintTriangleUpSideDown(i_Height - 2, i_Height);
        }

        public static void PrintTriangleOfStars(int i_Height, int i_OriginalHeight)
        {
            if (i_Height >= 1)
            {
                PrintTriangleOfStars(i_Height - 2, i_OriginalHeight);
                PrintRowOfStars(i_Height, i_OriginalHeight);
            }
        }

        public static void PrintTriangleUpSideDown(int i_Height, int i_OriginalHeight)
        {
            if (i_Height >= 1)
            {
                PrintRowOfStars(i_Height, i_OriginalHeight);
                PrintTriangleUpSideDown(i_Height - 2, i_OriginalHeight);
            }
        }

        public static void PrintRowOfStars(int i_CurrentRowLen, int i_LongestRowLen)
        {
            int spaces = (i_LongestRowLen - i_CurrentRowLen) / 2;

            WriteLine(new string('*', i_CurrentRowLen).PadLeft(i_CurrentRowLen + spaces));
        }
    }
}
