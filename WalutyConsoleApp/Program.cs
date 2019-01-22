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

            var gbp = loader.LoadCurrencyFromFile("gbp.txt");
            Console.WriteLine(gbp.ListOfRecords[0].Volume);
            Console.WriteLine(gbp.ListOfRecords[0].High);
            Console.WriteLine(gbp.ListOfRecords[0].Low);
            Console.WriteLine(gbp.ListOfRecords[0].Open);
            

            Console.ReadKey();
            
            
            foreach(var currency in loader.GetListOfAllCurrencies())
            {
                foreach(var currencyRecord in currency.ListOfRecords)
                {
                    Console.WriteLine(currency.Name + " " + currencyRecord.Date);
                }
            }

            Console.ReadKey();
        }
    }
}
