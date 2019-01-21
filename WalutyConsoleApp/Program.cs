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
            loader.LoadFromFile("Gbp.txt");

           
            
              
            Console.ReadKey();
        }
    }
}
