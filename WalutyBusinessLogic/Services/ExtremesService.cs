using System;
using System.Collections.Generic;
using WalutyBusinessLogic.DatabaseLoading;
using System.Linq;
using WalutyBusinessLogic.LoadingFromFile;
using WalutyBusinessLogic.Models;
using System.Threading.Tasks;

namespace WalutyBusinessLogic.Services
{
    public class ExtremesServices
    {
        private readonly ICurrencyRepository _repository;

        public ExtremesServices(ICurrencyRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<string>> GetGlobalExtremes()
        {
            List<string> AllGlobalExtremeValuesList = new List<string>();
            List<Currency> AllCurrenciesList = await _repository.GetAllCurrencies();
            foreach (var currency in AllCurrenciesList)
            {
                GlobalExtremeValueModel extremeValue = new GlobalExtremeValueModel();
                List<CurrencyRecord> ListOfRecords = await GetCurrencyList(currency.Name);
                extremeValue.NameCurrency = currency.Name;
                extremeValue.MaxValue = ListOfRecords.Max(c => c.High);
                extremeValue.MinValue = ListOfRecords.Min(c => c.Low);
                string ExtremeValueResult = $"For {extremeValue.NameCurrency}: " +
                    $"\n -Max value is {extremeValue.MaxValue}, \n -Min value is {extremeValue.MinValue}";
                AllGlobalExtremeValuesList.Add(ExtremeValueResult);
            }
            return AllGlobalExtremeValuesList;
        }

        public async Task<LocalExtremeValueModel> GetLocalExtremes(LocalExtremeValueModel extremeValue)
        {
            List<CurrencyRecord> ListOfRecords = await GetCurrencyList(extremeValue.NameCurrency);
            extremeValue.MaxValue = ListOfRecords.Where
                (c => c.Date >= extremeValue.StartDate && c.Date <= extremeValue.EndDate)
                .Max(c => c.High);
            extremeValue.MinValue = ListOfRecords.Where
                (c => c.Date >= extremeValue.StartDate && c.Date <= extremeValue.EndDate)
                .Min(c => c.Low);
            return extremeValue;
        }

        private async Task<List<CurrencyRecord>> GetCurrencyList(string codeCurrency)
        {
            codeCurrency += ".txt";
            Currency currency = await _repository.GetCurrency(codeCurrency);
            List<CurrencyRecord> listOfRecords = currency.ListOfRecords;
            return listOfRecords;
        }
    }
}
