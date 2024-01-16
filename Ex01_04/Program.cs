using System.Text;
using static System.Console;

namespace Ex01_04
{
    public class Program
    {
        public static void Main(string[] args)
        {
            RunProgram(args[0]);
        }

        public static void RunProgram(string i_String)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(string.Format("Some data about {0}:\n", i_String));

            stringBuilder.Append(string.Format("{0} is{1} a palindrome.\n", i_String, IsPalindrome(i_String) ? "" : " not"));

            if (IsANumber(i_String, out int parsedNumber) == true)
            {
                stringBuilder.Append(string.Format("{0} does{1} divide by 5.\n", i_String, parsedNumber % 5 == 0 ? "" : " not"));
            }

            else
            {
                stringBuilder.Append(string.Format("{0} has {1} lowercase letters.\n", i_String, CountLowerCase(i_String)));
            }

            Write(stringBuilder.ToString());
        }

        public static bool IsPalindrome(string i_String)
        {
            if (i_String.Length <= 1)
            {
                return true;
            }

            else
            {
                return i_String[0] == i_String[i_String.Length - 1]
                    && IsPalindrome(i_String.Substring(1, i_String.Length - 2));
            }
        }

        public static bool IsANumber(string i_String, out int o_ParsedNumber)
        {
            return int.TryParse(i_String, out o_ParsedNumber);
        }

        public static int CountLowerCase(string i_String)
        {
            int output = 0;

            for (int i = 0; i < i_String.Length; i++)
            {
                if (char.IsLower(i_String[i]) == true)
                {
                    output++;
                }
            }

            return output;
        }
    }
}
