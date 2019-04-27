using System;
using System.Collections.Generic;
using System.Linq;
using WalutyBusinessLogic.LoadingFromFile;

namespace WalutyMVCWebApp.Services
{
    public class DateChecker
    {
        public int SetCorrectDateForCurrency(int dateCurrency, string nameCurrency)
        {
            List<CurrencyRecord> CurrencyDateList = GetCurrencyDateList(nameCurrency);
            if (CurrencyDateList.Any(c => c.Date == dateCurrency))
            {
                return dateCurrency;
            }
            else return 0;
        }

        public int SetCorrectDateForTwoCurrencies(int dateCurrency, string firstNameCurrency,
            string secondNameCurrency)
        {
            List<CurrencyRecord> FirstCurrencyDateList = GetCurrencyDateList(firstNameCurrency);
            List<CurrencyRecord> SecondCurrencyDateList = GetCurrencyDateList(secondNameCurrency);
            
            else return 0;
        }

        private List<CurrencyRecord> GetCurrencyDateList(string nameCurrency)
        {
            Loader loader = new Loader();
            Currency currency = loader.LoadCurrencyFromFile(nameCurrency);
            List<CurrencyRecord> CurrencyDateList = currency.ListOfRecords;
            return CurrencyDateList;
        }
    }
}
