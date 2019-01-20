using System;
using System.IO;
using WalutyBusinessLogic.LoadingFromFile;

namespace WalutyConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Loader loader = new Loader();
            StreamReader loadFromFile = loader.LoadFromFile("GBP");

            Console.WriteLine(loadFromFile);
        }
    }
}
