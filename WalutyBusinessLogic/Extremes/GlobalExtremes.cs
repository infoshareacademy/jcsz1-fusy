using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WalutyBusinessLogic.CurrencyConversion;
using  WalutyBusinessLogic.LoadingFromFile;

namespace WalutyBusinessLogic.GlobaExtremes
{
    public class GlobalExtremes
    {

        public ExtremeValue GetGlobaExtreme(string nameCurrency)
        {
            ExtremeValue extremeValue = new ExtremeValue();
            nameCurrency += ".txt";
            Loader loader = new Loader();
            CurrencyRecord currencyRecord = new CurrencyRecord();
            Currency currency = loader.LoadCurrencyFromFile(nameCurrency);
            List<CurrencyRecord> listOfRecords = currency.ListOfRecords;
            extremeValue.MaxValue = listOfRecords.Max(c=> c.High);
            extremeValue.MinValue = listOfRecords.Min(c => c.Low);
            return extremeValue;
        }

    }

    class LocalExtremes
    {
        public ExtremeValue GetLocalExtreme(string nameCurrency, int date, int date2)
        {
            ExtremeValue extremeValue = new ExtremeValue();
            nameCurrency += ".txt";
            Loader loader = new Loader();
            CurrencyRecord currencyRecord = new CurrencyRecord();
            Currency currency = loader.LoadCurrencyFromFile(nameCurrency);
            List<CurrencyRecord> listOfRecords = currency.ListOfRecords;
            var e = listOfRecords.Select(c => c.Date > date && c.Date < date2 )
                                                 .Max(c => c.);
            return extremeValue;
        }
    }
    

    public class ExtremeValue
    {
        public float MaxValue { get; set; }
        public float MinValue { get; set; }
    }
}
