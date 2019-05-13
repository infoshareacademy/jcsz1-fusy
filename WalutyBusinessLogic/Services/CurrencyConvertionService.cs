using System;
using System.Collections.Generic;
using System.Linq;
using WalutyBusinessLogic.LoadingFromFile;
using WalutyMVCWebApp.Services;

namespace WalutyBusinessLogic.Models.Services
{
    public class CurrencyConvertionService //: ICurrencyConvertionServices
    {
        private readonly ILoader _loader;

        public CurrencyConvertionService(ILoader loader)
        {
            _loader = loader;
        }

        public CurrencyConvertionModel CalculateAmountForCurrencyConvertion(CurrencyConvertionModel currencyConvertionModel)
        {
            CurrencyRecord firstDesiredCurrency = GetDesiredCurrency(currencyConvertionModel.FirstCurrency, currencyConvertionModel.Date);
            CurrencyRecord secondDesiredCurrency = GetDesiredCurrency(currencyConvertionModel.SecondCurrency, currencyConvertionModel.Date);
            currencyConvertionModel.AmountSecondCurrency = currencyConvertionModel.AmountFirstCurrency * firstDesiredCurrency.Close / secondDesiredCurrency.Close;
            return currencyConvertionModel;
            
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
