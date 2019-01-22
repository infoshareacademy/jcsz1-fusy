using System;
using System.Collections.Generic;
using System.IO;
using WalutyBusinessLogic.LoadingFromFile;

namespace WalutyConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            // For tests, to be removed later
            Loader loader = new Loader();
            loader.LoadCurrencyFromFile("Gbp.txt");

            foreach(var line in loader.GetAvailableTxtFilesNames())
            {
                Console.WriteLine(line);
            }
            Console.ReadKey();
        }
    }
}
