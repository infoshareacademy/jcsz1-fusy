using System.Collections.Generic;
using System.Linq;
using WalutyBusinessLogic.LoadingFromFile;

namespace WalutyMVCWebApp.Services
{
    public class CurrencyConvertionServices
    {
        public string FirstNameCurrency { get; set; }
        public string SecondNameCurrency { get; set; }

        private readonly ILoader _loader;

        public CurrencyConvertionServices(ILoader loader, string firstNameCurrency, string secondNameCurrency)
        {
            _loader = loader;
            FirstNameCurrency = firstNameCurrency;
            SecondNameCurrency = secondNameCurrency;
        }

        public float CalculateAmountForCurrencyConvertion(float amountFirstCurrency, int date)
        {
            CurrencyRecord firstDesiredCurrency = GetDesiredCurrency(FirstNameCurrency, date);
            CurrencyRecord secondDesiredCurrency = GetDesiredCurrency(SecondNameCurrency, date);
            return amountFirstCurrency * firstDesiredCurrency.Close / secondDesiredCurrency.Close;
        }

        private CurrencyRecord GetDesiredCurrency(string nameCurrency, int date)
        {
            Currency currency = _loader.LoadCurrencyFromFile(nameCurrency);
            List<CurrencyRecord> listOfRecords = currency.ListOfRecords;
            CurrencyRecord desiredRecord = listOfRecords.SingleOrDefault(record => record.Date == date);
            return desiredRecord;
        }
    }
}
