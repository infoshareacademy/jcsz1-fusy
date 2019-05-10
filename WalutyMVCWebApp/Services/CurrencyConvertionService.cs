using System;
using System.Collections.Generic;
using System.Linq;
using WalutyBusinessLogic.LoadingFromFile;
using WalutyMVCWebApp.Models;

namespace WalutyMVCWebApp.Services
{
    public class CurrencyConvertionService 
    {
        private readonly ILoader _loader;

        public CurrencyConvertionService(ILoader loader)
        {
            _loader = loader;
            CurrencyConvertionModel currencyConvertionModel = new CurrencyConvertionModel();
        }

        public float CalculateAmountForCurrencyConvertion(CurrencyConvertionModel currencyConvertionModel)
        {
            CurrencyRecord firstDesiredCurrency = GetDesiredCurrency(currencyConvertionModel.FirstCurrency, currencyConvertionModel.Date);
            CurrencyRecord secondDesiredCurrency = GetDesiredCurrency(currencyConvertionModel.SecondCurrency, currencyConvertionModel.Date);
            return currencyConvertionModel.AmountFirstCurrency * firstDesiredCurrency.Close / secondDesiredCurrency.Close;
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
