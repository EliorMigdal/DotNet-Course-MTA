using System.Collections.Generic;

namespace Ex04.Menus.Interface
{
    public class MenuItem : MainMenu
    {
        private LinkedList<IMenuItemObserver> m_ItemObservers = null;

        public MenuItem() : base(false) { }

        public MenuItem(string i_Title) : base(false)
        {
            Title = i_Title;
        }

        public void AddObserver(IMenuItemObserver i_Observer)
        {
            if (m_ItemObservers == null)
            {
                m_ItemObservers = new LinkedList<IMenuItemObserver>();
            }

            m_ItemObservers.AddLast(i_Observer);
        }

        public void RemoveObserver(IMenuItemObserver i_Observer)
        {
            m_ItemObservers?.Remove(i_Observer);
        }

        public void OnSelection()
        {
            if (m_ItemObservers != null)
            {
                foreach (IMenuItemObserver itemObserver in m_ItemObservers)
                {
                    itemObserver.NotifyChoice(Title);
                }
            }

            else if (m_MenuItems != null)
            {
                Show();
            }
        }
    }
}