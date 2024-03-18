using System.Collections.Generic;
using System;
using System.Linq;

namespace Ex04.Menus.Delegates
{
    public class MainMenu
    {
        public string Title { get; set; }
        protected LinkedList<MenuItem> m_MenuItems = null;
        protected readonly bool m_TopLevel;

        public MainMenu(bool i_TopLevel)
        {
            m_TopLevel = i_TopLevel;
        }

        public MainMenu(string i_Title)
        {
            m_TopLevel = true;
            Title = i_Title;
        }

        public void AddMenuItem(MenuItem i_MenuItem)
        {
            if (m_MenuItems == null)
            {
                m_MenuItems = new LinkedList<MenuItem>();
            }

            m_MenuItems.AddLast(i_MenuItem);
        }

        public void Show()
        {
            int userDecision;

            do
            {
                do
                {
                    Console.WriteLine($"**{Title}**");
                    Console.WriteLine("----------------------");
                    displayItems();
                    Console.WriteLine("----------------------");
                } while (!validateUserInput(readUserInput(), out userDecision));

                Console.Clear();

                if (userDecision != 0)
                {
                    m_MenuItems.ElementAt(userDecision - 1).NotifySelection();
                }

            } while (userDecision != 0);
        }

        private void displayItems()
        {
            int counter = 1;

            foreach (MenuItem item in m_MenuItems)
            {
                Console.WriteLine($"{counter++} -> {item.Title}");
            }

            Console.WriteLine($"0 -> {(m_TopLevel ? "Exit" : "Back")}");
        }

        private string readUserInput()
        {
            Console.Write($"Please make your choice, or enter '0' to {(m_TopLevel ? "exit" : "go back")}: ");
            return Console.ReadLine();
        }

        private bool validateUserInput(string i_userInput, out int o_userDecision)
        {
            bool isParsable, inRange = false;

            isParsable = int.TryParse(i_userInput, out o_userDecision);

            if (isParsable)
            {
                inRange = isInRange(o_userDecision);

                if (!inRange)
                {
                    Console.WriteLine($"{o_userDecision} is out of the menu's options range!");
                }
            }

            else
            {
                Console.WriteLine($"{i_userInput} cannot be parsed as an integer.");
            }

            return isParsable && inRange;
        }

        private bool isInRange(int i_userDecision)
        {
            return i_userDecision >= 0 && i_userDecision <= m_MenuItems.Count;
        }
    }
}