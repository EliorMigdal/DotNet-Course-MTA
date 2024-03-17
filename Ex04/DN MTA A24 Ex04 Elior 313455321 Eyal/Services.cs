using System.Linq;
using System;

namespace Ex04.Menus
{
    internal class Services
    {
        public static void ShowDate()
        {
            Console.WriteLine("Current Date is: " + DateTime.Now.Date.ToShortDateString());
        }

        public static void ShowTime()
        {
            Console.WriteLine("The hour is: " + DateTime.Now.ToShortTimeString());
        }

        public static void CountCapitals()
        {
            Console.WriteLine("Please enter your sentence:");
            string userInput = Console.ReadLine();
            Console.WriteLine($"There are {userInput.Count(char.IsUpper)} capital letters in your sentence.");
        }

        public static void ShowVersion()
        {
            Console.WriteLine("Version: 24.1.4.9633");
        }
    }
}