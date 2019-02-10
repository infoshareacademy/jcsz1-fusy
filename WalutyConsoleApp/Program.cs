using System;
using System.Collections.Generic;

namespace Console_Menu
{
    class Program
    {
        private static int index = 0;


        public static class MenuItem
        {
            public const string
                item1 = "( 1 ) first item",
                item2 = "( 2 ) second item",
                item3 = "( 3 ) third item",
                exit = "(Esc) Exit";
        }

        private static void Main(string[] args)
        {
            List<string> menuItems = new List<string>() {
                MenuItem.item1,
                MenuItem.item2,
                MenuItem.item3,
                MenuItem.exit
            };

            Console.CursorVisible = false;
            while (true)
            {
                string selectedMenuItem = drawMenu(menuItems);

                switch (selectedMenuItem)
                {
                    case MenuItem.item1:                        
                        drawSubMenuBody("Generic FUNCTION ONE");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case MenuItem.item2:                       
                        drawSubMenuBody("Generic FUNCTION SECOND");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case MenuItem.item3:
                        drawSubMenuBody("Generic FUNCTION THIRD");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case MenuItem.exit:
                        Console.Clear();
                        Environment.Exit(0);
                        break;
                    case "0":
                        Console.Clear();
                        break;
                }
            }
        }

        private static string drawMenu(List<string> items)
        {
            drawMenuHeader();
            for (int i = 0; i < items.Count; i++)
            {
                if (i == index)
                {
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.Black;                    
                    Console.WriteLine(items[i]);
                }
                else
                {
                    Console.WriteLine(items[i]);
                }
                Console.ResetColor();
            }

            drawMenuHelper("Go to the item and ENTER");

            ConsoleKeyInfo userKey = Console.ReadKey();


            switch (userKey.Key)
            {
                case ConsoleKey.DownArrow:

                    if (index == items.Count - 1)
                    {
                        index = 0;
                    }
                    else { index++; }
                    break;

                case ConsoleKey.UpArrow:
                    if (index <= 0)
                    {
                        index = items.Count - 1;
                    }
                    else { index--; }
                    break;

                case ConsoleKey.Enter:
                    Console.Clear();
                    return items[index];

                default:
                    Console.Clear();
                    return "";
            }

            Console.Clear();
            return "0";          
        }


        private static void drawMenuHeader()
        {
            Console.WriteLine("========================== Welcome in WALUTY 2.0 ==========================");
            Console.WriteLine("");            
            Console.WriteLine("");
        }

        private static void drawSubMenuBody(string show)
        {
            Console.Clear();                 
            drawMenuHeader();
            Console.WriteLine($"{show}");
            drawMenuHelper("Press any key to exit");
        }
        

        private static void drawMenuHelper(string show)
        {
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine("");
            }
            Console.WriteLine($"{show}");
        }
    }
}