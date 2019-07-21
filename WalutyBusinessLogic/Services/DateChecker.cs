using System;
using System.Collections.Generic;
using WalutyBusinessLogic.DatabaseLoading;
using System.Linq;
using WalutyBusinessLogic.LoadingFromFile;
using System.Threading.Tasks;

namespace WalutyBusinessLogic.Services
{
    public class DateChecker : IDateChecker
    {
        private readonly ICurrencyRepository _repository;

        public DateChecker(ICurrencyRepository repository )
        {
            _repository = repository;
        }

        public async Task<bool> CheckingIfDateExistsForTwoCurrencies(DateTime dateCurrency, string firstNameCurrency,
            string secondNameCurrency)
        {
            List<CurrencyRecord> FirstCurrencyRecordList = await GetRecordDateList(firstNameCurrency);
            List<CurrencyRecord> SecondCurrencyRecordList = await GetRecordDateList(secondNameCurrency);
            if ((FirstCurrencyRecordList.Any(c => c.Date == dateCurrency))
            && (SecondCurrencyRecordList.Any(c => c.Date == dateCurrency)))
            {
                return true;
            }
            else return false;
        }

        public async Task<bool> CheckingIfDateExistInRange(DateTime firstDate, DateTime secondDate, string currencyName)
        {
            List<CurrencyRecord> CurrencyRecordList = await GetRecordDateList(currencyName);
            if (CurrencyRecordList.Exists(c => c.Date >= firstDate) &&
                CurrencyRecordList.Exists(c => c.Date <= secondDate))
            {
                if (!CurrencyRecordList.Where(c => c.Date >= firstDate && c.Date <= secondDate).Any())
                {
                    return false;
                }
                return true;
            }
            else return false;
        }

        private async Task<List<CurrencyRecord>> GetRecordDateList(string nameCurrency)
        {
            nameCurrency += ".txt";
            Currency currency = await _repository.GetCurrency(nameCurrency);
            List<CurrencyRecord> CurrencyDateList = currency.ListOfRecords;
            return CurrencyDateList;
        }
    }
}

