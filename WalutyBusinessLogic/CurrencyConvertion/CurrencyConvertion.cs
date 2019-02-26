using System;
using System.Collections.Generic;
using System.Linq;
using WalutyBusinessLogic.CurrencyConversion;
using WalutyBusinessLogic.LoadingFromFile;

namespace WalutyBusinessLogic
{
    class CurrencyConvertion
    {
        CurrencyRecord currencyRecord = new CurrencyRecord();
        CurrencyForConversation firstCurrencyConvertion = new CurrencyForConversation();
        CurrencyForConversation secondCurrencyConvertion = new CurrencyForConversation();

        public List<CurrencyForConversation> ConvertCurrency(string nameCurrency, string secondNameCurrency, 
            float amountCurrency, int date)
        {
            Loader loader = new Loader();
            Currency currency = loader.LoadCurrencyFromFile(nameCurrency);
            List<CurrencyRecord> listOfRecords = currency.ListOfRecords;
            CurrencyRecord desiredRecord = listOfRecords.Single(record => record.Date == date);
            var CurrencyConvertionList = new List<CurrencyForConversation>();

            firstCurrencyConvertion.Value = desiredRecord.Volume;
            firstCurrencyConvertion.Amount = amountCurrency;
            firstCurrencyConvertion.Name = nameCurrency;
            CurrencyConvertionList.Add(firstCurrencyConvertion);

            currency = loader.LoadCurrencyFromFile(secondNameCurrency);
            listOfRecords = currency.ListOfRecords;

            desiredRecord = listOfRecords.Single(record => record.Date == date);

            secondCurrencyConvertion.Name = secondNameCurrency;
            secondCurrencyConvertion.Value = currencyRecord.Volume;

            secondCurrencyConvertion.Amount = firstCurrencyConvertion.Amount * firstCurrencyConvertion.Value /
                                                   secondCurrencyConvertion.Value;
            CurrencyConvertionList.Add(secondCurrencyConvertion);

            return CurrencyConvertionList;
        }
    }
}
