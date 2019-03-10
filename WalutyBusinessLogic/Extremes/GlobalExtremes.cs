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
            ExtremeValue _extremeValue = new ExtremeValue();
            nameCurrency += ".txt";
            Loader loader = new Loader();
            CurrencyRecord currencyRecord = new CurrencyRecord();
            Currency currency = loader.LoadCurrencyFromFile(nameCurrency);
            List<CurrencyRecord> listOfRecords = currency.ListOfRecords;
            _extremeValue.MaxValue = listOfRecords.Max(c=> c.High);
            _extremeValue.MinValue = listOfRecords.Min(c => c.Low);
            return _extremeValue;
        }



    }

    public class ExtremeValue
    {
        public float MaxValue { get; set; }
        public float MinValue { get; set; }
    }
}
