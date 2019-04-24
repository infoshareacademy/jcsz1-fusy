using System;
using System.Collections.Generic;
using System.Linq;
using WalutyBusinessLogic.LoadingFromFile;

namespace WalutyMVCWebApp.Services
{
    public class CorrectDate
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
            if ((FirstCurrencyDateList.Any(c => c.Date == dateCurrency)) && (SecondCurrencyDateList.Any(c => c.Date == dateCurrency)))
            {
                    return dateCurrency;
            }
            if ((FirstCurrencyDateList[FirstCurrencyDateList.Count - 1].Date < dateCurrency)
            && (SecondCurrencyDateList[SecondCurrencyDateList.Count-1].Date < dateCurrency))
                {
                dateCurrency = Math.Min(SecondCurrencyDateList[SecondCurrencyDateList.Count - 1].Date,
                                        FirstCurrencyDateList[FirstCurrencyDateList.Count - 1].Date);
                return dateCurrency;
                }
            if ((FirstCurrencyDateList[0].Date < dateCurrency)
            && (SecondCurrencyDateList[0].Date < dateCurrency))
            {
                dateCurrency = Math.Max(SecondCurrencyDateList[SecondCurrencyDateList.Count - 1].Date,
                                        FirstCurrencyDateList[FirstCurrencyDateList.Count - 1].Date);
                return dateCurrency;
            }
            //if (
            //    (
            //        (FirstCurrencyDateList[FirstCurrencyDateList.Count - 1].Date < dateCurrency)
            //        && (SecondCurrencyDateList.Any(c => c.Date == dateCurrency))
            //    ) || (
            //        ((SecondCurrencyDateList[SecondCurrencyDateList.Count - 1].Date < dateCurrency)
            //        && (FirstCurrencyDateList.Any(c => c.Date == dateCurrency)))
            //    )
            //   )
            //{
            //    dateCurrency =
            //    return 0;
            //}
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
