using System;
using System.Text;

namespace Ex01_04
{
    public class Program
    {
        public static void Main()
        {
            string userInput = readInput();
            runProgram(userInput);
        }

        private static string readInput()
        {
            string userInput;

            do
            {
                Console.Write("Please enter an input of digits or letters, " +
                    "no longer than 8 characters: ");
                userInput = Console.ReadLine();
            } while (!isInputValid(userInput));

            return userInput;
        }

        private static bool isInputValid(string i_Input)
        {
            bool hasDigit = false, hasLetter = false;

            foreach (char c in i_Input)
            {
                if (char.IsLetter(c))
                {
                    hasLetter = true;
                }

                else if (char.IsDigit(c))
                {
                    hasLetter = true;
                }
            }

            return i_Input.Length >= 0 && i_Input.Length <= 8 && (hasDigit ^ hasLetter);
        }

        private static void runProgram(string i_String)
        {
            StringBuilder stringBuilder = examineString(i_String);
            Console.Write(stringBuilder.ToString());
            Console.WriteLine("Enter 1 to exit...");
            Console.ReadLine();
        }

        private static StringBuilder examineString(string i_String)
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine(string.Format("Some data about {0}: ", i_String));
            stringBuilder.AppendLine(string.Format("{0} is{1} a palindrome.", i_String,
                isPalindrome(i_String) ? string.Empty : " not"));

            if (isANumber(i_String, out int parsedNumber))
            {
                stringBuilder.AppendLine(string.Format("{0} does{1} divide by 5.",
                    i_String, parsedNumber % 5 == 0 ? "" : " not"));
            }

            else
            {
                stringBuilder.AppendLine(string.Format("{0} has {1} lowercase letters.",
                    i_String, countLowerCase(i_String)));
            }

            return stringBuilder;
        }

        private static bool isPalindrome(string i_String)
        {
            bool isPalindrome;

            if (i_String.Length <= 1)
            {
                isPalindrome = true;
            }

            else
            {
                isPalindrome = i_String[0] == i_String[i_String.Length - 1]
                    && Program.isPalindrome(i_String.Substring(1, i_String.Length - 2));
            }

            return isPalindrome;
        }

        private static bool isANumber(string i_String, out int o_ParsedNumber)
        {
            return int.TryParse(i_String, out o_ParsedNumber);
        }

        private static int countLowerCase(string i_String)
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