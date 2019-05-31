using System;
using System.Globalization;
using System.Linq;
using WalutyBusinessLogic.LoadingFromFile;
using WalutyBusinessLogic.Models;

namespace WalutyBusinessLogic.CurrenciesComparision
{
    public class CurrenciesComparator
    {
        private readonly ILoader _loader;
        public string FileExtension { get; set; }

        public CurrenciesComparator(ILoader loader)
        {
            _loader = loader;
            FileExtension = ".txt";
        }

        public CurrenciesComparatorModel CompareCurrencies(CurrenciesComparatorModel model)
        {
            Currency firstCurrency = _loader.LoadCurrencyFromFile(model.FirstCurrencyCode + FileExtension);
            Currency secondCurrency = _loader.LoadCurrencyFromFile(model.SecondCurrencyCode + FileExtension);

            CurrencyRecord firstCurrencyRecord =
                firstCurrency.ListOfRecords.Single(currency => currency.Date == model.Date);
            CurrencyRecord secondCurrencyRecord =
                secondCurrency.ListOfRecords.Single(currency => currency.Date == model.Date);

            float firstCloseValue = firstCurrencyRecord.Close;
            float secondCloseValue = secondCurrencyRecord.Close;

            float comparision = firstCloseValue / secondCloseValue;

            model.ComparatorResult = $"In day {model.Date.ToShortDateString()} {firstCurrency.Name} is worth {comparision} {secondCurrency.Name}";
            return model;
        }
    }
}
