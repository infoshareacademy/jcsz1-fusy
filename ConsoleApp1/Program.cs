using System;
using WalutyBusinessLogic.LoadingFromFile;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Loader loader = new Loader();
            var info = loader.LoadCurrencyInformation();
            foreach(var information in info)
            {
                Console.WriteLine($"{information.Code} {information.Name}");
            }
            Console.ReadLine();
        }
    }
}
