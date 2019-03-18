using System;
using System.Collections.Generic;
using System.Linq;
using WalutyBusinessLogic.LoadingFromFile;

namespace WalutyBusinessLogic
{
    public class CurrencyConvertion
    {
        private float ValueFirstCurrency { get; set; }
        private float AmountFirstCurrency { get; set; }
        private float ValueSecondCurrency { get; set; }
        private float AmountSecondCurrency { get; set; }
        
        public float ConvertCurrency(float amountFirstCurrency, string firstNameCurrency,
            string secondNameCurrency, int date)
        {
            AmountFirstCurrency = amountFirstCurrency;
            CurrencyRecord FirstDesiredCurrency = GetDesiredCurrency(firstNameCurrency, date);
            ValueFirstCurrency = FirstDesiredCurrency.Close;
            CurrencyRecord SecondDesiredCurrency = GetDesiredCurrency(secondNameCurrency, date);
            ValueSecondCurrency = SecondDesiredCurrency.Close;
            AmountSecondCurrency = amountFirstCurrency * ValueFirstCurrency / ValueSecondCurrency;
            return AmountSecondCurrency;
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
