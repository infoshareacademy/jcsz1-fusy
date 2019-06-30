using System;

namespace WalutyBusinessLogic.Services
{
    public interface IDateChecker
    {
        bool CheckingIfDateExistsForTwoCurrencies(DateTime dateCurrency, string firstNameCurrency,
            string secondNameCurrency);
        bool CheckingIfDateExistInRange(DateTime firstDate, DateTime secondDate, string currencyName);
    }
}
