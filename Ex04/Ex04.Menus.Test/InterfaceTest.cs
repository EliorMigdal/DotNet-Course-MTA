using Ex04.Menus.Interface;
using System.Linq;
using System;

namespace Menus.Test
{
    internal class InterfaceTest : IMenuItemObserver
    {
        public void RunTest()
        {
            MainMenu mainMenu = generateMenu();
            mainMenu.Show();
        }

        private MainMenu generateMenu()
        {
            MainMenu mainMenu = new MainMenu("Interface Main Menu");
            MenuItem dateAndTimeMenu = new MenuItem("Show Date/Time");
            MenuItem versionAndCapsMenu = new MenuItem("Version and Capitals");
            MenuItem showDateItem = new MenuItem("Show Date");
            MenuItem showTimeItem = new MenuItem("Show Time");
            MenuItem countCapitalsItem = new MenuItem("Count Capitals");
            MenuItem showVersionItem = new MenuItem("Show Version");

            showDateItem.AddObserver(this);
            showTimeItem.AddObserver(this);
            countCapitalsItem.AddObserver(this);
            showVersionItem.AddObserver(this);
            dateAndTimeMenu.AddMenuItem(showDateItem);
            dateAndTimeMenu.AddMenuItem(showTimeItem);
            versionAndCapsMenu.AddMenuItem(countCapitalsItem);
            versionAndCapsMenu.AddMenuItem(showVersionItem);
            mainMenu.AddMenuItem(dateAndTimeMenu);
            mainMenu.AddMenuItem(versionAndCapsMenu);

            return mainMenu;
        }

        public void NotifyChoice(string i_Title)
        {
            switch (i_Title)
            {
                case "Show Date":
                    showDate();
                    break;

                case "Show Time":
                    showTime();
                    break;

                case "Count Capitals":
                    countCapitals();
                    break;

                case "Show Version":
                    showVersion();
                    break;

                default:
                    break;
            }
        }

        private void showDate()
        {
            Console.WriteLine("Current Date is: " + DateTime.Now.Date.ToShortDateString());
        }

        private void showTime()
        {
            Console.WriteLine("The hour is: " + DateTime.Now.ToShortTimeString());
        }

        private void countCapitals()
        {
            Console.WriteLine("Please enter your sentence:");
            string userInput = Console.ReadLine();
            Console.WriteLine($"There are {userInput.Count(char.IsUpper)} capital letters in your sentence.");
        }

        private void showVersion()
        {
            Console.WriteLine("Version: 24.1.4.9633");
        }
    }
}