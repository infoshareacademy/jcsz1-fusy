using System;
using System.Globalization;
using System.Linq;
using WalutyBusinessLogic.LoadingFromFile;

namespace WalutyBusinessLogic.CurrenciesComparision
{
    public class CurrenciesComparator
    {
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
                DateTime dateFromInt = DateTime.ParseExact(date.ToString(), "yyyyMMdd", CultureInfo.InvariantCulture);

                Currency firstCurrency = Loader.GetLoaderInstance().LoadCurrencyFromFile(firstCurrencyCode + FileExtension);
                Currency secondCurrency = Loader.GetLoaderInstance().LoadCurrencyFromFile(secondCurrencyCode + FileExtension);

                CurrencyRecord firstCurrencyRecord =
                    firstCurrency.ListOfRecords.Single(currency => currency.Date == date);
                CurrencyRecord secondCurrencyRecord =
                    secondCurrency.ListOfRecords.Single(currency => currency.Date == date);

                float firstCloseValue = firstCurrencyRecord.Close;
                float secondCloseValue = secondCurrencyRecord.Close;

                float comparision = firstCloseValue / secondCloseValue;

                return $"In day {dateFromInt.ToShortDateString()} {firstCurrency.Name} is worth {comparision} {secondCurrency.Name}";
        }
        // ...
        // CompareCurrencies(string firstCurrencyCode, string secondCurrencyCode, int date) usage example:

        //CurrenciesComparator currencies = new CurrenciesComparator();
        //Console.WriteLine(currencies.CompareCurrencies("GBP", "EUR", 20141010));
        //Console.ReadKey();
    }
}
