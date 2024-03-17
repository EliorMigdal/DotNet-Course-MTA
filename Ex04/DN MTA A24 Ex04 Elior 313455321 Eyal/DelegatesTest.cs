using Ex04.Menus.Delegates;
using System.Linq;
using System;

namespace Menus.Test
{
    internal class DelegatesTest
    {
        public void RunTest()
        {
            MainMenu mainMenu = generateMenu();
            mainMenu.Show();
        }

        private MainMenu generateMenu()
        {
            MainMenu mainMenu = new MainMenu("Delegates Main Menu");
            MenuItem dateAndTimeMenu = new MenuItem("Show Date/Time");
            MenuItem versionAndCapsMenu = new MenuItem("Version and Capitals");
            MenuItem showDateItem = new MenuItem("Show Date");
            MenuItem showTimeItem = new MenuItem("Show Time");
            MenuItem countCapitalsItem = new MenuItem("Count Capitals");
            MenuItem showVersionItem = new MenuItem("Show Version");

            showDateItem.ItemSelection += menuItemShowDate_Selection;
            showTimeItem.ItemSelection += menuItemShowTime_Selection;
            countCapitalsItem.ItemSelection += menuItemCountCapitals_Selection;
            showVersionItem.ItemSelection += menuItemShowVersion_Selection;
            dateAndTimeMenu.AddMenuItem(showDateItem);
            dateAndTimeMenu.AddMenuItem(showTimeItem);
            versionAndCapsMenu.AddMenuItem(countCapitalsItem);
            versionAndCapsMenu.AddMenuItem(showVersionItem);
            mainMenu.AddMenuItem(dateAndTimeMenu);
            mainMenu.AddMenuItem(versionAndCapsMenu);

            return mainMenu;
        }

        private void menuItemShowDate_Selection()
        {
            Console.WriteLine("Current Date is: " + DateTime.Now.Date.ToShortDateString());
        }

        private void menuItemShowTime_Selection()
        {
            Console.WriteLine("The hour is: " + DateTime.Now.ToShortTimeString());
        }

        private void menuItemCountCapitals_Selection()
        {
            Console.WriteLine("Please enter your sentence:");
            string userInput = Console.ReadLine();
            Console.WriteLine($"There are {userInput.Count(char.IsUpper)} capital letters in your sentence.");
        }

        private void menuItemShowVersion_Selection()
        {
            Console.WriteLine("Version: 24.1.4.9633");
        }
    }
}