using System;

namespace Ex04.Menus.Delegates
{
    public class MenuItem : MainMenu
    {
        public event Action ItemSelection;

        public MenuItem() : base(false) { }

        public MenuItem(string i_Title) : base(false)
        {
            Title = i_Title;
        }

        public virtual void OnItemSelection()
        {
            if (ItemSelection != null)
            {
                ItemSelection.Invoke();
            }

            else if (m_MenuItems != null)
            {
                Show();
            }
        }
    }
}