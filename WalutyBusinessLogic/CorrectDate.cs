using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WalutyBusinessLogic.LoadingFromFile;

namespace WalutyBusinessLogic
{
    class CorrectDate
    {
        public int SetCorrectDate(int dateCurrency, string nameCurrency)
        {
            List<CurrencyRecord> CurrencyDateList = GetCurrencyDateList(nameCurrency);
            if (dateCurrency < CurrencyDateList[0].Date)
            {
                dateCurrency = CurrencyDateList[0].Date;
            }
            if (dateCurrency >= CurrencyDateList[0].Date && dateCurrency <= CurrencyDateList[CurrencyDateList.Count-1].Date)
            {
                dateCurrency = CurrencyDateList[0].Date;
            }
            if (dateCurrency > CurrencyDateList[CurrencyDateList.Count - 1].Date)
            {
                dateCurrency = CurrencyDateList[CurrencyDateList.Count - 1].Date;
            }
            return dateCurrency;
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
