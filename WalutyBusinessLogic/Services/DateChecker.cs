using System;
using System.Collections.Generic;
using System.Linq;
using WalutyBusinessLogic.LoadingFromFile;

namespace WalutyBusinessLogic.Models.Services
{
    public class DateChecker : IDateChecker
    {
        public DateTime? CheckeDateForCurrency(DateTime dateCurrency, string nameCurrency)
        {
            List<CurrencyRecord> CurrencyDateList = GetRecordDateList(nameCurrency);
            if (CurrencyDateList.Any(c => c.Date == dateCurrency))
            {
                return dateCurrency;
            }
            else return null;
        }

        public DateTime? CheckDateForTwoCurrencies(DateTime dateCurrency, string firstNameCurrency,
            string secondNameCurrency)
        {
            List<CurrencyRecord> FirstCurrencyRecordList = GetRecordDateList(firstNameCurrency);
            List<CurrencyRecord> SecondCurrencyRecordList = GetRecordDateList(secondNameCurrency);
            if(FirstCurrencyRecordList.Any(c=> c.Date ==dateCurrency) 
            && SecondCurrencyRecordList.Any(c=> c.Date == dateCurrency))
            {
                return dateCurrency;
            }
            else return null;
        }

        private List<CurrencyRecord> GetRecordDateList(string nameCurrency)
        {
            Loader loader = new Loader();
            Currency currency = loader.LoadCurrencyFromFile(nameCurrency);
            List<CurrencyRecord> CurrencyDateList = currency.ListOfRecords;
            return CurrencyDateList;
        }
    }
}
