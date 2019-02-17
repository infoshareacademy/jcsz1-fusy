using System;
using System.Linq;
using System.Collections.Generic;
using WalutyBusinessLogic.LoadingFromFile;
using System.Globalization;
using WalutyBusinessLogic.CurrenciesComparision;

namespace Console_Menu
{
    class Program
    {
        private static int index = 0;

        public static class MenuItem
        {
            public const string
                item1 = "SHOW ENTRIES FROM DATA RANGE",
                item2 = "SHOW CURRENCIES IN PARTICULAR DAY",
                item3 = "SHOW SUPPORTED CURRENCIES",
                item4 = "COMPARE CURRENCIES",
                exit = "EXIT";
        }

        private static void Main(string[] args)
        {
            List<string> menuItems = new List<string>() {
                MenuItem.item1,
                MenuItem.item2,
                MenuItem.item3,
                MenuItem.item4,
                MenuItem.exit
            };

            Console.CursorVisible = false;
            while (true)
            {
                string selectedMenuItem = drawMenu(menuItems);

                switch (selectedMenuItem)
                {
                    case MenuItem.item1:
                        drawSubMenuBody(MenuItem.item1);
                        ShowSingleCurrencyEntriesByDataRange();
                        Console.WriteLine("");
                        Console.WriteLine("Press any key to exit");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case MenuItem.item2:
                        drawSubMenuBody(MenuItem.item2);
                        ShowSingleCurrencyEntriesBySingleDate();
                        Console.WriteLine("");
                        Console.WriteLine("Press any key to exit");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case MenuItem.item3:
                        drawSubMenuBody(MenuItem.item3);
                        ShowSupportedCurencies();
                        drawSubMenuHelper();
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case MenuItem.item4:
                        drawSubMenuBody(MenuItem.item4);
                        CompareTwoCurrenciesBySingleDate();
                        drawSubMenuHelper();
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
            // drawMenuHelper("Press any key to exit");
        }

        private static void drawSubMenuHelper()
        {
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
        // IEnumerator<Loader> enumerator = getCurrency.GetEnumerator();

        public static void RunLoader()
        {
            Loader loader = new Loader();
            var getCurrency = loader.LoadCurrencyFromFile("GBP.txt");


            foreach (var item in getCurrency.ListOfRecords)
            {
                Console.WriteLine($"Date= {item.Date} Open= {item.Open} High= {item.High} Low= {item.Low} Close= {item.Close}");
            }

            Console.WriteLine("");
            Console.WriteLine(getCurrency.ListOfRecords.Count);

            // var currenciesFromRange = getCurrency.ListOfRecords.OrderByDescending(c => c.Date).Where(c => c.Date > 2000106).Where(c => c.Date < 20010106);
            // IEnumerable<CurrencyRecord> currenciesFromRange = getCurrency.ListOfRecords.Where(c => c.Date > 2000106 && c.Date < 20010106);
            IEnumerable<CurrencyRecord> currenciesFromRange = getCurrency.ListOfRecords.Where(c => c.Date < 20010106 && c.Date > 2000106);

            //var zapytanie = from data in currenciesFromRange
            //                where data.Date

            IEnumerable<CurrencyRecord> currenciesFromRange1 =
                getCurrency.ListOfRecords.Where(c => c.Date < 2001010)
                    .Where(c => c.Date > 2000106);

            Console.WriteLine("");

            foreach (var item in currenciesFromRange)
            {
                Console.WriteLine($"Date= {item.Date} Open= {item.Open} High= {item.High} Low= {item.Low} Close= {item.Close}");
            }

            Console.WriteLine("");
            Console.WriteLine(getCurrency.ListOfRecords.Count);


            var getCurrencies = loader.GetListOfAllCurrencies();

            Console.Write(getCurrencies);

            Console.WriteLine("");
            foreach (var item in getCurrencies)
            {
                Console.Write($" {item.Name} ");
            }


            var getFileNames = loader.GetAvailableTxtFileNames();


            for (int i = 0; i < getFileNames.Count; i++)
            {
                Console.WriteLine($"Name= {getFileNames}");
            }


            List<string> list = loader.GetAvailableTxtFileNames();

            // Console.Write(getCurrency.ListOfRecords.); LINQ
        }

        public static void ShowSingleCurrencyEntriesByDataRange()
        {
            
            var _inputCurrency    = "GBP.txt";
            var _inputCurrencyTxt = "GBP";

            var _startDate = "";
            var _endDate = "";

            Loader loader = new Loader();
            var getCurrency = loader.LoadCurrencyFromFile("GBP.txt");

            Console.WriteLine();
            Console.WriteLine("Supported currencies : ");
            ShowSupportedCurencies();

            Console.WriteLine();
            Console.WriteLine();
            Console.Write("Enter currency : ");
            _inputCurrency = Console.ReadLine().ToUpper();
            _inputCurrencyTxt = String.Concat(_inputCurrency.ToUpper(), ".txt");
            getCurrency = loader.LoadCurrencyFromFile(_inputCurrencyTxt);

            _startDate = getCurrency.ListOfRecords.Min(x => x.Date).ToString();          
            _endDate = getCurrency.ListOfRecords.Max(x => x.Date).ToString();

            Console.WriteLine($"For {_inputCurrency} we have the range of dates you can take: ");
            Console.WriteLine();
            Console.WriteLine($"Start date : {_startDate.ToString()} End date : {_endDate} ");
            //Console.WriteLine($"Start date : {_startDate.ToString("MMMM dd, yyyy", "pl-PL")} End date : {_endDate} ");

            Console.WriteLine();

            Console.WriteLine();
            Console.Write("Enter start Date : ");
            _startDate = Console.ReadLine();

            Console.WriteLine();
            Console.Write("Enter end Date : ");
            _endDate = Console.ReadLine();
            //_endDate = Convert.ToInt32(_endDate);

            // ===================================================================================================
            //var currenciesInRange = getCurrency.ListOfRecords.Where(c => c.Date > 20011010 && c.Date < 20021010);

            //foreach (CurrencyRecord record in currenciesInRange)
            //{
            //    Console.WriteLine($"{record.Date} {record.Close}");
            //}
            // ===================================================================================================            
            //var currenciesInRange = getCurrency.ListOfRecords.Where(c => c.Date > Convert.ToInt32(_startDate) && c.Date < Convert.ToInt32(_endDate));

            //foreach (CurrencyRecord record in currenciesInRange)
            //{
            //    Console.WriteLine($"{record.Date} {record.Close}");
            //}
            // ===================================================================================================

            List<CurrencyRecord> listOfFilteredRecords = new List<CurrencyRecord>();
            foreach (var record in getCurrency.ListOfRecords)
            {
                if (record.Date > Convert.ToInt32(_startDate) && record.Date < Convert.ToInt32(_endDate))
                {
                    listOfFilteredRecords.Add(record);
                }
            }
            foreach (var filteredRecord in listOfFilteredRecords)
            {
                Console.WriteLine($"Date= {filteredRecord.Date} Open= {filteredRecord.Open} High= {filteredRecord.High} Low= {filteredRecord.Low} Close= {filteredRecord.Close}");
            }
        }

        public static void ShowSingleCurrencyEntriesBySingleDate()
        {

            var _inputCurrency = "GBP.txt";
            var _inputCurrencyTxt = "GBP";

            var _startDate = "";
            var _endDate = "";

            Loader loader = new Loader();
            var getCurrency = loader.LoadCurrencyFromFile("GBP.txt");

            Console.WriteLine();
            Console.WriteLine("Supported currencies : ");
            ShowSupportedCurencies();

            Console.WriteLine();
            Console.WriteLine();
            Console.Write("Enter currency : ");
            _inputCurrency = Console.ReadLine().ToUpper();
            _inputCurrencyTxt = String.Concat(_inputCurrency.ToUpper(), ".txt");
            getCurrency = loader.LoadCurrencyFromFile(_inputCurrencyTxt);

            _startDate = getCurrency.ListOfRecords.Min(x => x.Date).ToString();
            _endDate = getCurrency.ListOfRecords.Max(x => x.Date).ToString();

            Console.WriteLine($"For {_inputCurrency} we have the range of dates you can take: ");
            Console.WriteLine();
            Console.WriteLine($"Start date : {_startDate.ToString()} End date : {_endDate} ");
            //Console.WriteLine($"Start date : {_startDate.ToString("MMMM dd, yyyy", "pl-PL")} End date : {_endDate} ");

            Console.WriteLine();

            Console.WriteLine();
            Console.Write("Enter single Date : ");
            _startDate = Console.ReadLine();


            List<CurrencyRecord> listOfFilteredRecords = new List<CurrencyRecord>();
            foreach (var record in getCurrency.ListOfRecords)
            {
                if (record.Date > Convert.ToInt32(_startDate) && record.Date == Convert.ToInt32(_endDate))
                {
                    listOfFilteredRecords.Add(record);
                }
            }
            foreach (var filteredRecord in listOfFilteredRecords)
            {
                Console.WriteLine($"Date= {filteredRecord.Date} Open= {filteredRecord.Open} High= {filteredRecord.High} Low= {filteredRecord.Low} Close= {filteredRecord.Close}");
            }
        }

        public static void CompareTwoCurrenciesBySingleDate()
        {

            var _inputCurrency1 = "GBP.txt";
            var _inputCurrency1Txt = "GBP";

            var _inputCurrency2 = "AUD.txt";
            var _inputCurrency2Txt = "AUD";

            var _CurrentDate = "";
            var _startDate = "";
            var _endDate = "";

            Loader loader = new Loader();
            var getCurrency1 = loader.LoadCurrencyFromFile("GBP.txt");
            var getCurrency2 = loader.LoadCurrencyFromFile("AUD.txt");

            Console.WriteLine();
            Console.WriteLine("Supported currencies : ");
            ShowSupportedCurencies();

            Console.WriteLine();
            Console.WriteLine();
            Console.Write("Enter first currency : ");
            _inputCurrency1 = Console.ReadLine().ToUpper();
            _inputCurrency1Txt = String.Concat(_inputCurrency1.ToUpper(), ".txt");
            getCurrency1 = loader.LoadCurrencyFromFile(_inputCurrency1Txt);

            Console.WriteLine();
            Console.Write("Enter second currency : ");
            _inputCurrency2 = Console.ReadLine().ToUpper();
            _inputCurrency2Txt = String.Concat(_inputCurrency2.ToUpper(), ".txt");
            getCurrency2 = loader.LoadCurrencyFromFile(_inputCurrency2Txt);

            // pytanie czy obie waluty maja te same zakresy dat
            _startDate = getCurrency1.ListOfRecords.Min(x => x.Date).ToString();
            _endDate = getCurrency1.ListOfRecords.Max(x => x.Date).ToString();

            Console.WriteLine($"For {_inputCurrency1} we have the range of dates you can take: ");
            Console.WriteLine();
            Console.WriteLine($"Start date : {_startDate.ToString()} End date : {_endDate} ");
            //Console.WriteLine($"Start date : {_startDate.ToString("MMMM dd, yyyy", "pl-PL")} End date : {_endDate} ");

            Console.WriteLine();

            Console.WriteLine();
            Console.Write("Enter date for currencies: ");
            _CurrentDate = Console.ReadLine();

            CurrenciesComparator currencies = new CurrenciesComparator();
            Console.WriteLine(currencies.CompareCurrencies(_inputCurrency1, _inputCurrency2, Convert.ToInt32(_CurrentDate)));

            //List<CurrencyRecord> listOfFilteredRecords = new List<CurrencyRecord>();
            //foreach (var record in getCurrency.ListOfRecords)
            //{
            //    if (record.Date > Convert.ToInt32(_startDate) && record.Date == Convert.ToInt32(_endDate))
            //    {
            //        listOfFilteredRecords.Add(record);
            //    }
            //}
            //foreach (var filteredRecord in listOfFilteredRecords)
            //{
            //    Console.WriteLine($"Date= {filteredRecord.Date} Open= {filteredRecord.Open} High= {filteredRecord.High} Low= {filteredRecord.Low} Close= {filteredRecord.Close}");
            //}
        }

        public static void ShowSupportedCurencies()
        {
            Loader loader = new Loader();
            var getCurrencies = loader.GetListOfAllCurrencies();
            var enumerator = getCurrencies.GetEnumerator();

            while (enumerator.MoveNext())
            {
                Console.Write($"{enumerator.Current.Name} ");
            }
        }
    }
}