using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WalutyBusinessLogic.LoadingFromFile;

namespace WalutyMVCWebApp.Services
{
    public class CorrectDate
    {
        public int SetCorrectDate(int dateCurrency, string nameCurrency)
        {
            List<CurrencyRecord> CurrencyDateList = GetCurrencyDateList(nameCurrency);
            if (CurrencyDateList.Any(c => c.Date == dateCurrency))
            {
                return dateCurrency;
            }
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
