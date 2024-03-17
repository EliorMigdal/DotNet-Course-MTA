namespace Ex04.Menus.Delegates
{
    public class MainMenu : Menu
    {
        public MainMenu() : base(true) { }

        public MainMenu(string i_Title) : base(true)
        {
            Title = i_Title;
        }
    }
}