using System;
using System.Collections.Generic;

namespace WalutyConsoleApp
{
    class DrawMenu
    {
        private static int _index = 0;

        public static void drawPressAnyKey()
        {
            Console.WriteLine("");
            drawMenuHelper("Press any key to exit");
        }

        public static void drawSubMenuBody(string show)
        {
            Console.Clear();
            drawMenuHeader();
            Console.WriteLine($"{show}");
        }

        public static void drawMenuHeader()
        {
            Console.WriteLine("========================== Welcome in WALUTY 2.0 ==========================");
            Console.WriteLine("");
            Console.WriteLine("");
        }

        public static void drawMenuHelper(string show)
        {
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine("");
            }
            Console.WriteLine($"{show}");
        }

        public static string drawMenu(List<string> items)
        {
            drawMenuHeader();
            for (int i = 0; i < items.Count; i++)
            {
                if (i == _index)
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

                    if (_index == items.Count - 1)
                    {
                        _index = 0;
                    }
                    else { _index++; }
                    break;

                case ConsoleKey.UpArrow:
                    if (_index <= 0)
                    {
                        _index = items.Count - 1;
                    }
                    else { _index--; }
                    break;

                case ConsoleKey.Enter:
                    Console.Clear();
                    return items[_index];

                default:
                    Console.Clear();
                    return "";
            }

            Console.Clear();
            return "0";
        }
    }
}
