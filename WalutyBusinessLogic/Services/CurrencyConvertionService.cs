using System;
using System.Collections.Generic;
using System.Linq;
using WalutyBusinessLogic.LoadingFromFile;
using WalutyMVCWebApp.Services;

namespace WalutyBusinessLogic.Models.Services
{
    public class CurrencyConvertionService : ICurrencyConvertionServices
    {
        private readonly ILoader _loader;

        public CurrencyConvertionService(ILoader loader)
        {
            _loader = loader;
        }

        public CurrencyConvertionModel CalculateAmountForCurrencyConvertion(DateTime date,
            string firstCurrency, string secondCurrency, float amountFirstCurrency)
        {
            CurrencyConvertionModel currencyConvertionModel = new CurrencyConvertionModel();
            currencyConvertionModel.FirstCurrency = firstCurrency;
            currencyConvertionModel.SecondCurrency = secondCurrency;
            currencyConvertionModel.Date = date;
            currencyConvertionModel.AmountFirstCurrency = amountFirstCurrency;
            firstCurrency += ".txt";
            secondCurrency += ".txt";
            CurrencyRecord firstDesiredCurrency = GetDesiredCurrency(firstCurrency, date);
            CurrencyRecord secondDesiredCurrency = GetDesiredCurrency(secondCurrency, date);
            currencyConvertionModel.AmountSecondCurrency = amountFirstCurrency * firstDesiredCurrency.Close / secondDesiredCurrency.Close;
            return currencyConvertionModel;
            
        }

        private CurrencyRecord GetDesiredCurrency(string nameCurrency, DateTime date)
        {
            Currency currency = _loader.LoadCurrencyFromFile(nameCurrency);
            List<CurrencyRecord> listOfRecords = currency.ListOfRecords;
            CurrencyRecord desiredRecord = listOfRecords.SingleOrDefault(record => record.Date == date);
            return desiredRecord;
        }
    }
}
