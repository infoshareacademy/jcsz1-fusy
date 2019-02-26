using System;
using System.Collections.Generic;
using System.Linq;
using WalutyBusinessLogic.CurrenciesComparision;
using WalutyBusinessLogic.LoadingFromFile;
using WalutyConsoleApp;

namespace Console_Menu
{
    class Program
    {
        private static Loader loader = new Loader();
        private static class MenuItem
        {
            public const string
                item1 = "SHOW SUPPORTED CURRENCIES",
                item2 = "SHOW ALL CURRENCIES IN PARTICULAR DAY",
                item3 = "SHOW ENTRIES FROM DATA RANGE",
                item4 = "COMPARE CURRENCIES",
                item5 = "CONVERT CURRENCY",
                exit = "EXIT";
        }

        private static void Main(string[] args)
        {
            List<string> menuItems = new List<string>() {
                MenuItem.item1,
                MenuItem.item2,
                MenuItem.item3,
                MenuItem.item4,
                MenuItem.item5,
                MenuItem.exit
            };

            Console.CursorVisible = false;
            while (true)
            {
                string selectedMenuItem = DrawMenu.drawMenu(menuItems);

                switch (selectedMenuItem)
                {
                    case MenuItem.item1:
                        DrawMenu.drawSubMenuBody(MenuItem.item1);
                        Console.WriteLine("");
                        ShowSupportedCurencies();
                        DrawMenu.drawPressAnyKey();
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case MenuItem.item2:
                        DrawMenu.drawSubMenuBody(MenuItem.item2);
                        ShowSingleCurrencyEntriesBySingleDate();                        
                        DrawMenu.drawPressAnyKey();
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case MenuItem.item3:
                        DrawMenu.drawSubMenuBody(MenuItem.item3);
                        ShowSingleCurrencyEntriesBetweenDataRange();
                        DrawMenu.drawPressAnyKey();
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case MenuItem.item4:
                        DrawMenu.drawSubMenuBody(MenuItem.item4);
                        CompareTwoCurrenciesBySingleDate();
                        DrawMenu.drawPressAnyKey();
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case MenuItem.item5:
                        DrawMenu.drawSubMenuBody(MenuItem.item5);
                        ShowSupportedCurencies();
                        DrawMenu.drawPressAnyKey();
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

        private static void RunLoader()
        {
            var getCurrency = loader.LoadCurrencyFromFile("GBP.txt");
            var getFileNames = loader.GetAvailableTxtFileNames();
            var getCurrencies = loader.GetListOfAllCurrencies();

            foreach (var item in getCurrency.ListOfRecords)
            {
                Console.WriteLine($"Date= {item.Date} Open= {item.Open} High= {item.High} Low= {item.Low} Close= {item.Close}");
            }

            Console.WriteLine("");
            Console.WriteLine(getCurrency.ListOfRecords.Count);
            IEnumerable<CurrencyRecord> currenciesFromRange = getCurrency.ListOfRecords.Where(c => c.Date < 20010106 && c.Date > 2000106);
            Console.WriteLine("");

            foreach (var item in currenciesFromRange)
            {
                Console.WriteLine($"Date= {item.Date} Open= {item.Open} High= {item.High} Low= {item.Low} Close= {item.Close}");
            }

            Console.WriteLine("");
            Console.WriteLine(getCurrency.ListOfRecords.Count);
            Console.Write(getCurrencies);
            Console.WriteLine("");
            foreach (var item in getCurrencies)
            {
                Console.Write($" {item.Name} ");
            }            

            for (int i = 0; i < getFileNames.Count; i++)
            {
                Console.WriteLine($"Name= {getFileNames}");
            }
            List<string> list = loader.GetAvailableTxtFileNames();
        }

        private static void ShowSingleCurrencyEntriesBetweenDataRange()
        {
            var _getCurrency = loader.LoadCurrencyFromFile("GBP.txt");
            var _inputCurrency    = "GBP.txt";
            var _inputCurrencyTxt = "GBP";
            var _startDate = "";
            var _endDate = "";            
            
            ShowSupportedCurencies();
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("Enter currency : ");
            _inputCurrency = Console.ReadLine().ToUpper();
            _inputCurrencyTxt = String.Concat(_inputCurrency.ToUpper(), ".txt");
            _getCurrency = loader.LoadCurrencyFromFile(_inputCurrencyTxt);
            _startDate = _getCurrency.ListOfRecords.Min(x => x.Date).ToString();          
            _endDate = _getCurrency.ListOfRecords.Max(x => x.Date).ToString();

            Console.WriteLine($"For {_inputCurrency} we have the range of dates you can take: ");
            Console.WriteLine();
            Console.WriteLine($"Start date : {_startDate.ToString()} End date : {_endDate} ");
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("Enter start Date : ");
            _startDate = Console.ReadLine();
            Console.WriteLine();
            Console.Write("Enter end Date : ");
            _endDate = Console.ReadLine();

            List<CurrencyRecord> listOfFilteredRecords = new List<CurrencyRecord>();
            foreach (var record in _getCurrency.ListOfRecords)
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

        private static void ShowSingleCurrencyEntriesBySingleDate()
        {
            var getCurrency = loader.LoadCurrencyFromFile("GBP.txt");
            var _inputCurrency = "GBP.txt";
            var _inputCurrencyTxt = "GBP";
            var _startDate = "";
            var _endDate = "";
            
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

        private static void CompareTwoCurrenciesBySingleDate()
        {
            var _inputCurrency1 = "GBP.txt";
            var _inputCurrency1Txt = "GBP";
            var _inputCurrency2 = "AUD.txt";
            var _inputCurrency2Txt = "AUD";
            var _CurrentDate = "";
            var _startDate = "";
            var _endDate = "";            
            var _getCurrency1 = loader.LoadCurrencyFromFile("GBP.txt");
            var _getCurrency2 = loader.LoadCurrencyFromFile("AUD.txt");

            ShowSupportedCurencies();

            Console.WriteLine();
            Console.WriteLine();
            Console.Write("Enter first currency : ");
            _inputCurrency1 = Console.ReadLine().ToUpper();
            _inputCurrency1Txt = String.Concat(_inputCurrency1.ToUpper(), ".txt");
            _getCurrency1 = loader.LoadCurrencyFromFile(_inputCurrency1Txt);

            Console.WriteLine();
            Console.Write("Enter second currency : ");
            _inputCurrency2 = Console.ReadLine().ToUpper();
            _inputCurrency2Txt = String.Concat(_inputCurrency2.ToUpper(), ".txt");
            _getCurrency2 = loader.LoadCurrencyFromFile(_inputCurrency2Txt);

            _startDate = _getCurrency1.ListOfRecords.Min(x => x.Date).ToString();
            _endDate = _getCurrency1.ListOfRecords.Max(x => x.Date).ToString();

            Console.WriteLine($"For {_inputCurrency1} we have the range of dates you can take: ");
            Console.WriteLine();
            Console.WriteLine($"Start date : {_startDate.ToString()} End date : {_endDate} ");
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("Enter date for currencies: ");
            _CurrentDate = Console.ReadLine();

            CurrenciesComparator currencies = new CurrenciesComparator();
            Console.WriteLine(currencies.CompareCurrencies(_inputCurrency1, _inputCurrency2, Convert.ToInt32(_CurrentDate)));
        }

        private static void ShowSupportedCurencies()
        {
            Loader loader = new Loader();
            var getCurrencies = loader.GetListOfAllCurrencies();
            var enumerator = getCurrencies.GetEnumerator();

            while (enumerator.MoveNext())
            {
                Console.Write($"{enumerator.Current.Name} ");
            }

            Console.WriteLine("Press any key to exit");
        }
    }
}