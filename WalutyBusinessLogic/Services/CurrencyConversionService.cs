using System;
using System.Collections.Generic;
using System.Linq;
using WalutyBusinessLogic.LoadingFromFile;
using WalutyBusinessLogic.DatabaseLoading;
using WalutyBusinessLogic.Models;
using System.Threading.Tasks;

namespace WalutyBusinessLogic.Services
{
    public class CurrencyConversionService : ICurrencyConversionServices
    {
        private readonly ICurrencyRepository _repository;

        public CurrencyConversionService(ICurrencyRepository repository)
        {
            _repository = repository;
        }

        public async Task<CurrencyConversionModel> CalculateAmountForCurrencyConversion(CurrencyConversionModel currencyConversionModel)
        {
            CurrencyRecord firstDesiredCurrency = await GetDesiredCurrency(currencyConversionModel.FirstCurrency, currencyConversionModel.Date);
            CurrencyRecord secondDesiredCurrency = await GetDesiredCurrency(currencyConversionModel.SecondCurrency, currencyConversionModel.Date);
            currencyConversionModel.AmountSecondCurrency = currencyConversionModel.AmountFirstCurrency * firstDesiredCurrency.Close / secondDesiredCurrency.Close;
            return currencyConversionModel;
            
        }

        private async Task<CurrencyRecord> GetDesiredCurrency(string nameCurrency, DateTime date)
        {
            nameCurrency += ".txt";
            Currency currency = await _repository.GetCurrency(nameCurrency);
            List<CurrencyRecord> listOfRecords = currency.ListOfRecords;
            CurrencyRecord desiredRecord = listOfRecords.SingleOrDefault(record => record.Date == date);
            return desiredRecord;
        }
    }
}
