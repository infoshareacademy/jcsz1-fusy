using System;
using System.Collections.Generic;
using System.Linq;
using WalutyBusinessLogic.LoadingFromFile;

namespace WalutyBusinessLogic
{
    public class CurrencyConvertion
    {
        public float ValueFirstCurrency { get; set; }
        public float ValueSecondCurrency { get; set; }

        public float ConvertCurrency(float amountFirstCurrency, string firstNameCurrency,
            string secondNameCurrency, int date)
        {
            CurrencyRecord FirstDesiredCurrency = GetDesiredCurrency(firstNameCurrency, date);
            ValueFirstCurrency = FirstDesiredCurrency.Close;
            CurrencyRecord SecondDesiredCurrency = GetDesiredCurrency(secondNameCurrency, date);
            ValueSecondCurrency = SecondDesiredCurrency.Close;
            return amountFirstCurrency * ValueFirstCurrency / ValueSecondCurrency;
        }

        private CurrencyRecord GetDesiredCurrency(string nameCurrency,int  date)
        {
            Loader loader = new Loader();
            Currency currency = loader.LoadCurrencyFromFile(nameCurrency);
            List<CurrencyRecord> listOfRecords = currency.ListOfRecords;
            CurrencyRecord desiredRecord = listOfRecords.SingleOrDefault(record => record.Date == date);
            return desiredRecord; 
        }
    }
}
