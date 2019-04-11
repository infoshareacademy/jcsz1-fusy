using System;
using System.Collections.Generic;
using System.Linq;
using WalutyBusinessLogic.LoadingFromFile;

namespace WalutyBusinessLogic
{
    public class CurrencyConvertion
    {
        public string FirstNameCurrency { get; set; }
        public string SecondNameCurrency { get; set; }

        public CurrencyConvertion(string firstNameCurrency, string secondNameCurrency)
        {
            FirstNameCurrency = firstNameCurrency;
            SecondNameCurrency = secondNameCurrency;
        }

        public float CalculateAmountForCurrencyConvertion(float amountFirstCurrency, int date)
        {
            CurrencyRecord FirstDesiredCurrency = GetDesiredCurrency(FirstNameCurrency , date);
            CurrencyRecord SecondDesiredCurrency = GetDesiredCurrency(SecondNameCurrency , date);
            return amountFirstCurrency * FirstDesiredCurrency.Close / SecondDesiredCurrency.Close;
        }

        private CurrencyRecord GetDesiredCurrency(string nameCurrency, int date)
        {
            Currency currency = Loader.GetLoaderInstance().LoadCurrencyFromFile(nameCurrency);
            List<CurrencyRecord> listOfRecords = currency.ListOfRecords;
            CurrencyRecord desiredRecord = listOfRecords.SingleOrDefault(record => record.Date == date);
            return desiredRecord; 
        }
    }
}
