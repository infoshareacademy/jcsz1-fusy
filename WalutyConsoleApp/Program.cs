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
            StreamReader streamReader = loader.LoadStreamFromFile("Gbp.txt");
            List<string> lines = loader.GetLinesFromStreamReader(streamReader);

            Currency currency = loader.GetCurrency(lines);

           
            
              
            Console.ReadKey();
        }
    }
}
