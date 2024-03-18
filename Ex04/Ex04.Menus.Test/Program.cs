using System;

namespace Menus.Test
{
    internal class Program
    {
        public static void Main()
        {   
            InterfaceTest interfaceTest = new InterfaceTest();
            DelegatesTest delegatesTest = new DelegatesTest();
            
            interfaceTest.RunTest();
            delegatesTest.RunTest();
            Console.WriteLine("Press enter to exit...");
            Console.ReadLine();
        }
    }
}