using static System.Console;

namespace Ex01_04
{
    public class Program
    {
        public static void Main(string[] args)
        {
            runProgram("abbbbbbbbbbbbba");
        }

        public static void runProgram(string i_String)
        {
            WriteLine($"Is {i_String} a palindrome? {(isPalindrome(i_String) ? "Yes!" : "No!" )}");

            if (isANumber(i_String, out int parsedNumber) == true)
            {
                WriteLine($"Does {i_String} divide by 5? {(parsedNumber % 5 == 0 ? "Yes!" : "No!")}");
            }

            else
            {
                WriteLine($"Number of lowercase letters in {i_String}: {countLowerCase(i_String)}");
            }
        }

        public static bool isPalindrome(string i_String)
        {
            if (i_String.Length <= 1)
            {
                return true;
            }

            else
            {
                return i_String[0] == i_String[i_String.Length - 1]
                    && isPalindrome(i_String.Substring(1, i_String.Length - 2));
            }
        }

        public static bool isANumber(string i_String, out int o_ParsedNumber)
        {
            return int.TryParse(i_String, out o_ParsedNumber);
        }

        public static int countLowerCase (string i_String)
        {
            int output = 0;

            for (int i = 0; i < i_String.Length; i++)
            {
                if (i_String[i] >= 'a' && i_String[i] <= 'z')
                {
                    output++;
                }
            }

            return output;
        }
    }
}
