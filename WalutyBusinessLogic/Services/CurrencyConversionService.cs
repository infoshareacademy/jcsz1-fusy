using System;
using System.Collections.Generic;
using System.Linq;
using WalutyBusinessLogic.LoadingFromFile;
using WalutyBusinessLogic.Models;

namespace WalutyBusinessLogic.Services
{
    public class CurrencyConversionService : ICurrencyConversionServices
    {
        private readonly ILoader _loader;

        public CurrencyConversionService(ILoader loader)
        {
            _loader = loader;
        }

        public CurrencyConversionModel CalculateAmountForCurrencyConversion(CurrencyConversionModel currencyConversionModel)
        {
            CurrencyRecord firstDesiredCurrency = GetDesiredCurrency(currencyConversionModel.FirstCurrency, currencyConversionModel.Date);
            CurrencyRecord secondDesiredCurrency = GetDesiredCurrency(currencyConversionModel.SecondCurrency, currencyConversionModel.Date);
            currencyConversionModel.AmountSecondCurrency = currencyConversionModel.AmountFirstCurrency * firstDesiredCurrency.Close / secondDesiredCurrency.Close;
            return currencyConversionModel;
            
        }

        private CurrencyRecord GetDesiredCurrency(string nameCurrency, DateTime date)
        {
            nameCurrency += ".txt";
            Currency currency = _loader.LoadCurrencyFromFile(nameCurrency);
            List<CurrencyRecord> listOfRecords = currency.ListOfRecords;
            CurrencyRecord desiredRecord = listOfRecords.SingleOrDefault(record => record.Date == date);
            return desiredRecord;
        }
    }
}
