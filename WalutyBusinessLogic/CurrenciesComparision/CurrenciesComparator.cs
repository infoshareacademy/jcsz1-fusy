using System;
using System.Globalization;
using System.Linq;
using WalutyBusinessLogic.LoadingFromFile;

namespace WalutyBusinessLogic.CurrenciesComparision
{
    public class CurrenciesComparator
    {
        private readonly Loader loader = new Loader();
        public string FileExtension { get; set; }

        public CurrenciesComparator()
        {
            FileExtension = ".txt";
        }

        public CurrenciesComparator(string fileExtension)
        {
            FileExtension = fileExtension;
        }

        public string CompareCurrencies(string firstCurrencyCode, string secondCurrencyCode, int date)
        {
            try
            {
                DateTime dateFromInt = DateTime.ParseExact(date.ToString(), "yyyyMMdd", CultureInfo.InvariantCulture);

                Currency firstCurrency = loader.LoadCurrencyFromFile(firstCurrencyCode + FileExtension);
                Currency secondCurrency = loader.LoadCurrencyFromFile(secondCurrencyCode + FileExtension);

                CurrencyRecord firstCurrencyRecord =
                    firstCurrency.ListOfRecords.Single(currency => currency.Date == date);
                CurrencyRecord secondCurrencyRecord =
                    secondCurrency.ListOfRecords.Single(currency => currency.Date == date);

                float firstCloseValue = firstCurrencyRecord.Close;
                float secondCloseValue = secondCurrencyRecord.Close;

                float comparision = firstCloseValue / secondCloseValue;

                return
                    $"Dnia {dateFromInt.ToShortDateString()} {firstCurrency.Name} jest warta {comparision} {secondCurrency.Name}";
            }
            catch (Exception e)
            {
                return "Elo zle";
            }
        }

        // CompareCurrencies(string firstCurrencyCode, string secondCurrencyCode, int date) usage example:

        //CurrenciesComparator currencies = new CurrenciesComparator();
        //Console.WriteLine(currencies.CompareCurrencies("GBP", "EUR", 20141010));
        //Console.ReadKey();
    }
}
